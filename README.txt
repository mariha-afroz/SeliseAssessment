Project Overview

Introduction:
This document provides an overview of the architecture and implementation details of the Order and Product Management System developed as part of the interview assessment. 
The system is designed with a focus on loose coupling and maintainability, utilizing best practices in software architecture and design.

Architecture:
The project is structured into three main layers to ensure separation of concerns and enhance maintainability:

Data Access Layer: 
Handles all database interactions and is implemented using Entity Framework Core. 
It includes two managers (ProductManager and OrderManager) and corresponding interfaces (IProduct and IOrder).

Domain Layer: Contains the domain models (Product and Order) and is crucial for the business logic.

Application Layer: Comprises two main services, ProductService and OrderService, which are loosely coupled and interact with the Data Access Layer via interfaces.

Database Design:
The DataAccessLayer contains a DbModel class with virtual DbSet properties for Product and Order, designed to be the ORM representation for database operations. 
Migrations are prepared but not executed due to the absence of a database connection string.

Core Functionalities:
Each service (Product and Order) in the application layer is designed to handle four basic operations:

Add (CreateProduct/CreateOrder)
Update (UpdateProduct/UpdateOrder)
Fetch (GetProductById/GetOrderById)
Fetch All (GetAllProducts/GetAllOrders)
These methods are implemented in the respective managers and exposed via interfaces.

Also The Product_Service class has the core functionalities:
AddNewProduct
UpdateProductDetails
FetchProductDetailsById
FetchListOfProducts

The remaining core functionalities (which are mentioned for OrderService) were intended to be implemented in the Order_Service class following the patterns established in Product_Service.

Additionally, the services, including IProduct with ProductManager and IOrder with OrderManager, were registered in the program.cs file.

CQRS Pattern:
The project adopts the Command Query Responsibility Segregation (CQRS) design pattern, particularly in the ProductService, to separate read operations from write operations, enhancing scalability and maintainability.

Challenges and Resolutions:
Namespace Conflicts: 
Encountered issues with namespace conflicts due to similar naming conventions in .NET framework classes. 
Resolved by explicitly specifying the namespaces to ensure the correct classes were referenced.

Event-Driven Architecture: Not implemented. Intended to use RabbitMQ for messaging and event-driven interactions between services that are created.

Setup and Configuration:
Dependencies: Ensure all project references are correctly set up as per the solution architecture.
Database Configuration: Set up the connection string in the configuration file and execute migrations to create the database schema.

The project lays a solid foundation for a robust Order and Product Management System with a clear focus on clean architecture principles and future scalability. 
Further enhancements will include integrating advanced messaging capabilities and completing the pending service functionalities.

