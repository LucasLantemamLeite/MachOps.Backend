# 🏗️ MachOps.Backend

**MachOps.Backend** is a backend project built with .NET, focused on the management and control of **industrial and port machinery**. The system is designed with a modern and pragmatic architecture, applying principles like **DDD (Domain-Driven Design)**, **CQRS (Command Query Responsibility Segregation)**, and a smart dependency injection mechanism.

> This project is under active development as part of my professional portfolio. It was inspired by a system I previously implemented while working at the **Ponta do Felix** port terminal. That original solution was built using **Power BI**, but as it grew in complexity, the visualization became difficult to manage and misaligned. This project aims to rebuild that solution with a more structured, scalable, and maintainable backend approach.

---

## ⚙️ Technologies & Tools

- **.NET 8**
- **SQL Server**
- **Dapper** – Lightweight and high-performance data access.
- **Entity Framework Core** – Used only for managing database migrations.
- **CQRS** – Clear separation of responsibilities for reading and writing.
- **DDD** – Rich domain with a focus on business logic.
- **xUnit** + **FakeBaseInfra** – Complete and database-independent testing setup.
- **Smart Dependency Injection** – Custom mechanism to ensure required dependencies are properly injected.

---

## 🧠 BaseUseCase with Smart Dependency Control

The project includes a generic base class `BaseUseCase<TQuery, TRepository>` that centralizes usage logic and simplifies dependency injection in use cases. If a dependency is not required in a specific context, the special `IUnused` type can be used and the constructor will automatically ignore it. Otherwise, the class ensures required dependencies are injected — throwing descriptive exceptions to assist in development when something is missing.

---

## 🧪 Unit Testing with FakeBaseInfra

The project includes unit test coverage for:

- **Domain**
- **Queries**
- **Repositories**
- **UseCases**

Thanks to `FakeBaseInfra`, it simulates a database environment using **shared in-memory lists across test classes**, ensuring speed, predictability, and test isolation. The test code mirrors the production logic closely, with only the database swapped for an in-memory structure.

---

## 📌 Purpose

Build a robust and scalable backend for controlling and monitoring industrial and port machines, with a focus on:

- Clean architecture
- Modern development practices
- Testability and maintainability
- Rebuilding a real-world solution in a better structured and more efficient way
- Demonstrating technical skills in a professional portfolio

---

## 🚧 Status

> Actively under development – new features, tests, and structural improvements are continuously being added.
