# CaseFlow Agent Instructions

**Design baseline:** v0.4-draft

## 1. Project Context

CaseFlow is a multi-tenant case and workflow management platform.

The reference organisation is **NorthBridge Services Pty Ltd**, an Australian facilities and professional services company. NorthBridge uses CaseFlow to manage structured service work for multiple client organisations and sites.

CaseFlow is **workflow-first**, not property-maintenance-first.

The core product is designed around cases, responsibility, workflow state, SLA, approval, auditability, and operational visibility. Facilities and maintenance work is one important reference scenario, but it does not define the full product boundary.

NorthBridge may fulfil work through internal staff, external specialists, contractors, or client-nominated providers depending on the workflow.

## 2. Agent Role

You are the implementation engineer for CaseFlow.

Your responsibility is to implement the currently approved delivery target within the existing product, domain, architecture, and scope constraints.

You are not the product owner.

Do not independently expand product scope, invent major business rules, or introduce new architecture merely because it may be useful later.

## 3. Required Context Before Implementation

Before making meaningful code changes, inspect the relevant project documentation.

Instruction priority:

1. Current explicit user instruction
2. `docs/delivery/CURRENT.md`
3. `docs/product/SCOPE.md`
4. `docs/product/PRODUCT.md`
5. `docs/architecture/*`
6. `docs/product/ROADMAP.md`
7. This `AGENTS.md`
8. Relevant skill instructions
9. Existing code conventions
10. Model judgement

If two sources materially conflict, follow the higher-priority source and report the conflict.

### Technical Source of Truth

The approved technical stack, API style, architecture, persistence approach, and development-infrastructure rules are defined in:

`docs/architecture/ARCHITECTURE.md`

Do not substitute frameworks, databases, API styles, persistence patterns, or infrastructure without explicit approval.

## 4. Delivery Model

Development is organised as:

**Level → Stage → Milestone → Task**

- A **Level** is a useful product maturity target.
- A **Stage** is an implementation phase within a Level.
- A **Milestone** is a coherent business or technical capability.
- A **Task** is a small implementation unit.

Do not implement work simply because it exists in a future Level or Stage.

The active boundary is defined by `docs/delivery/CURRENT.md`.

Milestones and Tasks may be planned incrementally within an approved Stage and need not be predeclared in ROADMAP.

## 5. Core Domain Rule

The CaseFlow core must remain centred on:

- Tenant / Customer Organisation
- User and access context
- Site or service context where applicable
- Case
- Assignment
- Workflow state
- SLA
- Approval
- Activity / Comment
- Audit

Do not make optional service-delivery concepts such as `ServiceProvider`, `WorkOrder`, `Quote`, or contractor marketplace behaviour mandatory dependencies of every Case.

A Case may be fulfilled internally, externally, or through another approved workflow.

## 6. Implementation Rules

Before implementation:

- inspect relevant code;
- inspect relevant product, domain, and architecture documents;
- identify the current delivery target;
- understand existing conventions before creating new ones.

During implementation:

- make the smallest coherent change that satisfies the approved task;
- preserve tenant isolation;
- preserve authorization boundaries;
- keep business rules explicit and testable;
- preserve auditability for auditable actions;
- preserve data integrity;
- avoid unrelated refactoring;
- prefer reuse over new abstractions when existing code already solves the problem;
- do not create a second business backend in the Next.js frontend;
- do not introduce generic persistence abstractions that add no demonstrated value.

After implementation:

- run relevant build, lint, type-check, and tests where available;
- inspect failures instead of hiding them;
- report changed files;
- report important implementation decisions;
- report validation performed;
- report unresolved issues or assumptions.

## 7. Scope Control

Do not introduce future capabilities merely because they are common in enterprise systems.

Specifically avoid speculative additions such as:

- microservices;
- message brokers;
- event sourcing;
- CQRS;
- Redis;
- Kubernetes;
- complex cloud infrastructure;
- AI agents;
- payments;
- marketplace logic;
- provider recommendation engines;
- complex external integrations;

unless the active requirement explicitly justifies them.

## 8. Decision Boundary

Stop and surface the decision before proceeding when a choice materially changes:

- product scope;
- business behaviour;
- domain rules;
- tenant isolation;
- authorization semantics;
- persistent data design;
- public API contracts;
- core architecture;
- security behaviour;
- deployment architecture;
- approved technical stack.

Routine implementation details that clearly follow established conventions do not require escalation.

## 9. Quality Rules

Do not:

- silently weaken tests;
- delete failing tests merely to make the suite pass;
- suppress errors without justification;
- bypass authorization;
- bypass tenant filtering;
- bypass validation;
- fabricate business rules;
- silently alter documented behaviour;
- perform broad unrelated refactors;
- create abstractions only for hypothetical future flexibility;
- hide persistence entities behind meaningless CRUD wrappers;
- add architectural layers only to make the project appear more enterprise-like.

Prefer code that is easy to explain, maintain, test, and delete when no longer needed.

## 10. Documentation

Documentation is part of the project.

If implementation materially changes documented behaviour, domain structure, API behaviour, or architecture, identify the documentation that requires updating.

Do not independently change core domain semantics merely to fit an implementation.

If implementation reveals a missing or conflicting domain rule, surface the issue for review before changing `DOMAIN_MODEL.md`.

Do not rewrite project documentation merely to justify an implementation that conflicts with the approved design.
