# ForgeFolio

![C#](https://img.shields.io/badge/Language-C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET 9](https://img.shields.io/badge/.NET-9.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![MSSQL](https://img.shields.io/badge/Database-MSSQL-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)
![Bootstrap](https://img.shields.io/badge/Frontend-Bootstrap_5-7952B3?style=for-the-badge&logo=bootstrap&logoColor=white)
![License](https://img.shields.io/badge/License-MIT-yellow?style=for-the-badge)

> **Professional Portfolio Management System**  
> A comprehensive web application built with **ASP.NET Core 9.0 MVC**, featuring a modern responsive design, secure authentication system, and an integrated admin panel.

## 🚀 Key Features

*   **Secure Authentication**: Built-in Admin & User roles using ASP.NET Core Identity.
*   **Modern Architecture**: Clean N-Layer Architecture with Repository & Unit of Work patterns.
*   **Admin Dashboard**: Real-time statistics, message management, and CRUD operations.
*   **Responsive Portfolio**: Mobile-first design showcasing projects and experiences.
*   **Task Management**: Integrated To-Do list functionality for admin productivity.

## 🏗️ Architecture Overview

The project follows a clean, modular architecture:

```
ForgeFolio/
├── Core/                 # Entities, Interfaces, DTOs (Domain Layer)
├── Infrastructure/       # Data Access, Repositories, Services (Persistence Layer)
├── Web/                  # Controllers, Views, ViewComponents (Presentation Layer)
```

## 🛠️ Technology Stack

| Component | Technology | Description |
|-----------|------------|-------------|
| **Framework** | ASP.NET Core 9.0 | High-performance cross-platform framework |
| **Language** | C# 12 | Latest version of C# language |
| **Database** | MSSQL (LocalDB) | Robust relational database |
| **ORM** | Entity Framework Core 9.0 | Modern object-database mapper |
| **Frontend** | Bootstrap 5 + jQuery | Responsive UI components |
| **Logging** | Serilog | Structured logging library |

## ⚙️ Getting Started

### Prerequisites
- .NET 9.0 SDK
- SQL Server (LocalDB comes with Visual Studio)
- Visual Studio 2022

### Installation

1.  **Clone the repository**
    ```bash
    git clone https://github.com/anilakbay/ForgeFolio.git
    cd ForgeFolio
    ```

2.  **Configure Admin Credentials (Optional)**
    The system automatically creates a default admin user.
    *   **Email:** `admin@forgefolio.com`
    *   **Password:** `Admin123!`

3.  **Run the Application**
    ```bash
    dotnet run --project ForgeFolio
    ```
    *The database will be automatically created and seeded on the first run.*

## 🔒 Security

*   **Role-Based Access Control (RBAC)**: Admin-only areas are protected.
*   **Secure Storage**: Passwords are hashed using PBKDF2.
*   **Protection**: CSRF tokens and input validation implemented globally.

## 🤝 Contributing

1.  Fork the Project
2.  Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3.  Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4.  Push to the Branch (`git push origin feature/AmazingFeature`)
5.  Open a Pull Request

## 📄 License

Distributed under the MIT License. See `LICENSE` for more information.

## 📧 Contact

**Anıl Akbay** - Senior Software Engineer  
[LinkedIn](https://linkedin.com/in/anilakbay) | [GitHub](https://github.com/anilakbay)
