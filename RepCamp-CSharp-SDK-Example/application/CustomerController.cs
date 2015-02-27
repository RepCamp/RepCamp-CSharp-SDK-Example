using net.kriter.rcsdk.model;
using net.kriter.rcsdk.rest;
using RepCampSDKExample.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepCampSDKExample.application
{
    public class CustomerController
    {
        RepCampAPI repcampAPI = null;
        CustomerService customerService = null;

        public CustomerController()
        {
            this.repcampAPI = new RepCampAPI();
            this.customerService = new CustomerService();
        }

        public bool addCustomer(String code)
        {
            try
            {
                Customer customer = this.customerService.findByCode(code);

                GenericResponse resp =  repcampAPI.addCustomer(customer);

                if(resp.singleResponse != null)
                {
                    if(resp.singleResponse.error != null)
                    {
                        Console.WriteLine("Failed to upload customer: (CODE) " + customer.code + " Error: " + resp.singleResponse.error);
                    }
                }

                Console.WriteLine(resp.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

            return true;
        }

        public bool removeCustomers(DateTime? date)
        {
            try
            {
                List<String> customerCodes = customerService.removedItems(date);

                List<String> errors = new List<String>();


                foreach(String code in customerCodes)
                {
                    GenericResponse resp =  repcampAPI.removeCustomer(code);

                    if(resp.singleResponse != null)
                    {
                        if(resp.singleResponse.error != null)
                        {
                            errors.Add(code);
                            Console.WriteLine("Failed to delete customer: (CODE) " + code + " Error: " + resp.singleResponse.error);
                        }
                    }
                }

                if(errors.Count() == 0)
                {
                    if(customerCodes.Count() == 0) Console.WriteLine("Customers to Delete: None");
                    else Console.WriteLine("Customers Deleted: " + customerCodes.Count());
                    return true;
                }
                else
                {
                    Console.WriteLine("Customers Deleted: ERROR, Check the error log for details");

                    String msg = "";
                    foreach(String err in errors)
                    {
                        msg += err + "\n";
                    }

                    Console.WriteLine("Failed to delete this customers: " + msg);

                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to delete customers");
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

        public bool uploadCustomers(DateTime? date)
        {
            try
            {
                GenericResponse resp = null;
                int skip = 0, take = 100;
                bool finish = false;

                int totals = 0;
                int errorsnum = 0;
                int updates = 0;
                int inserts = 0;

                List<String> errors = new List<String>();

                while(!finish)
                {
                    List<Customer> customers = null;

                    if(date == null) { customers = customerService.findAll(skip,take); }
                    else { customers = customerService.findAll(date, skip,take); }

                    if(customers.Count() > 0)
                    {
                        resp = repcampAPI.uploadCustomers(customers);

                        if(resp.bulkResponse != null)
                        {
                            totals += resp.bulkResponse.total;
                            inserts += resp.bulkResponse.inserts;
                            updates += resp.bulkResponse.updates;
                            errorsnum += resp.bulkResponse.errors;

                            if(resp.bulkResponse.errors > 0)
                            {
                                foreach(String code in resp.bulkResponse.items_error) { errors.Add(code); }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Customers Upload: ERROR, Check the error log for details");
                            Console.WriteLine("URL: " + resp.url);
                            Console.WriteLine("STATUS: " + resp.status);
                            Console.WriteLine("MESSAGE: " + resp.message);
                        }

                        skip += take;
                    }
                    else
                    {
                        finish = true;
                    }
                }



                if(errorsnum == 0)
                {
                    if(totals == 0) Console.WriteLine("Customers to Upload: None");
                    else
                    {
                        Console.WriteLine("Customers Uploaded: " + totals);
                        Console.WriteLine("Customers Added: " + inserts);
                        Console.WriteLine("Customers Updates: " + updates);
                        Console.WriteLine("Customers Errors: " + errorsnum);
                    }

                    return true;
                }
                else
                {
                    Console.WriteLine("Customers Upload: ERROR, Check the error log for details");

                    String msg = "";
                    foreach(String err in errors)
                    {
                        msg += err + "\n";
                    }

                    Console.WriteLine("Failed to upload this customers: " + msg);

                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Customers Upload: ERROR, Check the error log for details");
                Console.WriteLine("Failed to upload customers");
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }
    }
}
