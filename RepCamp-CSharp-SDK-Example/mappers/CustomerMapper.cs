using net.kriter.rcsdk.model;
using RepCampSDKExample.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepCampSDKExample.mappers
{
    public class CustomerMapper
    {
        //Map your customer model with the RepCamp Customer so it can be pushed!

        public Customer map (MyCustomer mycustomer)
        {
            Customer customer = new Customer();


            //NOTE: If RepCamp's customer model has more attributes than yours just forget them. No blank mapping needed.
            //      If Your customer has more attributes that you would like RepCamp to have just wait a bit... or send an email to support@repcamp.com. We are working hard to satisfy your needs.

            customer.code = mycustomer.code;
            customer.vat_number = mycustomer.vat_number;
            customer.fiscal_name = mycustomer.fiscal_name;
            customer.comercial_name = mycustomer.comercial_name;
            customer.telephone = mycustomer.telephone;
            customer.telephone_2 = mycustomer.telephone_2;
            customer.email = mycustomer.email;
            customer.address = mycustomer.address;
            customer.address_2 = mycustomer.address_2;
            customer.city = mycustomer.city;
            customer.zip = mycustomer.zip;
            customer.state = mycustomer.state;
            customer.country = mycustomer.country;
            customer.latitude = mycustomer.latitude;
            customer.longitude = mycustomer.longitude;
            customer.description = mycustomer.description;
            customer.discount = mycustomer.discount;
            customer.payment_method = mycustomer.payment_method;
            customer.status = mycustomer.status;

            if(mycustomer.pricelist != null) customer.pricelist = mycustomer.pricelist;

            //if(mycustomer.reps.Count() > 0) customer.reps = mycustomer.reps;

            //TODO: Uncomment when SDK includes CustomerLanguageType in the future versions
            //if(mycustomer.language.equalsIgnoreCase("ca")) customer.longitude = CustomerLanguageType.CATALAN;
            //else if(mycustomer.language.equalsIgnoreCase("es")) customer.setLanguage = CustomerLanguageType.SPANISH;
            //else customer.language = CustomerLanguageType.ENGLISH;

            return customer;
        }
    }
}
