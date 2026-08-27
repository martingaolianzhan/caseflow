# CaseFlow Scope

**Design baseline:** v0.4-draft

## 1. Scope Principle

CaseFlow is developed incrementally through explicit maturity Levels.

A capability being useful in a hypothetical commercial product does not make it part of the current delivery scope.

Future compatibility may influence a design decision, but speculative future requirements must not create unnecessary current complexity.

Technical implementation must follow `docs/architecture/ARCHITECTURE.md`.

# Level 1 — MVP / Employable Version

## Goal

Deliver a complete demonstrable vertical workflow showing that CaseFlow can manage a real service Case end-to-end across tenant, role, workflow, SLA, and audit boundaries.

## Required Product Capabilities

- authentication;
- customer organisation / tenant foundation;
- user and role foundation;
- site or equivalent service-context support;
- Case creation;
- Case viewing and queueing;
- Case assignment;
- Case status transitions;
- basic SLA due-date and overdue behaviour;
- audit logging of important actions;
- basic operational dashboard;
- seed/demo data;
- essential tests;
- basic project documentation.

## Required Technical Foundation

Level 1 also requires:

- Next.js + React + TypeScript frontend;
- ASP.NET Core controller-based REST-style Web API;
- Entity Framework Core;
- PostgreSQL;
- EF Core migrations;
- baseline Docker Compose development environment with PostgreSQL;
- OpenAPI development documentation;
- reproducible local frontend/backend/database startup;
- baseline automated testing capability.

## Level 1 Reference Workflow

The primary demo workflow may use a facilities/service-request scenario because it naturally demonstrates intake, assignment, operational work, SLA, audit, and completion.

However, Level 1 must not make property-maintenance-specific concepts mandatory in the CaseFlow core.

# Level 2 — Competitive Enterprise Version

Expected capabilities include:

- richer approval workflows;
- comments and activity timeline;
- document attachments;
- notifications;
- filtering;
- sorting;
- pagination;
- stronger API validation;
- broader integration testing;
- improved/full-stack Docker developer experience where useful;
- ERD and expanded architecture documentation;
- selected service-delivery extensions where justified.

Potential service-delivery extensions may include:

- Service Provider;
- Work Order;
- Quote;
- completion evidence.

These remain extensions of Case processing, not universal requirements for every Case.

# Level 3 — Portfolio / Production-minded Version

Potential capabilities include:

- CI/CD;
- cloud deployment;
- structured error logging;
- rate limiting;
- justified background jobs;
- advanced reporting;
- audit export;
- documented security considerations;
- performance analysis;
- portfolio walkthrough and case study.

# Explicitly Deferred

Unless explicitly promoted into the active delivery target:

- payment;
- billing;
- native mobile applications;
- AI agents;
- marketplace behaviour;
- provider recommendation/ranking;
- provider reputation scoring;
- complex supplier compliance;
- advanced procurement;
- complex notification rules;
- broad enterprise integrations;
- microservices;
- Kubernetes;
- speculative distributed infrastructure;
- unnecessary generic repository layers;
- Next.js-based parallel persistence/business backend.

## Commercialisation Boundary

Future commercialisation may choose a specific vertical or workflow module.

The current project must preserve enough domain clarity to evolve, but it must not prematurely become a clone of a property-maintenance platform or any other single incumbent.
