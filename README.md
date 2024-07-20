# ConsoleAppEmployeeManager

This is a console application for managing employee records stored in a JSON file. The application supports adding, updating, retrieving, and deleting employee records.

## Employee Record Format

- **Id**: `int`
- **FirstName**: `string`
- **LastName**: `string`
- **SalaryPerHour**: `decimal`

## Operations

The application accepts command-line arguments to perform the following operations:

- **Add a new employee record**:  
```sh
-add FirstName:John LastName:Doe Salary:100.50
```

- **Update an existing employee record**. You can update any field except `Id`:
```sh
-update Id:123 FirstName:Doe
```
```sh
-update Id:123 Salary:1000000
```


- **Retrieve an employee record by `Id`**:  
```sh
  -get Id:1
  ```

- **Delete an employee record by `Id`**:
 ```sh
    -delete Id:1
```
- **Retrieve all employee records**:
```sh
   -getall
```
## Running the Application

1. **Clone the repository**:
 ```sh
 git clone https://github.com/VladimirBudilov/ConsoleAppEmployeeManager.git
 ```

2. **Navigate to the project directory**:
```sh
    cd ConsoleAppEmployeeManager/Presentation
```
3. **Build the application**:
```sh
    dotnet build
```

4. **Run the application with the desired operation**:
```sh
    dotnet run -- -add FirstName:John LastName:Doe Salary:100.50
```
