using net.kriter.rcsdk.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepCampSDKExample.application
{
    public class ApiDataMaker
    {
        public static APIData getAPIData()
        {
            //API Data to be modified. Retrieve it from a *.properties file or just stick it in your code!

            String url = "http://api.repcamp.com";
            String username = "your@email.com";
            String password = "Sha1_encrypted_password";
            String secretkey = "your_secret_key";
            String apikey = "your_api_key";
            String apiversion = "v1";

            return new APIData(url, username,password,apikey,secretkey,apiversion);
        }
    }
}
