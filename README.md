# CarServiceApp
### Console App for Car Service Company 

#### Core Functionality:
- at start checking if sql database is created
- checking if sql database is populated, if not app will populate database with dummy data from csv file
- ability to create xml files from dummy data
- managing employees information
- managing clients information
- save (on demend) all changes made in database to json file and audit txt file

#### Employees functionality:
- List all employees
- Add new employee
- Find employee by id
- Remove selected employee
- Show more details:
  - Show minimum salary in the company
  - Show departments in company
  - Show ordered employees by: last name / salary / date of employment
  - Show empolyees with salary greater then entered by user
  - Show employees older then age entered by user
  - Show employees in chosen department

#### Clients functionality
- List all clients
- Add new client
- Find client by id
- Show clients in chosen department
