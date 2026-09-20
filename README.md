# CaseFlow

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

   In development, OpenAPI is available at `http://localhost:5015/openapi/v1.json` and the health endpoint is `http://localhost:5015/api/health`.

3. In another terminal, install dependencies and start the frontend at `http://localhost:3000`:

   ```bash
   cd frontend
   npm ci
   npm run dev
   ```

Stop PostgreSQL with `docker compose down`. Add `-v` only when the local database data may be discarded.

### Verification commands

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
