# Todo-Sample-Azure Tables

ToDo sample app using Asp.net core, Azure Tables, Angular and Mobile Support with Xamarin

To learn more about code generation download <a href="https://www.silverdawn.com/download-silvermodel/">SilverModel</a> and open Model(todo.gen) to generate code. 

<h1>Introduction to the ToDo Sample Application</h1>
This is a quick introduction to the ToDo sample app. The sample has been written to give you a quick introduction on using SilverModel and also so that you can see how a model is turned into code.

Going forward a version of this application will be used to demonstrate our generators and it is currently working with our mobile, web and database code generators.

The code for this sample can be downloaded from GitHub at <a href="https://github.com/Silverdawn/Todo-Sample-.NetCore">https://github.com/Silverdawn/Todo-Sample-.NetCore</a>
<h1>Todo Model Design</h1>
The model has two main classes.
<p id="NIiHxIs"><img class="alignnone size-full wp-image-1014 " src="https://www.silverdawnsoftware.com/wp-content/uploads/2017/09/img_59ba59775a895.png" alt="" /></p>
The first class is Users and the second is Tasks. This model allows you to keep track of a list of tasks for a user.

To use the application first you would add a user and then you would add a task to that user.

This model also allows the demonstration of parent-child relationships within a model and how that code is generated.

Going forward we will also use this sample application to demonstrate more advanced techniques and other technologies.
<h1>ToDo Architecture</h1>
In this section, I will explain the architecture used to create the sample application. As much as possible the application has been written with open source technologies such as Microsofts. Net Core Framework.

Firstly let us look at a diagram of the Todo Application Architecture and all the software layers within it.
<p id="crsExPx"><img class="alignnone size-full wp-image-1017 " src="Todo Azure Tables Architechure.png" alt="" /></p>

<h2>Application Layers</h2>
Now I will explain the different layers in the application and how the code generators work together.
<h3>Database Layer</h3>
In the ToDo solution, the project "ToDo" holds all the database code. This code uses the "Azure Tables" code generator and generates the code for the saving the model to Azure Tables.

All the classes that Azure Tables needs to define and use the database are in the "Database" folder.

The Azure Tables is using the same model as the Entity Framework Todo samples. This demostrates that your models can easliy be used with Azure Tables or Entity Framework.

<h3>Update and View Models</h3>
This layer holds all the view models and the models for adding, updating and delete the database entities.

Also, the code that updates the database and creates the views is in this layer also.

The code for the Views is in the "Views" folder.

The code for the adding, updating and delete is in the "Transactions" folder.

The code for this is generated by the "Azure Tables" code generator and the code is in the "ToDo" project

In the future, it will be possible to swap these layers out to access different types of database e.g. MongoDB
<h3>REST API</h3>
To allow external applications e.g Mobile apps to access the data we need a REST web service. The Rest API uses the "Update and View Models" layer to access the database.

The code for this is generated by the "WebAPI Core" code generator and the code is in the "ToDoRestAPI" project
<h3>REST Access API</h3>
This layer manages the communications between the Mobile App and the REST API.

It also has all the view models and transaction models defined as well.

The code for this is generated by the "REST Access" code generator and the code is in the "ToDoRESTAccess" project
<h3>Andriod/iPhone Layer</h3>
This is where all the Xarmin Forms are created that interact with the REST Access API.

All the XAML Forms and View Models for the Mobile Applications are stored in this layer.

The code for this is generated by the "Xarmin Forms" code generator and the code is in the "ToDoMobile" project.
<h3>Angular REST Access Services and Models</h3>
For the Angular Forms to communicate with the REST API, they first need all the Models and Services they can use to be defined.

This layer provides all the infrastructure for the above that the Angular forms require. The code for this is generated by the "AngularJS4Material" code generator and the code is in the "ToDoWebClient" project.
<h3>Angular HTML Client</h3>
The final piece of the puzzle is the HTML forms for the Angular Application.

This layer is where all the HTML and Typescript code is held to run the application.

The code for this is generated by the "AngularJS4Material" code generator and the code is in the "ToDoWebClient" project.
<h1>Questions</h1>
If you have any questions about the application or how the code generators are working please contact us on our <a href="http://support.siverdawnsoftware.com/">support website</a> and we will be happy to help.