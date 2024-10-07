                                    **Event Management System**


**Project Overview:**

  The event management system application allows users to browse and explore various events listed on the Events List page. By clicking the "View Details" button, users can access detailed information about an event, such as its description, location, and date. If an event interests them, they can register by providing their basic information on the Registration Page.
  
  For admins responsible for managing events, they must log in and complete basic authentication to access the event management features. Once logged in, admins can view the event list and have the ability to manage events. They can modify existing events to reflect updates, create new events, or delete old ones. Additionally, there is a "View Registrations" button that enables admins to view the details of users who have registered for a specific event.

**Technical information:**

  For developing the web application, I have used Asp.net MVC with core framework. For database connection, the entity framework was used in the code-first approach. For UI, HTML5 and CSS are used to make it beautiful to the user. 
  All the methods in the code are self-explanatory and I have used camel case syntax for declaring the variables. I have used basic HTML5 and CSS mostly without bootstrap as it’s one of the requirements. 


**Setting up the environment:**

•	The framework used is the latest .Net 8.0, for database I have used SQL Server.

•	We just have to initialize the DataSource in the EventContextModel.cs with the SQL Server name of the local system where the program should be run. 

•	For Admin login, the username is admin; password is 12345;

•	An attachment of sample events in the form of Insert query is added to the repo. It will help create the events in database and it will be easy to manipulate the events in application.

•	That’s it, just run the program and you will have access to all the events.


