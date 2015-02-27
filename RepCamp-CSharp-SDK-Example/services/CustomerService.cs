using net.kriter.rcsdk.model;
using RepCampSDKExample.domain;
using RepCampSDKExample.mappers;
using RepCampSDKExample.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepCampSDKExample.services
{
    public class CustomerService
    {
        //Retrieve your customers from whatever source you like (Data Base, file, WebService, etc.) do some logic, map them to RepCamp's customer type and you are good to go!

        public List<Customer> findAll(int skip, int take)
        {
            CustomerRepository customerRepository = new CustomerRepository();

            //Retrieve your database customers
            List<MyCustomer> mycustomers = customerRepository.findAll(skip, take);

            return mapAndTreatMyCustomers(mycustomers);
        }

        public List<Customer> findAll(DateTime? date, int skip, int take)
        {
            CustomerRepository customerRepository = new CustomerRepository();

            //Retrieve your database customers from a given date (just modified customers)
            List<MyCustomer> mycustomers = customerRepository.findAll(date, skip, take);

            return mapAndTreatMyCustomers(mycustomers);
        }

        public Customer findByCode(String code)
        {
            CustomerRepository customerRepository = new CustomerRepository();

            //Retrieve your database customer from a given criteria
            MyCustomer mycustomer = customerRepository.findByCode(code);

            //Instantiate the mapper
            CustomerMapper customerMapper = new CustomerMapper();

            return customerMapper.map(mycustomer);
        }

        public List<String> removedItems(DateTime? date)
        {
            CustomerRepository customerRepository = new CustomerRepository();
            return customerRepository.removedItems(date);
        }

        private List<Customer> mapAndTreatMyCustomers(List<MyCustomer> mycustomers)
        {
            //New list of "RepCamp type" customers
            List<Customer> customers = new List<Customer>();

            //Instantiate the mapper
            CustomerMapper customerMapper = new CustomerMapper();

            foreach(MyCustomer mycustomer in mycustomers)
            {
                //Treat them
                customers.Add(customerMapper.map(mycustomer));
            }

            return customers;
        }
    }
}
