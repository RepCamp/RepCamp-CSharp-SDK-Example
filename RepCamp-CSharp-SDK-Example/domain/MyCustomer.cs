using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepCampSDKExample.domain
{
    public class MyCustomer
    {
        //My ERP or CRM customer to be uploaded

        public String code { get; set; } //required
        public String vat_number { get; set; }
        public String fiscal_name { get; set; }
        public String comercial_name { get; set; } //required
        public String telephone { get; set; }
        public String telephone_2 { get; set; }
        public String email { get; set; }
        public String address { get; set; }
        public String address_2 { get; set; }
        public String city { get; set; }
        public String zip { get; set; }
        public String state { get; set; }
        public String country { get; set; }
        public Decimal latitude { get; set; }
        public Decimal longitude { get; set; }
        public String description { get; set; }
        public Decimal discount { get; set; }
        public String payment_method { get; set; }
        public short status { get; set; }
        public String pricelist { get; set; }
        public List<String> reps { get; set; }
        public String language { get; set; }
    }
}
