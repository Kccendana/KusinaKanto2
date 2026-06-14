# Overview

KusinaKanto2 is a web-based food ordering system built with Blazor Server, Entity Framework Core, and SQLite. The application is designed for a Filipino bakery and restaurant, allowing customers to browse menu items, place dine-in or takeout orders, manage their cart, and track order progress. The system provides a modern and responsive ordering experience while simplifying restaurant operations.

The purpose of this project was to deepen my understanding of full-stack web development using the .NET ecosystem. Through building this application, I gained experience working with Blazor components, state management, database design, Entity Framework Core, dependency injection, routing, and responsive user interface development.

## Running the Application

1. Clone the repository.
2. Open the project in Visual Studio 2022 or later.
3. Restore the NuGet packages.
4. Run the application using Visual Studio or the command:

```bash
dotnet run
```

5. Open the browser and navigate to:

```text
https://localhost:7156
```

or the URL displayed in the terminal.

## Software Demo Video

[Software Demo Video](http://youtube.link.goes.here)

# Web Pages

## Menu Page

The menu page displays available bakery and food items organized by category. Customers can browse products, view descriptions and prices, and add items to their cart. Menu items are dynamically loaded from the database.

## Shopping Cart

The cart page displays selected items, quantities, and the current order total. Customers can update quantities, remove items, and proceed to checkout. Cart contents are managed through a shared state service.

## Checkout Page

Customers provide order information and choose either dine-in or takeout service. The system validates the order and saves it to the database.

## Order Confirmation Page

After submitting an order, customers receive a confirmation page showing the order details and next steps.

## Order History Page

Dine-in customers can view active orders associated with their table number. The page displays ordered items, quantities, statuses, and the overall total. Customers may continue ordering or request checkout when they are ready to pay.

## Thank You Page

When dine-in customers request checkout, they are redirected to a thank-you page confirming that payment assistance has been requested. A cashier can then process the payment.

## Cashier View

The cashier view displays orders that have requested checkout and are ready for payment processing. Cashiers can review order totals and update payment status.

# Development Environment

## Tools Used

* Visual Studio 2022
* Git and GitHub
* SQLite
* Entity Framework Core Tools

## Languages and Frameworks

* C#
* Razor Components
* HTML
* CSS
* Blazor Server
* ASP.NET Core
* Entity Framework Core
* SQLite

# Useful Websites

* https://learn.microsoft.com/en-us/aspnet/core/blazor/
* https://learn.microsoft.com/en-us/ef/core/
* https://learn.microsoft.com/en-us/dotnet/csharp/
* https://sqlite.org/docs.html
* https://tailwindcss.com/docs
* https://stackoverflow.com

# Future Work

* Implement kitchen and cashier dashboards with real-time updates.
* Add QR code ordering and payment support.
* Add customer order tracking for takeout orders.
* Implement role-based authentication and authorization.
* Add sales reporting and analytics features.
* Improve mobile responsiveness and accessibility.
* Integrate online payment options.
