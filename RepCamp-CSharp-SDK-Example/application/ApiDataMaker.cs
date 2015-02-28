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

            //String url = "http://api.repcamp.com";
            //String username = "your@email.com";
            //String password = "Sha1_encrypted_password";
            //String secretkey = "your_secret_key";
            //String apikey = "your_api_key";
            //String apiversion = "v1";

            String url = "http://api.repcamp.com";
            String username = "marc.mora@kriter.net";
            String password = "7c222fb2927d828af22f592134e8932480637c0d";
            String secretkey = "7677e9f1cdd28f672589ccb9740487be655ddfb254e73e2377f2f";
            String apikey = "3ec02e37be25462caa22f98fc20d840b54e73e2377e8a";
            String apiversion = "v1";

            return new APIData(url, username,password,apikey,secretkey,apiversion);
        }
    }
}
