Software Design Document (SDD)
 
<h2>Savr - Personal Finance Tracker - .Net Core 9 / Blazor / MudBlazor / EF Core / REST API </h2>
Version: 1.0

Date: 22.05.2025
Author: Sameera Dayananda
Personal Finance Tracker

Revision History
Date	Version	Description	Author
22.05.2025	
0.1	Initial Documentation	
Sameera Dayananda
			
1. Introduction
1.1 Purpose
This document outlines the software design for Savr, a minimalist personal finance tracker application. The purpose of this document is to provide a clear architectural and design roadmap for building an intuitive and efficient platform that enables users to manage their income, expenses, and savings effortlessly. By prioritizing simplicity, usability, and performance, Savr aims to empower individuals to take control of their finances with confidence and clarity.

1.2 Scope
Savr provides users with a streamlined platform to input income and expenses, categorize financial activities, and gain a clear overview of their financial health. The app enables users to set and monitor savings goals, track spending patterns over time, and visualize trends through intuitive dashboards. With a focus on minimalism and ease of use, Savr is designed to make personal finance management accessible and stress-free.

5. Architecture & Technologies
Architecture Overview

Savr is built following the principles of Clean Architecture, ensuring a clear separation of concerns across the layers. It keeps the core business or application logic use cases independent of frontend and external frameworks. . This architecture promotes maintainability, testability, and scalability by organizing the codebase into well-defined layers:
Independent of UI: presentation layers could change easily without altering the application layer and so on. UI can be from any front-end framework, or console UI, any web, and can be replaced without changing the other layers or rest of the system.
Database Independent: The architecture should be flexible enough to swap the database without affecting the application use cases and entities. 
Independent of External agency/libraries/Drivers: The business rules should be independent of external parties or agencies.
Framework Independent: The core business or application rules should be independent upon the existence of frameworks, libraries.s for the future.
Testable: The architecture complies with the testing of the core application and business cases and rules without the UI, database, Web server, or any external component.

Solution Structure  <br>
Project solution architecture is properly adhearing with the Clean Architecture concepts. <br>
 
5.1 Tech Stack
<h2>Technology Stack</h2>  <br>
The Savr personal finance tracker app is built using a modern full-stack approach to ensure performance, scalability, and maintainability.  <br>
• Frontend: .Net Core 9.0 + Blazor Server Pages with MudBlazer UI Components  <br>
• Backend: .Net Core 9.0  <br>
• ORM: Entity Framework Core  <br>
• Database: Microsoft SQL Server  <br>

<h2>Project Setup Guide</h2>

1). Colne the source code into your local development environment. <br>
2). Create a database named 'SavrDevDB' using MSSMS. <br>
3). Open Savr.API project and navigate to appsettings.Development.json file. Makesure the sql server instance and database names are matching. <br>
4). Run the migration using the folowing comands. Use Package Manager Console. and change the eunning project as Savr.Infrastructure before run the following <br>
     
      Add-Migration Initial -StartupProject Savr.Api <br>
      Update-Database -StartupProject Savr.Api <br>

5). Go to Set multiple startup projects and set Savr.API and Savr.Client as starting projects. <br>
6). Move to Savr.Client which is the blazor web client, change the Rest endpoint URL accordingly. <br>
7). Run the project.  <br>
