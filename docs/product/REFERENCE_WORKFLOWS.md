# CaseFlow Reference Workflows

**Design baseline:** v0.4-draft

This document provides concrete examples for product design and demos.

These workflows are examples, not universal domain requirements.

## 1. Facilities / Maintenance

```text
Customer reports issue
        ↓
Case created
        ↓
Manager reviews / triages
        ↓
Case assigned
        ↓
Internal team or external provider performs work
        ↓
Progress updated
        ↓
SLA monitored
        ↓
Completion / approval
        ↓
Audit history
```

Optional extension:

```text
Case
 ↓
Work Order
 ↓
Service Provider
 ↓
Quote / approval if required
 ↓
Completion evidence
```

The provider may be:

- NorthBridge internal team;
- client-preferred contractor;
- external specialist;
- future approved provider network.

The workflow must also work without marketplace or provider-discovery behaviour.

## 2. Multi-site Operational Service

```text
Store/site reports operational problem
        ↓
Case created
        ↓
Operations manager reviews
        ↓
Internal specialist assigned
        ↓
Progress and deadline tracked
        ↓
Case completed
        ↓
Audit and reporting
```

This scenario demonstrates that CaseFlow is not limited to property repair.

## 3. Professional Service Case

```text
Client submits request
        ↓
Case created
        ↓
Coordinator reviews
        ↓
Specialist assigned
        ↓
Documents/information collected
        ↓
Review / approval
        ↓
Case completed
        ↓
Audit history
```

No Service Provider or Work Order is required.

## 4. Design Rule

When designing a CaseFlow core capability, ask:

> Does this capability belong to the general lifecycle of a Case, or only to one reference workflow?

If it belongs only to one workflow, prefer an extension/module rather than making it mandatory in the core domain.
