# Agri-Energy Connect Prototype

## Project Overview
Agri-Energy Connect is a prototype web application designed to bridge the gap between the agricultural sector and green energy technology providers. The platform enables farmers and employees to collaborate, manage products, and access resources for sustainable agriculture and renewable energy.

## Features
- Secure authentication with Farmer and Employee roles
- Farmers can add/view their own products
- Employees can add/view farmer profiles and view/filter all products
- Responsive, user-friendly interface
- Data validation and error handling

## Technology Stack
- ASP.NET Core MVC (C#)
- Entity Framework Core (for database)
- SQL Server LocalDB or SQLite (for development)
- Bootstrap (for UI)

## Database Schema
### Tables
- **Farmers**: Id, Name, Email, Location
- **Employees**: Id, Name, Email, Department
- **Products**: Id, Name, Category, ProductionDate, FarmerId (FK)
- **AspNetUsers**: (Identity table for authentication)

### Sample Data
- 2 Farmers, 2 Employees, 3 Products (see /Data/SeedData.cs)

## User Roles
- **Farmer**: Add/view their own products
- **Employee**: Add/view farmer profiles, view/filter all products

## Setup Instructions
1. Clone the repository
2. Open in Visual Studio 2022+
3. Restore NuGet packages
4. Update `appsettings.json` with your database connection string
5. Run `Update-Database` in Package Manager Console to apply migrations
6. Press F5 to run the application

## Usage
- Register as a Farmer or Employee
- Log in to access your dashboard
- Farmers: Add/view products
- Employees: Add/view farmers, view/filter products

## Development Notes
- Data validation is enforced via DataAnnotations
- Role-based authorization is implemented
- See `/Data/SeedData.cs` for sample data

## License
For educational use only. 