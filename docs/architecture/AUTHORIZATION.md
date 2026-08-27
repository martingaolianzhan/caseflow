# CaseFlow Authorization Model

**Design baseline:** v0.4-draft

## 1. Security Principle

Authorization is enforced by the backend.

Frontend visibility, hidden buttons, or disabled controls are usability features, not security enforcement.

## 2. Authorization Dimensions

An authorization decision may depend on:

1. authenticated identity;
2. tenant/customer-organisation access;
3. role or permission;
4. resource tenant ownership;
5. relationship to the resource;
6. workflow state where relevant.

A role alone must not grant access across tenant boundaries.

## 3. Tenant Isolation

Tenant-scoped resources must only be accessible to users explicitly authorised for that Tenant.

A user authorised for Tenant A must not access a Case owned by Tenant B merely because the user knows the Case identifier.

Tenant isolation must be enforced server-side.

## 4. Role Philosophy

Roles describe broad business responsibility.

Detailed authorization should not rely on role names alone when resource ownership or workflow context also matters.

The exact Level 1 role set will be finalised before Stage 1.2 implementation.

## 5. Reference Role Categories

These categories describe the current product direction without locking the final persistence model.

### Platform Administrator

Represents administration of the CaseFlow platform/reference NorthBridge environment.

Platform administration does not automatically imply unrestricted day-to-day access to all tenant business data.

### Tenant / Customer Manager

Represents a manager or authorised coordinator operating for a client organisation.

Typical responsibilities may include:

- viewing tenant Cases;
- reviewing incoming Cases;
- assigning responsibility;
- monitoring workflow and SLA;
- performing manager-level workflow actions.

### Tenant / Customer User

Represents a normal user associated with a client organisation.

Typical capabilities may include:

- creating Cases;
- viewing Cases they are authorised to see;
- providing required information;
- viewing appropriate progress.

### Internal Service User

Represents an internal service or professional user who may process approved Cases.

This may include NorthBridge staff in a reference workflow.

Access must be explicitly constrained to the relevant tenant and Case context.

### External Provider User

Represents a user acting for an external provider when an optional service-delivery workflow is used.

This role is not required for every CaseFlow workflow and should not be implemented in Level 1 unless the active delivery target requires it.

## 6. Resource-level Rules

At minimum:

- Case access requires tenant authorization;
- assignment requires permission appropriate to the workflow;
- status changes require both permission and a valid transition;
- audit history must not expose cross-tenant information;
- optional Work Orders and provider data must respect the owning Case/Tenant context.

## 7. Level 1 Permission Matrix

The exact matrix is intentionally not final yet.

| Capability                 |     Customer User | Customer Manager |         Internal Service User |      Platform Admin |
| -------------------------- | ----------------: | ---------------: | ----------------------------: | ------------------: |
| Create Case                |               Yes |              Yes |             Context-dependent |  Admin/support only |
| View permitted Case        |               Yes |              Yes |                           Yes | Explicitly governed |
| View tenant Case queue     |           Limited |              Yes |             Context-dependent | Explicitly governed |
| Assign Case                |                No |              Yes |                    Usually No | Explicitly governed |
| Update Case progress       |           Limited |              Yes | Yes where assigned/authorised | Explicitly governed |
| View SLA status            | Appropriate Cases |              Yes |             Appropriate Cases | Explicitly governed |
| Tenant user administration |                No |      Context/TBD |                            No | Platform-level only |

Any `TBD` or context-dependent cell must be resolved before implementing the relevant endpoint.

## 8. Service Delivery Extension

If Service Providers / Work Orders are introduced:

- a provider user must not gain broad tenant access merely because a Work Order exists;
- provider access should be limited to the work and context required;
- client-nominated and platform-approved providers may have different onboarding relationships but must still follow explicit authorization;
- marketplace-style access is deferred.

## 9. Security Rules

Never:

- authorize solely from frontend state;
- trust a tenant identifier supplied by the client without validating access;
- permit a role check to bypass resource ownership checks;
- expose tenant-scoped entities through predictable IDs without authorization;
- silently widen permissions to solve implementation difficulty.

## 10. Testing Expectations

Authorization-sensitive functionality should include tests covering:

- permitted access;
- denied role access;
- denied cross-tenant access;
- unauthenticated access where relevant;
- invalid workflow-context access where relevant.

Cross-tenant denial tests are high priority.

## 11. Deferred Decisions

Before Stage 1.2 implementation, explicitly decide:

- final Level 1 role names;
- user-to-tenant membership model;
- whether internal service users can access multiple tenants;
- whether customer managers can administer tenant users in Level 1;
- how platform administrators access tenant data, if at all;
- resource-level visibility rules for customer users.

