# CaseFlow Product Definition

**Design baseline:** v0.4-draft

## 1. Product

**CaseFlow** is a multi-tenant case and workflow management platform for organisations that need structured, auditable handling of service work across clients, teams, and sites.

CaseFlow is **workflow-first** rather than tied to one vertical such as property maintenance.

## 2. Reference Organisation

The reference organisation is **NorthBridge Services Pty Ltd**, an Australian facilities and professional services company.

NorthBridge manages service work for multiple client organisations. Depending on the engagement, work may be performed by:

- NorthBridge internal staff;
- external specialists or contractors;
- client-nominated service providers;
- another approved party in the workflow.

NorthBridge is the reference business used to make the product concrete. It does not define every possible CaseFlow customer or use case.

## 3. Core Problem

Operational work is often fragmented across:

- email;
- spreadsheets;
- shared folders;
- phone calls;
- messaging apps;
- disconnected specialist systems.

This creates recurring problems:

- requests are missed;
- ownership is unclear;
- hand-offs are inconsistent;
- response deadlines are missed;
- approval history is difficult to reconstruct;
- important documents and comments are scattered;
- managers lack operational visibility;
- similar work is handled differently by different people.

## 4. Product Goal

CaseFlow centralises service requests into structured workflows with explicit ownership and traceability.

The product should support realistic enterprise software capabilities including:

- multi-tenancy;
- authentication and authorization;
- case intake;
- assignment;
- workflow state transitions;
- SLA tracking;
- approvals;
- comments and activity history;
- audit logging;
- operational reporting.

## 5. Product Boundary

The fundamental object is a **Case**.

A Case represents a business matter that must be:

1. received or created;
2. understood;
3. owned;
4. processed through an approved workflow;
5. tracked against relevant service expectations;
6. reviewed or approved where necessary;
7. completed with a durable history.

The core product must not assume that every Case is:

- a property repair;
- a maintenance request;
- a contractor job;
- a document request;
- a support ticket.

These are possible workflow types built on the same core.

## 6. Reference Scenarios

### Scenario A — Facilities and Maintenance

A client site reports an air-conditioning problem.

CaseFlow records the Case, assigns responsibility, tracks SLA, and may create a Work Order for an internal or external provider.

### Scenario B — Multi-site Operations

A retail client reports an operational issue at one location.

A manager triages the Case, assigns an internal team or specialist, tracks progress, and records the outcome.

### Scenario C — Professional Service Case

A client submits a document-driven service request.

The Case moves through review, assignment, document collection, approval, and completion without requiring a maintenance provider.

These scenarios demonstrate that the same case/workflow kernel can support different service contexts.

## 7. Product Principles

- Business correctness is more important than feature count.
- Workflow clarity is more important than visual novelty.
- Security boundaries and tenant isolation are first-class requirements.
- Auditability should be designed into meaningful business actions.
- The core should remain reusable without pretending to solve every workflow in every industry.
- Reference workflows should be concrete; the core domain should not be unnecessarily vertical-specific.
