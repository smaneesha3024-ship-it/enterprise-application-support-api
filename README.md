# Enterprise Application Support API

A personal portfolio project demonstrating application development and support capabilities using C#, ASP.NET Core Web API, Entity Framework Core, and MySQL.

## Project Overview

This project simulates a warehouse order management application. It provides REST APIs for managing customer orders, tracking application incidents, investigating issues, and monitoring incident-resolution metrics.

The project focuses on practical application support scenarios, including data validation, error handling, SQL-based investigation, logging, and root-cause analysis.

## Technology Stack

- C#
- ASP.NET Core Web API (.NET 10)
- Entity Framework Core
- MySQL
- SQL
- Swagger / OpenAPI
- VS Code

## Key Features

### 1. Order Management
- Retrieve all orders.
- Retrieve an order by ID.
- Create new orders.
- Validate customer information, SKU, quantity, and order status.

### 2. Incident Management
- Create and retrieve application incidents.
- Track incident severity and status.
- Assign incidents to support personnel.
- Record root causes and resolution notes.
- Track incident resolution timestamps.

### 3. Application Support and Troubleshooting
- Centralized exception handling.
- Application error logging.
- Safe error responses to API clients.
- Simulated application failure testing.
- Incident investigation and root-cause documentation.

### 4. Incident Reporting
- Total incident count.
- Open incident count.
- High-severity open incidents.
- Resolved incident count.
- Average incident resolution time.

### 5. SQL Investigation
Practiced SQL queries involving:
- Filtering and sorting incidents by severity.
- JOIN operations between incidents and orders.
- Aggregations and COUNT functions.
- Calculating incident resolution time using TIMESTAMPDIFF.

## API Endpoints

| Method | Endpoint | Description |
|---|---|---|
| GET | /api/Orders | Retrieve all orders |
| GET | /api/Orders/{id} | Retrieve an order |
| POST | /api/Orders | Create an order |
| GET | /api/Incidents | Retrieve all incidents |
| GET | /api/Incidents/{id} | Retrieve an incident |
| POST | /api/Incidents | Create an incident |
| PUT | /api/Incidents/{id} | Update incident details |
| GET | /api/Reports/dashboard | Retrieve incident metrics |

## Running the Project Locally

### Prerequisites
- .NET 10 SDK
- MySQL Server
- Visual Studio Code (or another C# IDE)

### Setup

1. Clone this repository.
2. Open the `Support.API` project folder in your terminal.
3. Configure the MySQL connection string using .NET User Secrets:

```powershell
dotnet user-secrets init

dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=localhost;Port=3306;Database=EnterpriseSupportDB;User=root;Password=YOUR_PASSWORD;"
```

Replace `YOUR_PASSWORD` with your local MySQL password.

4. Apply database migrations:

```powershell
dotnet ef database update
```

5. Run the application:

```powershell
dotnet run
```

6. Open the Swagger URL displayed in the terminal to explore and test the API.

## Incident Root Cause Analysis

A simulated application failure was used to test centralized exception handling. The application logged technical exception details while returning a safe HTTP 500 response to the API client.

The investigation, root cause, resolution, and validation steps are documented in `docs/incident-rca.md`.

## Project Purpose

This is an independent learning and portfolio project developed to strengthen practical skills in C#/.NET application development, REST APIs, relational databases, SQL troubleshooting, and application support workflows.