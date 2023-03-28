
# Order Management System 

A Sales Order Management System Task given By IW.

Requirements are:
  - Create new database tables Using Code First In Entity Framework.
  - Blazor WebAssembly app with an interface to show data from DB.
  - Make an ability to change and save data in the application: state, name, and dimensions.
  - Add the ability to create and delete orders, windows and elements.
  - Optional: Interface validations. DTO. Separated BLL and DAL projects.
  




## Prerequisites
- .NET Core SDK

- PostgreSQL

## Installation


- Clone this repository by using

```bash
  git clone https://github.com/Farhad-Rakib/OMS.git
```
- Change appsettings.json with credentials.

- Add migrations and update database in Infrastructure Project by using PMC

```bash
  Add-migration "(Migration_Name}"
  update-database
```
- Set the SERVER Project as the startup  Project




    
## Project Description

- Architecture Followed :
  -  Clean Architecture AKA Onion Architecture with Blazor web Assembly (.Net Core Hosted)
- Major Library Used:
  -  AutoMapper
  - EntityFrameworkCore
  - NpgSql.EntityFrameworkCore.PostgreSQL
- Database Used: PostgreSQL
- Project Depedency Flow:
  - BLAZOR Server --> Infrastructure --> Appllication --> Core 

    ### Backend Project
    OrderController is responsible for receiving all the request from Blazor front-end project. Swagger is also installed to test the APIs.
    - Swagger UI : https://localhost:*PORT/oms/apis/
    ### Frontend Project
    - On project run(Server app as the starting project) , '/' is set to the list of orders .
    - '/orders' also show all the orders entered by the users
    - 'create order' button will bring the order creation Form which is a nested form of windows and sub-elements.
    - Validations are applied where needed.
    - Seperate component and cs file(partial class implementation)



