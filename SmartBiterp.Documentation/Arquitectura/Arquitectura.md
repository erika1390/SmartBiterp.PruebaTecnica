
📘 Documentación de Arquitectura Empresarial – SmartBiterp

0. 🗂️ Estructura de la Solución y Propósito de Cada Proyecto

La solución SmartBiterp está compuesta por los siguientes proyectos principales:

- **SmartBiterp.Domain**  
  Define las entidades del dominio, enums y las reglas de negocio centrales. No tiene dependencias de infraestructura ni de frameworks externos.

- **SmartBiterp.Application**  
  Contiene los servicios de aplicación, casos de uso y lógica de orquestación. Depende del dominio y define interfaces para la infraestructura.

- **SmartBiterp.Infrastructure**  
  Implementa la persistencia de datos (repositorios, DbContext), acceso a base de datos y cualquier integración técnica. Satisface las interfaces definidas en Application.

- **SmartBiterp.Api**  
  Proyecto ASP.NET Core que expone la API REST. Orquesta la interacción entre Application e Infrastructure y expone los endpoints HTTP.

- **SmartBiterp.Documentation**  
  Contiene la documentación técnica y de arquitectura del sistema, incluyendo diagramas, descripciones y manuales.

Cada proyecto cumple una función específica y respeta la separación de responsabilidades, facilitando el mantenimiento, la escalabilidad y las pruebas.

0.1 🗂️ Estructura Interna de Proyectos y Carpetas

### SmartBiterp.Domain
- **Entities\\**  
  Entidades del dominio (por ejemplo: `ExpenseType`, `Budget`, `User`, etc.).
- **Enums\\**  
  Enumeraciones usadas en el dominio (por ejemplo: `ExpenseCategoryType`).
- **ValueObjects\\**  
  Objetos de valor y tipos inmutables del dominio.
- **(Otros)**  
  Agregados, interfaces de dominio, lógica de negocio pura.

### SmartBiterp.Application
- **Services\\**  
  Servicios de aplicación y casos de uso (por ejemplo: `ExpenseTypeService`, `BudgetService`).
- **DTOs\\**  
  Objetos de transferencia de datos entre capas.
- **Interfaces\\**  
  Contratos para servicios y repositorios que implementará la infraestructura.

### SmartBiterp.Infraestructura
- **Repositories\\**  
  Implementaciones concretas de los repositorios (por ejemplo: `ExpenseTypeRepository`).
- **Persistence\\**  
  Contexto de base de datos (`AppDbContext`), migraciones y configuraciones de EF Core.
- **Migrations\\**  
  Archivos de migración de la base de datos.
- **ExternalServices\\**  
  (Si existieran) Integraciones técnicas con servicios externos.
- **Configurations\\**  
  Configuraciones de entidades para EF Core.

### SmartBiterp.Api
- **Controllers\\**  
  Controladores que exponen los endpoints REST (por ejemplo: `ExpenseController`).
- **Models\\**  
  Modelos de request/response para la API.
- **Middlewares\\**  
  Middleware para manejo de errores, logging, etc.
- **Program.cs / Startup.cs**  
  Configuración de la aplicación y servicios.

### SmartBiterp.Documentation
- **Arquitectura\\**  
  Documentación de arquitectura, diagramas y descripciones técnicas.
- **Backend\\**  
  Documentos sobre la lógica y estructura del backend.
- **BaseDatos\\**  
  Esquemas, scripts y documentación de la base de datos.
- **Pruebas\\**  
  Documentación y ejemplos de pruebas.

---

Cada carpeta está orientada a una responsabilidad clara, facilitando la mantenibilidad, escalabilidad y comprensión del sistema.  
Esta estructura sigue las mejores prácticas de proyectos empresariales en .NET.


1. 🧩 Arquitectura Lógica

SmartBiterp implementa una arquitectura en capas diseñada para garantizar:

Escalabilidad

Mantenibilidad

Separación clara de responsabilidades

Facilidad de pruebas

Capas principales:

Domain
Contiene entidades, reglas de negocio y agregados.

Application
Orquesta casos de uso, lógica de aplicación y servicios.

Infrastructure
Persistencia, repositorios, servicios externos.

API
Expone endpoints REST usando .NET.

2. 🏛️ Arquitectura Física

La arquitectura física se basa en una infraestructura moderna y modular:

Cliente (Web/Angular)

API (.NET 9)

Base de Datos SQL Server

Servicios externos (APIs, colas, storage, etc.)

:::mermaid
graph TD
    Cliente["🖥️ Cliente Web/Móvil"]
    API["🔌 API REST (.NET 9)"]
    DB["🗄️ Base de Datos SQL Server"]
    Ext["☁️ Servicios Externos (APIs, Mensajería)"]

    Cliente --> API
    API --> DB
    API --> Ext
:::
3. 🧱 Diagrama de Componentes
:::mermaid
graph TD
    API["ExpenseController"]
    AppService["ExpenseTypeService / BudgetService"]
    Domain["Entidades y lógica de dominio"]
    Repo["ExpenseTypeRepository"]
    Infra["Infraestructura (DB, Integraciones)"]

    API --> AppService
    AppService --> Domain
    AppService --> Repo
    Repo --> Infra
:::
4. 🗂️ Estructura de Capas
:::mermaid
graph TD
    A["API"]
    B["Application"]
    C["Domain"]
    D["Infrastructure"]

    A --> B
    B --> C
    B --> D
    D --> C
:::
5. 🧠 Patrones Utilizados
✔ Repository

Abstrae la capa de acceso a datos.

✔ Unit of Work

Garantiza atomicidad en transacciones.

✔ CQRS

Divide comandos (escrituras) y consultas (lecturas).

✔ Domain-Driven Design (DDD)

Modelo orientado al dominio y sus reglas.

✔ Dependency Injection

Para desacople total y pruebas fáciles.

6. 🗃️ Modelo de Datos (ERD)
:::mermaid
erDiagram
    ExpenseType {
        int Id
        string Code
        string Description
        ExpenseCategoryType Category
        DateTime CreatedAt
        DateTime UpdatedAt
    }
    Budget {
        int Id
        int ExpenseTypeId
        int Year
        int Month
        decimal AllocatedAmount
        BudgetStatusType Status
        DateTime CreatedAt
        DateTime UpdatedAt
    }
    MoneyFund {
        int Id
        string Code
        string Name
        MoneyFundType FundType
        decimal InitialBalance
        decimal CurrentBalance
        DateTime CreatedAt
        DateTime UpdatedAt
    }
    ExpenseHeader {
        int Id
        DateTime Date
        int MoneyFundId
        string StoreName
        DocumentType DocumentType
        string Notes
        DateTime CreatedAt
        DateTime UpdatedAt
    }
    ExpenseDetail {
        int Id
        int ExpenseHeaderId
        int ExpenseTypeId
        decimal Amount
        DateTime CreatedAt
        DateTime UpdatedAt
    }
    Deposit {
        int Id
        DateTime Date
        int MoneyFundId
        decimal Amount
        DateTime CreatedAt
        DateTime UpdatedAt
    }
    User {
        int Id
        string Username
        string Email
        int RoleId
        DateTime CreatedAt
        DateTime UpdatedAt
    }
    Role {
        int Id
        RoleType RoleType
        DateTime CreatedAt
        DateTime UpdatedAt
    }
    Permission {
        int Id
        string Code
        string Description
        DateTime CreatedAt
    }
    Menu {
        int Id
        string Title
        string Route
        string Icon
        int ParentId
        DateTime CreatedAt
        DateTime UpdatedAt
    }
    RolePermission {
        int Id
        int RoleId
        int PermissionId
        DateTime AssignedAt
        string AssignedBy
        DateTime CreatedAt
    }
    MenuRole {
        int Id
        int MenuId
        int RoleId
        DateTime CreatedAt
    }
    AuditLog {
        int Id
        string Action
        string Entity
        int EntityId
        string PerformedBy
        DateTime PerformedAt
    }

    ExpenseType ||--o{ Budget : "asigna"
    ExpenseType ||--o{ ExpenseDetail : "usa"
    Budget }o--|| ExpenseType : "por tipo"
    MoneyFund ||--o{ ExpenseHeader : "financia"
    MoneyFund ||--o{ Deposit : "recibe"
    ExpenseHeader ||--o{ ExpenseDetail : "detalle"
    ExpenseDetail }o--|| ExpenseHeader : "pertenece"
    ExpenseDetail }o--|| ExpenseType : "clasifica"
    User }o--|| Role : "tiene"
    Role ||--o{ RolePermission : "asigna"
    Permission ||--o{ RolePermission : "otorga"
    Role ||--o{ MenuRole : "acceso"
    Menu ||--o{ MenuRole : "acceso"
    Menu ||--o{ Menu : "hijos"
:::
7. 🔄 Flujos Principales de Negocio
📝 Flujo: Registro de un Gasto

Descripción del flujo:

Usuario envía un POST /expense.

El controlador recibe y valida los datos.

El servicio de aplicación ejecuta el caso de uso.

El repositorio persiste la información.

La API devuelve respuesta exitosa.

Diagrama de Secuencia
:::mermaid
sequenceDiagram
    participant U as Usuario
    participant C as ExpenseController
    participant S as ExpenseTypeService
    participant R as ExpenseTypeRepository

    U->>C: POST /expense
    C->>S: Validar y procesar gasto
    S->>R: Guardar gasto
    R-->>S: Confirmación
    S-->>C: Resultado
    C-->>U: Respuesta exitosa
:::
8. 🔐 Seguridad

Actualmente, SmartBiterp **no implementa autenticación JWT ni OAuth2**. El acceso a la API no está protegido por mecanismos de autenticación o autorización basados en tokens. Se recomienda implementar autenticación y autorización en futuras versiones para proteger los recursos y datos sensibles.

:::mermaid
flowchart TD
    User["Usuario"]
    API["API sin autenticación"]
    Recursos["Recursos/Endpoints"]

    User --> API
    API --> Recursos
:::
9. 🛠️ Errores, Excepciones, Logging y Auditoría

- Manejo global de errores con middleware.
- Logging estructurado implementado con Serilog.
- Auditoría de eventos críticos: creación, actualización, eliminación, acceso restringido.
- **Nota:** Aunque existen entidades de roles y permisos en el modelo de datos, actualmente **no se controla el acceso a las APIs por rol o permiso**. Todos los endpoints están abiertos y no hay validación de autorización en la capa de API.

10. 🌐 Integración con Servicios Externos

Actualmente, SmartBiterp **no realiza integraciones con servicios externos** (APIs, mensajería, almacenamiento externo, etc.).  
Todas las operaciones y lógica de negocio se ejecutan de forma interna dentro de la aplicación y su base de datos.

> Se recomienda documentar e implementar integraciones externas en futuras versiones si el negocio lo requiere.

11. 🚀 CI/CD, Versionamiento y Despliegue

- **Versionamiento:** El control de versiones se realiza con Git.
- **Repositorio:** El código fuente se gestiona en un repositorio Git (GitHub).
- **CI/CD:** Actualmente, **no se ha configurado ningún pipeline de integración continua ni despliegue automático** (Azure DevOps o similar).
- **Despliegue:** El despliegue se realiza de forma manual.
- **Recomendación:** Se sugiere implementar pipelines en Azure DevOps para automatizar build, pruebas, análisis de código y despliegue en futuras versiones.