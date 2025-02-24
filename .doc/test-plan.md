# Flow of the system test

I would like make the application in Angular to text back-and application, but the time was short to start. But if technical team want I can show a particular code in my repository.

The code pattner used was the equals the indicate in the template in the all code. Some code points like in the handles usually I create a Service to better segregate code, but I beliave that the avaliation objective was check if I can continuate in the existent pattern.


# Folders

 - **Products** -> To create a product in the database.
 -  **Sales** -> To create a sele in the database.
 -  **SaslesProducts** -> To include a product in the sale.

# Step one

Before start the tests is important create the database. I recommend open the solution in the Visual Studio and build solution to restore the libs before execute migration.

To execute migration you can open cmd command and execute the line bellow:

    dotnet ef database update --project <PATH TO ORM PROJECT>
    --startup-project <PATH TO WebApi PROJECT> --msbuildprojectextensionspath obj\

> Attention to markups in the line and change with the correct project path.

# Step two

After creating the database, you can run the application in Visual Studio to start testing. Since I couldn not create the frontend application to facilitate testing, we can run tests in the Swagger tool.

## Create a user

To authenticate I use the JWT that existing feature in the API and to facilitate the test the User CRUD is anonymous method. So create the user in the system.

Use the below routine

![image](https://github.com/user-attachments/assets/706a695a-b8a2-47b1-b6d3-f1f88ddeac9e)

## Login in the sistem

Use the below routine
![image](https://github.com/user-attachments/assets/87cb7a8f-004d-4694-9435-85b03d1ca495)

