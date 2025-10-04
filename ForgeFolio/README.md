# ForgeFolio

> **Professional Portfolio Management System**  
> A comprehensive web application built with ASP.NET Core 9.0 MVC, featuring a modern responsive design and integrated admin panel for content management.

## Screenshot

![ForgeFolio Dashboard](./portfolyo.png)

## Architecture Overview

This project implements a clean architecture pattern with clear separation of concerns:

```
ForgeFolio/
├── Controllers/          # MVC Controllers (Presentation Layer)
├── DAL/                  # Data Access Layer
│   ├── Context/         # Entity Framework DbContext
│   └── Entities/        # Domain Models
├── ViewComponents/       # Reusable UI Components
├── Views/               # Razor Views
└── wwwroot/             # Static Assets
```

## Core Features

### Frontend
- **Responsive Design**: Mobile-first approach with Bootstrap 5
- **Portfolio Showcase**: Dynamic project display with filtering
- **Contact Integration**: Real-time message handling
- **Performance Optimized**: Lazy loading and efficient asset management

### Admin Panel
- **Dashboard Analytics**: Real-time statistics and insights
- **Content Management**: CRUD operations for all entities
- **Message Center**: Integrated communication system
- **Task Management**: Built-in todo list functionality

## Technology Stack

| Component | Technology | Version |
|-----------|------------|---------|
| **Backend** | ASP.NET Core MVC | 9.0 |
| **Database** | Entity Framework Core | 9.0.9 |
| **Database Engine** | SQL Server | Latest |
| **Frontend** | Bootstrap, jQuery | 5.x, 3.x |
| **Icons** | Font Awesome | 6.0 |
| **Architecture** | MVC Pattern, DI | - |

## Prerequisites

- .NET 9.0 SDK
- SQL Server (LocalDB or Full Instance)
- Visual Studio 2022 or VS Code

## Installation & Setup

### 1. Clone Repository
```bash
git clone https://github.com/anilakbay/ForgeFolio.git
cd ForgeFolio
```

### 2. Restore Dependencies
```bash
dotnet restore
```

### 3. Database Configuration
Update connection string in `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=ForgeFolioDB;Trusted_Connection=true;"
  }
}
```

### 4. Database Migration
```bash
dotnet ef database update
```

### 5. Launch Application
```bash
dotnet run
```

## Application Endpoints

| Service | URL | Description |
|---------|-----|-------------|
| **Frontend** | `/Default/Index` | Main portfolio page |
| **Admin Panel** | `/Layout/Index` | Management dashboard |
| **API** | `/api/*` | RESTful endpoints |

## Development Guidelines

### Code Standards
- Follow C# naming conventions
- Implement proper error handling
- Use dependency injection throughout
- Maintain clean architecture principles

### Database Design
- Entity relationships properly defined
- Indexed columns for performance
- Foreign key constraints enforced
- Migration strategy implemented

## Performance Considerations

- **Caching**: Implemented for frequently accessed data
- **Lazy Loading**: Entity Framework optimization
- **Asset Optimization**: Minified CSS/JS files
- **Database Indexing**: Optimized query performance

## Security Features

- **Input Validation**: Model validation attributes
- **SQL Injection Protection**: Parameterized queries
- **XSS Prevention**: HTML encoding
- **CSRF Protection**: Anti-forgery tokens

## Contributing

This project follows standard development practices:
- Feature branches for new development
- Code reviews for quality assurance
- Automated testing where applicable
- Documentation updates with changes

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Contact

**Anıl Akbay** - Senior Software Engineer  
- **Email**: anilakbay20@gmail.com  
- **Phone**: +90 546 593 80 36  
- **GitHub**: [@anilakbay](https://github.com/anilakbay)  
- **LinkedIn**: [Anıl Akbay](https://linkedin.com/in/anilakbay)  
- **Repository**: [ForgeFolio](https://github.com/anilakbay/ForgeFolio)

---

*Built with ❤️ using ASP.NET Core 9.0*
