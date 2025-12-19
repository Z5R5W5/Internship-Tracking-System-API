# 🎓 Internship Tracking System

A comprehensive **Internship Tracking System** built using **ASP.NET Core Web API**, following **Clean Architecture**, **CQRS**, and **MediatR** patterns.  
The system helps universities manage students, internship offers, applications, supervisors, evaluations, and reports efficiently.

---

## 🚀 Features

- 👨‍🎓 Student management
- 🏢 Company & Internship Offers management
- 📝 Internship Applications tracking
- 👨‍🏫 Supervisors & Evaluations
- 📄 Internship Reports (Weekly / Final)
- ✅ FluentValidation with MediatR Pipeline
- 🧠 Clean Architecture (API / Application / Infrastructure)
- 📦 Entity Framework Core (Code First)
- 🔁 CQRS with MediatR
- 🛡 Global Exception Handling Middleware
- 📊 Swagger API Documentation

---

## 🧱 Architecture

The project follows **Clean Architecture** principles:

Internship.Tracking
│
├── Internship.Tracking.Api → Presentation Layer (Controllers, Middleware)
├── Internship.Application → Application Layer (CQRS, MediatR, Validation)
├── Internship.Infrastructure → Infrastructure Layer (EF Core, DbContext)
└── Internship.Domain → Domain Layer (Entities, Value Objects)


---

## 🛠️ Technologies Used

- **.NET 9**
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **SQL Server**
- **MediatR**
- **CQRS Pattern**
- **Result Pattern (Consistent API Responses)**
- **FluentValidation**
- **Swagger / OpenAPI**
- **ILogger**

---

## 🗄️ Database Schema

Main entities:
- Students
- Companies
- InternshipOffers
- Applications
- Supervisors
- Evaluations
- Reports
