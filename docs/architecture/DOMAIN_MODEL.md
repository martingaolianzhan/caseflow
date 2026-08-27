# CaseFlow Domain Model

**Design baseline:** v0.4-draft

## 1. What This Document Defines

The Domain Model describes the business concepts, relationships, behaviours, and invariants that CaseFlow must represent.

It is **not** a database schema, API contract, or UI model.

For example:

- `Case` is a domain concept;
- the rule that every Case belongs to one Tenant is a domain invariant;
- whether the database stores that relationship using a particular foreign key/index is a persistence decision;
- whether an API returns a particular DTO shape is an API decision.

The purpose of this document is to keep the business model stable even when implementation details change.

## 2. Domain Principle

CaseFlow models structured business **Cases**, not one specific industry.

Facilities and maintenance work is a reference scenario, but the domain core must remain usable for other service and professional workflows.

The core Level 1 domain is:

```text
Tenant / Customer Organisation
        ↓
       Site or Service Context
        ↓
       Case
        ↓
    Assignment
        ↓
   Workflow State
        ↓
       SLA
        ↓
      Audit
```

Approval, comments, documents, and service-delivery extensions can enrich this flow.

## 3. Tenant / Customer Organisation

A Tenant represents a client organisation whose operational data must be isolated from other client organisations.

Examples include a property-services client, retail chain, clinic group, or professional-services client.

Tenant is primarily a data and authorization boundary.

Tenant-owned operational data must belong to exactly one Tenant unless a future approved design explicitly introduces a different ownership model.

## 4. User

A User represents an authenticated human identity.

A User may operate in different business contexts depending on approved membership, role, or access relationships.

Identity must not be confused with resource ownership.

The exact persistence representation of membership and cross-context access is deferred until Stage 1.2.

## 5. Site / Service Context

A Site represents a physical or operational location where that concept is relevant.

Examples:

- office;
- store;
- clinic;
- warehouse;
- property;
- service location.

Not every future CaseFlow workflow must require a physical Site.

The domain should preserve the ability to support non-site-based professional service Cases.

## 6. Case

Case is the central workflow aggregate.

A Case represents a business matter requiring structured handling.

A Case must:

- belong to a Tenant;
- have an identifiable lifecycle;
- support ownership/assignment;
- support status or workflow progression;
- preserve relevant history.

A Case may optionally reference a Site or another approved service context.

A Case is not inherently a maintenance request and does not inherently require an external provider.

## 7. Assignment

Assignment represents responsibility for progressing a Case or approved part of a Case.

Level 1 must support clear current ownership.

The exact representation of assignment history should be decided before implementation if history is required beyond the AuditLog.

## 8. Workflow State

A Case progresses through an approved state model.

The exact Level 1 state machine must be explicitly defined before Stage 1.3 implementation.

State transitions must not be invented ad hoc by individual endpoints.

## 9. SLA

SLA represents a time-based service expectation or deadline associated with a Case.

Level 1 requires at minimum:

- a due time or equivalent deadline;
- deterministic overdue evaluation.

Complex escalation policies are deferred.

## 10. Approval

Approval represents an explicit decision gate in a workflow.

Not every Case requires approval.

Closure approval, quote approval, or other approval types may be introduced only when required by the active scope.

## 11. Comment / Activity

Comments and activity entries provide human-readable operational context around a Case.

Detailed collaboration features are primarily Level 2 unless promoted into Level 1.

## 12. Audit Log

AuditLog records important business and security-relevant actions.

Examples:

- Case creation;
- assignment;
- status changes;
- approval decisions;
- important access or ownership changes.

Audit records are append-oriented and must not be treated as ordinary editable business data.

## 13. Optional Service Delivery Extension

Some Cases may require work to be fulfilled by an internal team or external provider.

A service-delivery extension may introduce:

### Service Provider

An internal or external organisation/person capable of performing work.

Examples:

- NorthBridge internal service team;
- client-preferred contractor;
- external specialist;
- approved third-party provider.

### Work Order

A formal instruction created from a Case when execution must be handed to a service provider.

A Work Order is **not required for every Case**.

### Quote

A commercial proposal associated with work requiring approval before execution.

Quotes are optional and deferred unless required by the active stage.

### Completion Evidence

Evidence such as notes, documents, or photos supporting completion of work.

This extension demonstrates one possible fulfilment workflow. It must not redefine the CaseFlow core as a property-maintenance platform.

## 14. Domain Invariants

At minimum:

- tenant-owned data must not cross tenant boundaries;
- every Case belongs to exactly one Tenant;
- unauthorized users must not gain access through predictable identifiers;
- workflow state changes must follow approved transition rules;
- assignment must respect authorization rules;
- important auditable actions must create appropriate audit records;
- optional service-delivery objects must not become mandatory for unrelated Case types.

## 15. Deferred Decisions

Resolve only when the relevant milestone needs them:

- exact user/membership persistence model;
- exact Case state machine;
- assignment-history representation;
- exact SLA policy model;
- exact approval model;
- whether Level 1 requires comments/activity;
- exact service-provider/work-order model;
- cross-tenant or platform-operator access semantics.

Do not invent these decisions prematurely.
