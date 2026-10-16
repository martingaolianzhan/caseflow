# CaseFlow

CaseFlow is an early-stage case and workflow management project built with **Next.js, ASP.NET Core and PostgreSQL**. The project is designed around multi-tenant workflow concepts such as cases, assignment, authorization, SLA and auditability.

**Current stage:** Stage 1.1 — Solution Foundation.  
**Current milestone:** Foundation Integration & Closure (`1.1D`).

The repository currently focuses on establishing and verifying the full-stack development foundation. Case management, tenant authorization, workflow, SLA and audit behaviour are planned product capabilities and are **not yet implemented application features**.

## What exists today

The current repository includes:

- a **Next.js / React / TypeScript** frontend foundation with App Router and baseline Vitest coverage;
- a layered **ASP.NET Core Web API** solution with API, Application, Domain and Infrastructure projects;
- a controller-based health endpoint and development OpenAPI output;
- **Entity Framework Core / PostgreSQL** persistence configuration;
- a reproducible PostgreSQL development container through **Docker Compose**;
- baseline frontend and backend verification commands using Vitest and xUnit.

The current `1.1D` milestone is verifying that these pieces work together as a stable and reproducible development baseline before business functionality is introduced.

## Engineering approach

CaseFlow uses a straightforward **modular-monolith** architecture. The Next.js application is responsible for presentation and interaction, while core business operations are intended to flow through the ASP.NET Core REST API rather than creating a second business backend inside Next.js.

The detailed technical boundaries and design decisions are documented in [`docs/architecture/ARCHITECTURE.md`](./docs/architecture/ARCHITECTURE.md).

Development is structured for AI-assisted implementation. [`AGENTS.md`](./AGENTS.md) defines the repository context, instruction priority, scope boundaries, validation expectations and decisions that must be surfaced for human review. The active delivery boundary is maintained separately in [`docs/delivery/CURRENT.md`](./docs/delivery/CURRENT.md).

In practice, I use tools including **Pi and Codex CLI** for scoped investigation, implementation and review. AI-assisted changes remain constrained by the repository's approved architecture and delivery scope and are reviewed and verified before acceptance.

## Development setup

### Prerequisites

- Node.js 24 (`.nvmrc`) and npm 11
- .NET SDK 10.0.300 (`global.json`)
- Docker with Docker Compose

### Start local development

1. Start PostgreSQL:

   ```bash
   docker compose up -d postgres
   docker compose ps
   ```

2. Restore local .NET tools and start the backend at `http://localhost:5015`:

   ```bash
   dotnet tool restore
   dotnet run --project backend/src/CaseFlow.Api
   ```

   In development:

   - OpenAPI: `http://localhost:5015/openapi/v1.json`
   - Health: `http://localhost:5015/api/health`

3. In another terminal, install dependencies and start the frontend at `http://localhost:3000`:

   ```bash
   cd frontend
   npm ci
   npm run dev
   ```

Stop PostgreSQL with:

```bash
docker compose down
```

Add `-v` only when the local database data may be discarded.

## Verification

Frontend, from `frontend/`:

```bash
npm run lint
npm test
npm run typecheck
npm run build
```

Backend, from the repository root:

```bash
dotnet restore backend/CaseFlow.sln
dotnet build backend/CaseFlow.sln --no-restore
dotnet test backend/CaseFlow.sln --no-build
```

Current automated tests are **baseline checks for frontend rendering and the backend xUnit test runner**. Business behaviour, frontend-to-backend integration and database integration are not yet covered by those tests.

## Current scope

The active milestone is focused on integrating and verifying the Stage 1.1 development foundation.

See [`docs/delivery/CURRENT.md`](./docs/delivery/CURRENT.md) for the active delivery target and [`docs/architecture/ARCHITECTURE.md`](./docs/architecture/ARCHITECTURE.md) for the technical architecture.
