# CaseFlow Architecture

**Design baseline:** v0.4-draft

## 1. Architecture Goal

CaseFlow uses a straightforward modular-monolithic web architecture suitable for a realistic enterprise workflow system.

The architecture should prioritise:

- clear business logic;
- maintainability;
- tenant isolation;
- testability;
- reproducible local development;
- straightforward deployment;
- explainable engineering decisions.

Avoid complexity that is not justified by current requirements.

---

## 2. System Overview

CaseFlow consists of:

### Frontend

- Next.js;
- React;
- TypeScript;
- App Router.

### Backend

- ASP.NET Core Web API;
- controller-based endpoints;
- REST-style HTTP/JSON API.

### Persistence

- Entity Framework Core;
- PostgreSQL.

### Development Infrastructure

- Docker Compose;
- PostgreSQL runs in a development container from Stage 1.1.

The application code is developed and run locally by default during early development for simpler hot reload and debugging.

High-level structure:

```text
Next.js + React + TypeScript
App Router
        |
        | REST-style HTTP / JSON
        v
ASP.NET Core Web API
Controllers
        |
        v
Application Layer
        |
        v
Domain Model
        |
        v
Infrastructure / Entity Framework Core
        |
        v
PostgreSQL
(Docker Compose in local development)
```

The approved technical stack is a project constraint. Frameworks, databases, API styles, or infrastructure must not be substituted without explicit review.

---

## 3. Architectural Style

CaseFlow is a **modular monolith**.

Modules should be separated by clear business responsibility while remaining part of one deployable backend application unless a demonstrated future requirement justifies separation.

Possible business areas include:

- Identity and Access;
- Tenancy / Customer Organisations;
- Cases;
- Workflow;
- SLA;
- Audit;
- Reporting;
- optional Service Delivery extensions.

A modular monolith does not mean putting all logic into one project or one class. It means maintaining clear module and layer boundaries without introducing distributed-system complexity prematurely.

Do not introduce microservices merely to imitate large-enterprise architecture.

---

## 4. Frontend Architecture

The frontend uses **Next.js + React + TypeScript with the App Router**.

The frontend is responsible for:

- presentation;
- routing and navigation;
- rendering;
- forms and user interaction;
- UI state;
- calling CaseFlow backend APIs;
- client-side validation for usability;
- appropriate use of Next.js rendering features.

The frontend is **not** the source of truth for:

- authorization;
- tenant isolation;
- workflow rules;
- SLA rules;
- audit behaviour;
- persistence.

Next.js must not become a second business backend.

Do not introduce a parallel persistence path through Next.js Route Handlers, Server Actions, Prisma, or direct database access for CaseFlow core business operations unless explicitly approved.

Core business operations must flow through the ASP.NET Core backend.

---

## 5. Backend Structure

The backend should use clear separation between four responsibilities:

### API Layer

The API layer receives HTTP requests and produces HTTP responses.

It is responsible for:

- routing;
- controllers;
- request binding;
- invoking application use cases;
- translating results/errors into HTTP responses.

Controllers should remain thin.

They should not contain large amounts of business logic, persistence logic, or tenant/authorization rules.

### Application Layer

The Application layer coordinates a business use case.

Examples:

- CreateCase;
- AssignCase;
- ChangeCaseStatus;
- CloseCase.

It may:

- load required data;
- invoke authorization;
- coordinate domain behaviour;
- persist changes;
- trigger required audit behaviour.

The Application layer coordinates the operation; it should not invent domain rules that belong to the Domain layer.

### Domain Layer

The Domain layer represents the business model itself.

It contains business concepts such as:

- Tenant / Customer Organisation;
- Case;
- Assignment;
- workflow state;
- SLA;
- Approval;

and the rules/invariants that govern them.

The Domain Model is **not simply the database schema**.

For example, the domain may define that:

- a Case belongs to exactly one Tenant;
- an invalid workflow transition must be rejected;
- an assignment must respect approved business rules.

How those concepts are stored in PostgreSQL is an infrastructure concern.

### Infrastructure Layer

The Infrastructure layer implements technical interaction with external systems and persistence.

Current infrastructure includes:

- Entity Framework Core;
- PostgreSQL.

Future explicitly approved infrastructure could include:

- email delivery;
- file/object storage;
- external APIs.

The Domain layer should not depend directly on infrastructure implementation details.

---

## 6. Domain Core vs Extensions

The architectural core is centred on:

- Tenant / Customer Organisation;
- User/access context;
- Site/service context where applicable;
- Case;
- Assignment;
- Workflow;
- SLA;
- Approval;
- Audit.

Optional vertical or service-delivery modules may add concepts such as:

- Service Provider;
- Work Order;
- Quote;
- completion evidence.

Optional modules may depend on the Case core.

The Case core must not require those modules for every workflow.

---

## 7. Persistence

Entity Framework Core is the approved ORM.

PostgreSQL is the approved primary relational database.

EF Core migrations are the approved mechanism for evolving the application database schema.

Database access must preserve:

- tenant isolation;
- referential integrity;
- business-data integrity.

### Repository Abstractions

Do not add a generic Repository layer that merely forwards CRUD operations to Entity Framework Core.

For example, avoid introducing abstractions such as:

```text
IRepository<T>
    -> Add
    -> Update
    -> Delete
    -> GetById
```

when the implementation only forwards those calls to `DbContext`.

Repository abstractions may be introduced when they provide a concrete domain or persistence boundary, such as encapsulating meaningful aggregate-loading or persistence behaviour.

Repository pattern usage is therefore **not forbidden**; unnecessary wrapper abstraction is.

---

## 8. Local Development and Docker

Docker is part of the development architecture from Level 1 / Stage 1.1.

### Stage 1.1 baseline

Run application code locally:

```text
Next.js development server
ASP.NET Core development server
```

Run infrastructure through Docker Compose:

```text
PostgreSQL
```

This provides a reproducible database environment without requiring PostgreSQL to be installed directly on the developer machine.

### Later evolution

Full-stack containerisation of:

- frontend;
- backend;
- database;

may be introduced later if it provides clear development, deployment, or CI value.

Do not add containers merely for appearance or architectural complexity.

---

## 9. API Design

The ASP.NET Core backend exposes a **controller-based REST-style HTTP API**.

"REST-style" means the API should use clear resource-oriented HTTP conventions without introducing complexity solely to satisfy strict REST theory.

The API should use:

- resource-oriented URLs;
- standard HTTP methods;
- JSON request and response bodies;
- appropriate HTTP status codes;
- explicit request/response DTOs;
- consistent validation/error responses;
- OpenAPI documentation.

Example resource-oriented endpoints:

```text
GET    /api/cases
GET    /api/cases/{id}
POST   /api/cases
PATCH  /api/cases/{id}
```

Workflow-specific operations may use subordinate resources or clear action endpoints when that better represents the business operation, for example:

```text
POST /api/cases/{id}/assignments
POST /api/cases/{id}/approvals
```

Do not expose Entity Framework persistence entities directly as public API contracts.

API contracts should remain explicit and stable enough to separate frontend needs from persistence implementation.

Use meaningful HTTP status codes such as:

- `200 OK`;
- `201 Created`;
- `204 No Content`;
- `400 Bad Request`;
- `401 Unauthorized`;
- `403 Forbidden`;
- `404 Not Found`;
- `409 Conflict`;

as appropriate to the operation.

Use a consistent structured error representation based on ASP.NET Core Problem Details or an explicitly approved equivalent.

OpenAPI should be available during development for API inspection and documentation.

---

## 10. Authentication and Authorization Boundary

Authentication and authorization are backend responsibilities.

The exact authentication mechanism is intentionally not fixed in v0.4.

Before Stage 1.2 implementation, explicitly decide the authentication approach, including whether CaseFlow uses ASP.NET Core Identity, cookie-based authentication, JWT bearer authentication, or another approved mechanism.

Authorization behaviour is defined in `AUTHORIZATION.md`.

The frontend must never be treated as the enforcement point for security rules.

---

## 11. Testing Architecture

Automated testing is required, but tests should focus on meaningful behaviour rather than raw test count.

At minimum, the project architecture must support:

- backend unit tests;
- backend integration tests;
- frontend component/behaviour tests;
- authorization and cross-tenant tests.

The exact frontend and end-to-end testing toolchain may be refined during Stage 1.1 rather than introducing tools before they are needed.

Backend testing should use the standard .NET test ecosystem unless a concrete requirement justifies otherwise.

End-to-end browser testing may be introduced later when the Level 1 vertical workflow exists.

---

## 12. Cross-cutting Requirements

The architecture must support:

- tenant isolation;
- role/resource authorization;
- validation;
- auditability;
- predictable error handling;
- automated testing;
- reproducible local development;
- clear API contracts.

---

## 13. Current Architectural Boundaries

Not part of the current architecture unless explicitly approved:

- microservices;
- event sourcing;
- CQRS;
- message brokers;
- Kubernetes;
- distributed caching;
- Redis;
- speculative cloud-specific infrastructure;
- marketplace infrastructure;
- recommendation engines;
- parallel Next.js business APIs;
- generic abstraction layers without demonstrated value.

---

## 14. Versioning and Toolchain Configuration

Architecture documents define the approved technologies, not every patch version.

Exact runtime/tool versions should be pinned in repository configuration where appropriate, for example:

- `package.json` / package manager lockfile;
- Node version configuration;
- `.NET` SDK configuration such as `global.json` where justified;
- Docker image tags;
- project files.

Version changes that materially alter architecture or compatibility should be reviewed.

---

## 15. Evolution Rule

Future commercial requirements may justify additional modules or architectural changes.

Do not introduce architecture solely for hypothetical future scalability or verticalisation.

Any material architecture change must be explicitly reviewed before implementation.
