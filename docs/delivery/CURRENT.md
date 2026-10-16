# Current Delivery Target

**Design baseline:** v0.4-draft

## Current Level

Level 1 — MVP / Employable Version

## Current Stage

Stage 1.1 — Solution Foundation

## Current Milestone

Foundation Integration & Closure.

Working label: **1.1D**

This milestone integrates and verifies the foundations established by
1.1A, 1.1B, and 1.1C.

It should close remaining Stage 1.1 foundation gaps without introducing
business functionality from later stages.

## Current Objective

Verify that the complete CaseFlow development foundation is stable,
reproducible, and consistent with the Stage 1.1 expected outcomes.

The milestone should ensure that:

* the frontend foundation builds and passes its baseline quality checks;
* the backend foundation builds, tests, and runs correctly;
* PostgreSQL starts reproducibly through Docker Compose;
* the backend persistence configuration connects successfully to PostgreSQL;
* the local frontend/backend/database development workflow is clear;
* runtime/tool versions and configuration are internally consistent;
* a new developer can understand how to start and verify the development environment;
* remaining foundation-only cleanup is completed.

## Approved Work

### Frontend Verification

* verify dependency installation using the existing package-lock;
* verify linting;
* verify frontend tests;
* verify production build;
* verify explicit TypeScript type-check capability;
* add a small `typecheck` npm script using `tsc --noEmit` if an equivalent explicit command does not already exist.

Do not add business UI or backend API integration.

### Backend Verification

Verify:

* repository-local .NET tool restoration;
* solution restore;
* solution build;
* backend tests;
* backend startup;
* `GET /api/health`;
* development OpenAPI availability;
* EF Core DbContext discovery and persistence configuration.

Do not add additional API endpoints solely for verification.

### Local Development Workflow

Verify the intended Stage 1.1 development model:

* PostgreSQL runs through Docker Compose;
* ASP.NET Core runs locally;
* Next.js runs locally;
* all three can run together without configuration conflicts.

Frontend-to-backend business integration is not required in Stage 1.1.

### Development Documentation

Ensure the repository has concise, useful development startup documentation.

Prefer updating the root `README.md` if appropriate.

The documentation should cover only the practical Stage 1.1 development baseline, including:

* required runtimes/tools;
* PostgreSQL startup;
* backend startup;
* frontend startup;
* relevant build/test/lint/type-check commands.

Keep this documentation concise and developer-facing.

Do not duplicate architecture or product documentation unnecessarily.

### Version and Configuration Consistency

Review the existing Stage 1.1 runtime/tool configuration, including where applicable:

* `.nvmrc`;
* `global.json`;
* package lockfile;
* .NET project package versions;
* repository-local .NET tools;
* PostgreSQL Docker image;
* ASP.NET Core development configuration.

Resolve only clear Stage 1.1 inconsistencies.

Do not perform speculative dependency upgrades.

### Foundation Cleanup

Perform only small cleanup directly related to Stage 1.1.

Approved cleanup includes:

* rename the placeholder backend test file `UnitTest1.cs` to a clearer baseline-test name if it still exists;
* remove the unused `.agents/skills/*` stubs if they are confirmed to be obsolete;
* remove empty `.agents` directories resulting from that cleanup where appropriate.

Do not introduce replacement agent-skill infrastructure.

## Not Approved Yet

Work outside this milestone remains unapproved unless explicitly authorised.

In particular, do not implement:

* authentication;
* authorization;
* Tenant/User membership;
* Case or workflow domain entities;
* Assignment;
* SLA;
* Approval;
* Audit business behaviour;
* Service Provider / Work Order functionality;
* business repositories;
* frontend-to-backend business integration;
* CORS configuration unless a verified Stage 1.1 requirement makes it necessary;
* Playwright or business end-to-end tests;
* CI/CD;
* GitHub Actions;
* Azure/cloud deployment;
* frontend Dockerfile;
* backend Dockerfile;
* full-stack containerisation;
* Redis;
* message brokers;
* Kubernetes;
* Stage 1.2 or later functionality.

Do not create new architectural abstractions merely for Stage 1.1 closure.

Do not modify product or domain semantics.

## Expected Output

At milestone completion, report:

1. Stage 1.1 frontend verification results;
2. Stage 1.1 backend verification results;
3. PostgreSQL and persistence verification results;
4. complete local development workflow verification;
5. any README/development documentation changes;
6. runtime/tool/configuration consistency findings;
7. foundation cleanup performed;
8. all files created, modified, renamed, or deleted;
9. any remaining Stage 1.1 gaps;
10. any deviations from the approved milestone;
11. any risks or Review Queue candidates discovered.

A successful milestone leaves the repository with a stable and reproducible
Stage 1.1 development foundation and no premature Stage 1.2 functionality.

Do not advance the current Stage or Milestone automatically.

## Review Queue

### Tooling

* **ESLint 9 EOL**

  * Status: Deferred
  * Reason: The current Next.js tooling stack does not yet provide a clean
    ESLint 10 migration path without compatibility workarounds.
  * Review: Stage 1.1 closure, or earlier if the frontend tooling stack is upgraded.

