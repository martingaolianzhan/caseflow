# Current Delivery Target

**Design baseline:** v0.4-draft

## Current Level

Level 1 — MVP / Employable Version

## Current Stage

Stage 1.1 — Solution Foundation

## Current Milestone

Project foundation assessment.

## Current Objective

Inspect the existing CaseFlow repository and determine which Stage 1.1 foundation requirements already exist and which remain incomplete under the v0.4 technical baseline.

## Approved Work

For this milestone, inspect and report only.

### Repository and Toolchain

- repository structure;
- Node/package-manager configuration;
- .NET SDK/project configuration;
- version pinning where present;
- environment/configuration strategy.

### Frontend

Verify whether the repository has:

- Next.js;
- React;
- TypeScript;
- App Router;
- basic frontend structure;
- build/type-check/lint capability;
- baseline frontend test capability.

### Backend

Verify whether the repository has:

- ASP.NET Core Web API;
- controller-based endpoint structure;
- REST-style API conventions;
- clear API/Application/Domain/Infrastructure separation or an equivalent justified structure;
- OpenAPI development documentation;
- baseline backend testing setup.

### Persistence

Verify whether the repository has:

- Entity Framework Core;
- PostgreSQL configuration;
- EF Core migrations;
- clear persistence/infrastructure boundaries.

### Docker / Local Runtime

Verify whether the repository has:

- Docker Compose;
- PostgreSQL development container;
- reproducible local database startup;
- documented frontend/backend/database development startup.

### Architectural Consistency

Identify:

- conflicts with `ARCHITECTURE.md`;
- unnecessary abstraction layers;
- generic Repository wrappers that merely duplicate EF Core without demonstrated value;
- accidental Next.js backend/database paths;
- premature infrastructure;
- other Stage 1.1 risks.

## Not Approved Yet

Do not perform broad implementation during this assessment.

In particular, do not begin:

- detailed tenant/role implementation;
- authentication implementation;
- Case workflow implementation;
- SLA implementation;
- approval workflows;
- Service Provider / Work Order implementation;
- marketplace behaviour;
- notifications;
- advanced infrastructure;
- full-stack containerisation unless separately approved.

## Expected Output

Produce:

1. existing Stage 1.1 foundation inventory;
2. missing Stage 1.1 requirements;
3. conflicts between current code and the v0.4 architecture;
4. architectural or developer-experience risks;
5. unnecessary complexity already present, if any;
6. recommended smallest next milestone;
7. files likely affected by that milestone.

Do not perform broad implementation until the assessment is reviewed.
