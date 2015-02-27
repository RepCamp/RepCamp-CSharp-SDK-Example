using RepCampSDKExample.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepCampSDKExample.repositories
{
    public class CustomerRepository
    {
        //HERE IS WHERE YOU SHOULD CONNECT TO THE DATABASE AND RETRIEVE ALL YOUR DATA

    public List<MyCustomer> findAll(int skip, int take)
    {
        //Retrieve all Customers
        List<MyCustomer> customers = new List<MyCustomer>();

        //For the example to work
        if(skip < 2)
        {
            customers.Add(dataBaseCustomer1());
            customers.Add(dataBaseCustomer2());
        }

        return customers;
    }

    public List<MyCustomer> findAll(DateTime? date, int skip, int take) 
    {
        //Retrieve all Customers from a given date... so you make the synchronization lighter only uploading changes
        List<MyCustomer> modifiedCustomers = new List<MyCustomer>();

        //For the example to work
        if(skip < 2) {
            //Just a fake modification
            MyCustomer modifiedCustomer = dataBaseCustomer1();
            modifiedCustomer.comercial_name = "RepCamp";
            modifiedCustomers.Add(modifiedCustomer);
        }

        return modifiedCustomers;
    }

    public MyCustomer findByCode(String code)
    {
        //Retrieve this specific customer
        return dataBaseCustomer1();
    }

    public List<String> removedItems(DateTime? date)
    {
        //Retrieve all Customer codes from a given date... so you make the synchronization smart ;)
        List<String> removedCustomerCodes = new List<String>();

        //Just fake a customer removal
        removedCustomerCodes.Add("CT0002");

        return removedCustomerCodes;
    }
    
    private MyCustomer dataBaseCustomer1()
    {
        MyCustomer mycustomer = new MyCustomer();

        mycustomer.code = "CT0001";
        mycustomer.fiscal_name = "Kriter Software, S.L.";
        mycustomer.comercial_name = "Kriter Software";
        mycustomer.vat_number = "D58709832";
        mycustomer.telephone = "+34 937575997";
        mycustomer.telephone_2 = "";
        mycustomer.email = "support@repcamp.com";
        mycustomer.address = "Pablo Iglesias 63";
        mycustomer.address_2 = "PB L1";
        mycustomer.city = "Mataró";
        mycustomer.zip = "08302";
        mycustomer.state = "Barcelona (BCN)";
        mycustomer.country = "SPAIN";
        mycustomer.latitude = new Decimal(41.531395);
        mycustomer.longitude = new Decimal(2.43232);
        mycustomer.payment_method = "Bank Transfer 30 days";
        mycustomer.discount = new Decimal(10);
        mycustomer.description = "Kriter Software is a Business Management Information Systems developer. We work on masking technologies to give easy, simple, affordable, reliable and profitable solutions to our customers for the efficient management of their businesses";
        mycustomer.status = (short) 1;
        mycustomer.pricelist = "01";
        mycustomer.language = "en";

        //NOTE:  To match the existing Rep from your ERP and the one at RepCamp.com, you'll have to specified a code at reps management page.

        //        List<String> repcodes = new ArrayList<String>();
        //        repcodes.add = "ERP_ID";
        //        repcodes.add = "ERP_ID";
        //        repcodes.add = "ERP_ID";
        //
        //        mycustomer.Reps(repcodes);

            return mycustomer;
        }

        private MyCustomer dataBaseCustomer2()
        {
            MyCustomer mycustomer = new MyCustomer();

            mycustomer.code = "CT0002";
            mycustomer.fiscal_name = "Maname Camp, LTD";
            mycustomer.comercial_name = "Man & Surf";
            mycustomer.vat_number = "D58709832";
            mycustomer.telephone = "(831) 758-7214";
            mycustomer.telephone_2 = "";
            mycustomer.email = "comercial@maname.com";
            mycustomer.address = "15 Pujol St";
            mycustomer.address_2 = "";
            mycustomer.city = "Temecula";
            mycustomer.zip = "92589";
            mycustomer.state = "California (CA)";
            mycustomer.country = "ESTADOS UNIDOS DE AMERICA";
            mycustomer.latitude = new Decimal(-117.1500000);
            mycustomer.longitude = new Decimal(33.4900000);
            mycustomer.payment_method = "Bank Transfer 30 days";
            mycustomer.discount = new Decimal(0);
            mycustomer.description = "Some Comments";
            mycustomer.status = (short) 1;
            mycustomer.pricelist = "02";
            mycustomer.language = "en";

        //NOTE:  To match the existing Rep from your ERP and the one at RepCamp.com, you'll have to specified a code at reps management page.

        //        List<String> repcodes = new ArrayList<String>();
        //        repcodes.add = "ERP_ID";
        //        repcodes.add = "ERP_ID";
        //        repcodes.add = "ERP_ID";
        //
        //        mycustomer.Reps(repcodes);

            return mycustomer;
        }
    }
}
