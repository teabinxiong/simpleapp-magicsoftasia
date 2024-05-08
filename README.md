# Simple App - Magicsoft Asia
This project aims to demonstrate the usage of Clean Architecture with concern of OOP in .NET project.

## Author
Tea Binxiong

## Description
This repository contains a sample Api Project.

1. **Api Project**: 
   - [ApiProject](./src/ApiProject)

##  Structure of this project
1. The project will become more maintainable by using clean architecture, as the dependencies are point inward in 1 direction.
2. [Domain Layer](./src/ApiProject/ApiProject.Domain) - A Rich Domain Model was utilized in the project to better separate of reponsibilities between the application service layer and the domain layer.
3. [Application Service Layer](./src/ApiProject/ApiProject.Service) - The Application Service layer is where the Business Logics sit. Within this layer, we delegate the majority of the implementation such as Repositories,Email,even Clock to the infrastructure layer. This prevent third-party dependencies from polluting the Business Logic layer. Therefore in the event of switching email vendor, minimal or no required in the business layer.
4. This is where Interface class prove useful, we only need to inject the abstraction (which is the Interface class) into the service class, eliminating the need to write the implementation.
5. [Result Pattern](./src/ApiProject/ApiProject.Domain/Abstractions/Result.cs) - A Result Pattern was employed in this project to streamline errors, particularly the Application Errors. These Errors were defined within the project and managed within the Result Class.
6. Clean Architecture also improve the testibility of the project as we are able to test each layer independently. With the Dependency Injection employed in this project, we can mock the implementation of most of the service, including the DateTime utility class (e.g. DateTime.UtcNow()). [Clock](./src/ApiProject/ApiProject.Infrastructure/Clock/DateTimeProvider.cs)
7. [Infrastructure Layer](./src/ApiProject/ApiProject.Infrastructure) - The Infrastructure is where we incorporate thirdparty code,and database connection, etc. By seperating the thirdparty code from the business layer and domain layer, migrating to another vendor become easier as we may only required to update Infrastructure Project.

## Repository URL
[simpleapp-magicsoftasia](https://github.com/teabinxiong/simpleapp-magicsoftasia)





