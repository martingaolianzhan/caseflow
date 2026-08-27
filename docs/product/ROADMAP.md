# CaseFlow Delivery Roadmap

**Design baseline:** v0.4-draft

# Level 1 — MVP / Employable Version

## Definition of Done

A demo user can complete a coherent Case workflow:

**Request / Case creation → triage or review → assignment → work/progress update → SLA evaluation → completion → audit history → operational visibility**

The application must demonstrate working tenant and authorization boundaries.

The Level 1 implementation should remain centred on the CaseFlow core rather than optional vertical-specific extensions.

The implementation must follow the approved technical baseline in `docs/architecture/ARCHITECTURE.md`.

## Stage 1.1 — Solution Foundation

Goal: create a stable, reproducible development foundation.

Expected outcomes:

### Frontend

- Next.js application;
- React;
- TypeScript;
- App Router;
- basic frontend project structure.

### Backend

- ASP.NET Core Web API;
- controller-based API structure;
- REST-style HTTP/JSON conventions;
- initial API/controller organisation;
- OpenAPI available in development.

### Persistence

- Entity Framework Core;
- PostgreSQL;
- initial EF Core migration workflow.

### Development Environment

- Docker Compose baseline;
- PostgreSQL development container;
- local frontend/backend development workflow;
- environment/configuration strategy;
- relevant runtime/tool version pinning where appropriate.

### Quality Foundation

- baseline backend testing setup;
- baseline frontend testing capability;
- build/type-check/lint commands where applicable.

Stage 1.1 should establish the foundation only. It must not prematurely implement later business modules.

## Stage 1.2 — Identity, Tenancy and Access Boundaries

Goal: establish organisational and security boundaries.

Expected outcomes:

- Customer Organisation / Tenant;
- User;
- role model;
- explicit authentication architecture decision;
- authentication implementation;
- authorization foundation;
- tenant resolution;
- tenant data isolation;
- site/service-context ownership where needed;
- essential authorization tests;
- explicit cross-tenant denial tests.

Detailed role semantics must follow `AUTHORIZATION.md`.

## Stage 1.3 — Core Case Workflow

Goal: implement the central Case lifecycle.

Expected outcomes:

- Site or equivalent service context;
- Case;
- Case creation;
- Case queue;
- Case details;
- assignment;
- progress/status transitions;
- basic operational UI;
- REST-style API endpoints for the approved workflow;
- valid domain transition rules.

The implementation must not require a Service Provider or Work Order for every Case.

## Stage 1.4 — SLA and Auditability

Goal: make workflow behaviour measurable and traceable.

Expected outcomes:

- SLA or deadline rule;
- due date;
- overdue calculation;
- audit events for important workflow actions;
- case activity visibility where needed;
- tests for important SLA/audit behaviour.

## Stage 1.5 — MVP Integration and Release

Goal: turn individual capabilities into a coherent demonstrable release.

Expected outcomes:

- basic dashboard;
- open / overdue / completed visibility;
- seed data;
- demo accounts;
- critical workflow integration tests;
- README;
- architecture documentation;
- documented OpenAPI surface;
- reproducible local startup;
- demo-ready Level 1 release.

Full-stack Docker containerisation may be considered here if it materially improves reproducibility or deployment, but it is not required merely for appearance.

# Level 1 Release Gate

Level 1 is complete only if the primary Case workflow works end-to-end and tenant isolation, authorization, core business behaviour, API behaviour, and local reproducibility can be demonstrated.

Partial completion of individual features does not satisfy the Level 1 gate.

---

# Level 2 — Competitive Enterprise Version

Tentative stages:

- Stage 2.1 — Workflow Enrichment
- Stage 2.2 — Collaboration and Documents
- Stage 2.3 — Notifications and Query Hardening
- Stage 2.4 — Service Delivery Extensions
- Stage 2.5 — Testing and Developer Experience

Possible Stage 2.4 capabilities:

- Service Provider directory;
- basic Work Orders;
- quote / approval flow where justified;
- completion evidence.

These are not part of the CaseFlow kernel.

Stage 2.5 may improve:

- containerised developer experience;
- end-to-end testing;
- CI workflows;
- developer tooling.

Detailed planning should occur after the Level 1 release gate.

---

# Level 3 — Portfolio / Production-minded Version

Tentative stages:

- Stage 3.1 — Deployment and CI/CD
- Stage 3.2 — Observability and Reliability
- Stage 3.3 — Security and Performance
- Stage 3.4 — Advanced Reporting
- Stage 3.5 — Portfolio Packaging

Detailed planning should occur after Level 2 maturity and real project or market feedback.
