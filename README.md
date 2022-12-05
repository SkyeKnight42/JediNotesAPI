# JediNotesAPI

Welcome to the Jedi Notes API.
Follow the steps below prior to running the application.

Step 1
Connect to your local database in Microsoft SQL Server Management Studio.
Take note of the Server name value.

Step 2
Open JediAPI application in Visual Studio 2022.

Step 3
In appsettings.json set the value of JediAPIConnectionString 
With the Server name value mentioned in step 2, replace any single ‘\’ characters with “\\”.
The value of JediAPIConnectionString is :
“Server=” + Server name + “;Database=JediDatabase;Trusted_Connection=true”

For Example
Server name  = (localdb)\Local
This is formatted to:  (localdb)\\Local
JediAPIConnectionString  = “Server=(localdb)\\Local;Database=JediDatabase;Trusted_Connection=true”
Save appsettings.json

Step 4
Open Package Manager Console
Note: This can be accessed in Visual Studio 2022 via View > Other Windows > Package Manager Console, or by pressing CTRL + Q and searching for “Package Manager Console”

In Package Manager Console run the command “Add-Migration InitialCreate”
Once this has completed run the command “Update-Database”
This will create a database for the JediNotes and the necessary table.

Step 5
Run the JediAPI application.

