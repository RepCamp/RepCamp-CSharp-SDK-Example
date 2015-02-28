using net.kriter.rcsdk.model;
using net.kriter.rcsdk.rest;
using RepCampSDKExample.application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepCampSDKExample
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {

                //Instantiate the main RepCamp SDK controller
                RepCampAPI repcampAPI = new RepCampAPI();

                //Specify API data to start up
                APIData apidata = ApiDataMaker.getAPIData();

                //Set API data to the SDK
                repcampAPI.setAPIData(apidata);

                Console.WriteLine("**********************************   INIT   **********************************");

                //Authenticate your self, just to test your API key out.
                if (repcampAPI.authenticateMe()) Console.WriteLine("Authentication ----------- OK");
                else Console.WriteLine("Authentication ----------- FAILED");

                //Instantiate the controllers
                CustomerController customerController = new CustomerController();

                ////Uncomment to delete customers
                //DateTime date = new DateTime(2015, 01, 01);
                //if (customerController.removeCustomers(date)) Console.WriteLine("Delete Customers - OK");
                //else Console.WriteLine("Delete Customers - FAILED");

                //Uncoment for single customer upload
                if (customerController.addCustomer("CT0001")) Console.WriteLine("Upload Customer - OK");
                else Console.WriteLine("Upload Customer - FAILED");

                ////Uncomment for customers upload
                ////Set date instead of null for a partial synchronization. If null, all customers will be uploaded
                //if(customerController.uploadCustomers(null)) Console.WriteLine("Upload Customers - OK");
                //else Console.WriteLine("Upload Customers - FAILED");

                //Uncomment to retrieve all customers data
                //List<String> criteria = new List<String>();
                //criteria.Add("code=CT0001");

                //List<Customer> customerslist = repcampAPI.getCustomers(criteria, 0, 1);

                //foreach (Customer customer in customerslist) Console.WriteLine(customer.ToString());

                Console.WriteLine("********************************** FINISHED **********************************");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
