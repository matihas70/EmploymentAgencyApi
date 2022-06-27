# EmploymentAgencyApi
Tools: C#/.Net, ASP.NET Core, Entity Framework </br>
This project presents API for employment agency. Database was created with Entity framework. Contains three controllers: for employees, companies and contract. Endpoints in each controller:
1. EmployeesController - Route: api/employee
  - Get: default GET endpoint returns "Hello user"
  - Get /{id}: returns an emloyee which id is in route
  - Post: creates new employee, example of request body:
  ```
  {
    "Name": "Piotr",
    "LastName": "Szmit",
    "Age": 17,
    "Nationality": "Poland",
    "BirthDate": "2005-02-09",
    "PhoneNumber": "+48 637 819 321",
    "Email": "piotrszmit@gmail.com",
    "City": "Poznań",
    "Street": "Wojska Polskiego 23/5",
    "PostalCode": "31-903"
  }
  ```
  - Delete /{id}: remove employee which id is in route
  - Put /contact/{id}: updates employee contact data(phone number and e-mail), example of request body:
  ```
  {
    "PhoneNumber": "+48 913 853 123",
    "Email": "costam@gmail.com"
  }
  ```
  - Put /address/{id}: updates employee address data:
  ```
  {
    "City": "Kalisz",
    "Street": "Al. Wojska Polskiego 23/3",
    "PostalCode": "62-800"
  }
  ```

2. CompaniesController - Route: api/company
  - Get /{id}: returns a company which id is in route
  - Post: creates new company, example if request body:
  ```
  {
    "Name": "Kaufland",
    "Size": 3,
    "Industry": "Market",
    "City": "Poznań",
    "Street": "Pączkowa 56",
    "PostalCode": "85-901"
  }
  ```
  
 3. ContractsController - Route: api/contract
    - Get /{id}: returns a contract data witch id is in route
    - Post /{employeeId}/{companyId}: creates contract between employee and company which ids are in route

To map classes I used AutoMapper
