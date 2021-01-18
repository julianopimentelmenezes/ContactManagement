# Contact Management

This project is for manage contacts. 
You can see the contact list, detail a contact, create a new contact, update a contact and delete a contact.

### Installing

Open the ContactManagement.sln in the Visual studio 2019
In the solution properties, select multiple startup projects and choose the ContactManagement.API and ContactManagement.MVC projects.
Please, check if the applications have the appsettings.Development.json file.
After it, in the file "appsettings.Development.json" from ContactManagement.MVC project, check if exists the tag "BasePathUrlAPI". This tag is responsible for store the API URL.

## Running the tests

For automated tests, you will access the Test Explorer windows.
After, is just press the "Run All Tests" buttom.

## Built With

* [NET Core 5.0] - The web framework used
* [Visual studio 2019] - The IDE used

## Authors

* **Juliano Menezes**

## License

This project is licensed under the MIT License

## Premises

For this solution, i chose separete the front-end project to the back-end project. With this, both the back-end and the front-end can be replaced without impact.
I used dependency injection beacause is a good developement pratice.
To describe the API services i used swagger. 
I used automapper to do the bind from model view to domain class.
In this project was used the new functionality InMemoryDatabase. This net.core 5.0 functionality is a easy way to test your application without the need to have a dabatabase.
For the test was used xunit framework.
