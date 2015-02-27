# RepCamp-CSharp-SDK-Example

## Motivation
This repo contains an example and a **Getting Started** Project for RepCamp's C# SDK. The objective is to get familiar with the SDK and to provide, a proposal of an architecture for synchronizer application. With the help of the SDK you will be able to retrieve the data from whatever source you have (ERP, CRM, E-Commerce, etc.) and upload it smoothly to your account at RepCamp.com. 

## What is RepCamp?
RepCamp is a powerful **Mobile Application** that provides the Sales Representatives with all the information needed to carry out a productive and comprehensive Commercial Management. Apart from having all the customer information in a single Dashboard -georeferencing, statistics, orders, etc.- you’ll be able to show an elegant **Product Catalog** by categories and brands, with spceial prices, promotions, images, etc. so you can **make Orders** on the spot, without further delay, instantly closing business deals wherever you are. RepCamp is powered by **Kriter Software**, founded in 1989, who has been manufacturing management software and providing business solutions for huge variety of companies.

## Partner Program
Join the **Partner Program** to earn client revenue, discover how [here](http://www.repcamp.com/en/partner).
And access exclusive developer resources [here](http://developers.repcamp.com).

## What does the RepCamp SDK includes?
- A set of platform [**Objects**](http://www.developers.repcamp.com) that RepCamp has such as: Customers, Products, Categories, PriceLists, etc.
- A **REST Services** interface so you forget about http calls and focus on transffering back and forth the data.
- A [**Main Controller**:](http://www.developers.repcamp.com) The RepCampAPI is the main cantroller wich you will be using for authenticating and centralizing the API calls.

## RepCamp C# SDK Installation
For now there is a beta version of the sdk available in the [downloads](http://developers.repcamp.com/index.php?route=article&path=24_37&article_id=203) section of developed.repcamp.com.
Once the stable version is finished you will be able to reference it as a NuGet package.

## Dependencies
The SDK uses the well known [RestSharp](http://restsharp.org) library to parse and send/recieve data of an from the Rest services that RepCamp provides.

## Lets Code!

- Instantiate the main RepCamp SDK controller
```c
RepCampAPI repcampAPI = new RepCampAPI();
```
- Specify API data to start up the authentication.
```c
APIData apidata = new APIData(
      "url",
      "username",
      "password", //Sha1
      "apikey",
      "secretkey",
      "apiversion" //Just hardcode the version, for now is "v1"
);
```
- Set API data to the SDK
```c
repcampAPI.setAPIData(apidata);
```
- Authenticate your self, just to test the API key out.
```c
if (repcampAPI.authenticateMe()) Console.WriteLine("Authentication ----------- OK");
else Console.WriteLine("Authentication ----------- FAILED");
```
**Upload**

- Create a Customer
```c
Customer customer = new Customer();
//Set all necessary atributes
customer.code = "CT0001";
customer.fiscal_name = "Kriter Software, S.L.";
customer.comercial_name = "Kriter Software";
customer.vat_number = "D58709832";
customer.telephone = "+34 937575997";
customer.telephone_2 = "";
customer.email = "support@repcamp.com";
customer.address = "Pablo Iglesias 63";
customer.address_2 = "PB L1";
customer.city = "Mataró";
customer.zip = "08302";
customer.state = "Barcelona (BCN)";
customer.country = "SPAIN";
customer.latitude = new Decimal(41.531395);
customer.longitude = new Decimal(2.43232);
customer.payment_method = "Bank Transfer 30 days";
customer.discount = new Decimal(10);
customer.description = "This is just a comment area";
customer.status = (short) 1;
customer.pricelist = "01";
customer.language = "en";
//etc.
```
- Upload it and handle the response
```c
GenericResponse resp =  repcampAPI.addCustomer(code);

if(resp.singleResponse != null)
{
    if(resp.singleResponse.error != null)
    {
        errors.Add(code);
        Console.WriteLine("Failed to add customer: (CODE) " + code + " Error: " + resp.singleResponse.error);
    }
}
```

**Query RepCamp to obtain its data**

```c
List<String> criteria = new List<String>();
criteria.Add("code=CT0001");

List<Customer> customerslist = repcampAPI.getCustomers(criteria, 0, 1);

foreach (Customer customer in customerslist) Console.WriteLine(customer.ToString());
```

