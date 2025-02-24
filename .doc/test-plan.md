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

Using the email and password in the registered before execute the below action.

![image](https://github.com/user-attachments/assets/87cb7a8f-004d-4694-9435-85b03d1ca495)

In the response get the token attribute and save in someplace. See the image to understand.

![image](https://github.com/user-attachments/assets/d15491a3-af77-4064-9307-04b654cc81d2)

## Before another tests, do

Click in the top button "Authorize" and in the modal post your token.

![image](https://github.com/user-attachments/assets/249591be-09a0-46b4-b342-02060d3b0e12)

![image](https://github.com/user-attachments/assets/5c1c5543-2416-41e6-8927-7dabfb6d13d3)

## Create a product

Put the data in the action below and click in the execute button. So, with the response copy data.id value with the Guid and save in someplace too.

![image](https://github.com/user-attachments/assets/46671dfb-e9c0-49a7-a278-f2294994c172)

## Create a Sale

Put the data in the action below and click in the execute button. So, with the response copy data.id value with the Guid and save in someplace too.

![image](https://github.com/user-attachments/assets/590c22c7-acc1-41f1-8b43-66912587c7be)

## Change sale

I believe that the better use case to add product in the sale is in the segregate method, because this I create one action SaleProduct that make integrate the product in the sale. This method can be change the product item too.

To cancelate product item you can remove the item from sale. Below we have a sample from the use of the action.

![image](https://github.com/user-attachments/assets/8d730741-f55b-4205-ae5a-b085c0514b7c)

## Get a Sale

Enter with same Sale Id in apropriate in the action and click in the Execute button.

![image](https://github.com/user-attachments/assets/ac66da66-fbae-4711-8060-c3411cdb149c)
