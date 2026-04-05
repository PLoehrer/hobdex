# Project Memory — Hobdex

## What this project is

A personal hobby tracking web app called **Hobdex** (Hobby + Codex). Users keep track of all their hobbies and the entries within each hobby. The home page shows hobby cards with a name, icon, and basic stats. Clicking into a hobby shows its entries with details, status, notes, and more.

## Learning goals

The primary purpose of this project is hands-on learning. The user is an experienced C# / .NET / SQL developer who is new to frontend development. Key things being learned:

- **React** — components, props, JSX, hooks (useState, useEffect), component composition, routing
- **TypeScript** — interfaces, type annotations, union types, import type syntax
- **JavaScript** — modern JS patterns, destructuring, array methods (.map, .filter, etc.)
- **Vite** — dev server, hot module replacement, project structure, env variables
- **CSS** — styling React components, plain CSS, responsive grid layout

The .NET backend is familiar territory — move fast there and focus teaching energy on the frontend.

## Repo structure

```
hobdex/                        ← git root
  client/                      ← React/Vite/TypeScript frontend
    src/
      components/
        Header.tsx             — top branding bar
        HobbyCard.tsx          — card component for a single hobby
      types/
        Hobby.ts               — Hobby interface + IconName union type
      App.tsx                  — root component, fetches hobbies, renders grid
      App.css                  — global styles, dark minimal theme, CSS variables
      index.css                — minimal reset only
    .env                       — VITE_API_URL (gitignored)
  api/
    Hobdex.Api/                ← ASP.NET Core Web API (.NET 10)
      Constants/
        EntryStatusNames.cs    — string constants for seeded status names
      Data/
        HobdexDbContext.cs
      DTOs/
        HobbyDto.cs
        EntryDto.cs
        EntryStatusDto.cs
        EntryTypeDto.cs
        TagDto.cs
      Endpoints/
        HobbyEndpoints.cs
        EntryEndpoints.cs
        EntryStatusEndpoints.cs
        EntryTypeEndpoints.cs
        TagEndpoints.cs
      Models/
        AuditEntity.cs         — abstract base with CreatedOn, UpdatedOn, CreatedBy, UpdatedBy
        User.cs
        Hobby.cs
        Entry.cs
        EntryLog.cs
        EntryStatus.cs
        EntryType.cs
        Tag.cs
        EntryTag.cs
        HobbyTag.cs
      Program.cs
  hobdex.code-workspace        ← VS Code multi-root workspace
  .gitignore
  CLAUDE.md
  README.md
```

## Current tech stack

- **Frontend:** React 19 + TypeScript, Vite, Lucide React, plain CSS
- **Backend:** ASP.NET Core Web API (.NET 10 minimal APIs), EF Core, SQL Server
- **Database:** SQL Server local instance (DESKTOP-8E1NF7K), database named HobdexDb
- **Version control:** Git / GitHub

## Backend — established patterns

- Minimal APIs (not controllers) organized as extension methods in `Endpoints/` folder
- `Program.cs` is clean — just wires up services and calls `app.MapXEndpoints()`
- DTOs separate API contracts from EF models
- EF Core code-first with migrations
- Connection string stored in .NET User Secrets (not in appsettings)
- CORS configured for `http://localhost:5173`
- `dotnet ef migrations add` / `dotnet ef database update` for schema changes
- `EF Core Select` projections used for computed counts — no `Include`/`ThenInclude`
- Status name comparisons use `EntryStatusNames` constants (no magic strings or magic numbers)

## Frontend — established patterns

- `useEffect` + `fetch` for data loading, API base URL from `import.meta.env.VITE_API_URL`
- `useState<T[]>([])` initialized to empty array, populated after fetch
- `useEffect` dependency array: `[]` = run once on mount
- `.env` file in `client/` holds `VITE_API_URL=http://localhost:5109`

## TypeScript/React conventions

- `import type` for TypeScript type/interface imports (verbatimModuleSyntax is enabled)
- Combine hook imports on one line: `import { useState, useEffect } from 'react'`
- Explicit type annotations on arrays/variables rather than relying on inference
- One component per file, `export default` at the bottom
- Props interfaces defined in the same file as the component
- Static lookup objects (e.g. `iconMap`) defined outside component functions
- Named imports only for Lucide icons (never `import * as Icons`)

## Design direction

- Dark, minimal, clean aesthetic — "codex" vibe
- App name: **Hobdex**
- CSS variables defined in App.css (--bg-primary, --accent: #c8a96e, etc.)
- Card-based layout with responsive grid (auto-fill, minmax 280px)
- Lucide icons as hobby placeholders until real images are supported
- No UI library — all hand-written CSS
- Drag-to-reorder planned for Hobbies and Entries

## Full data model — IMPLEMENTED

### Naming conventions
- Table names are **plural** (EF Core default)
- Audit columns on all core tables via `AuditEntity` base class: `CreatedOn`, `UpdatedOn`, `CreatedBy` (int, FK → Users), `UpdatedBy` (int, FK → Users)
- `User` does NOT extend `AuditEntity` — has its own nullable `CreatedBy`/`UpdatedBy` (null = self-registered, int = created by another user e.g. admin)
- Mapping tables (`EntryTags`, `HobbyTags`): `CreatedOn`, `UpdatedOn` only
- Soft delete (`IsDeleted` bool) on: `Hobbies`, `Entries`, `EntryLogs`
- Hard delete on: `Tags`, `EntryTypes`, `EntryTags`, `HobbyTags`
- `DisplayOrder` stored as `double` (float in SQL) to allow reordering without renumbering all rows

### Tables (all implemented and migrated)

**Users** — Id, Email, DisplayName, CreatedOn, UpdatedOn, CreatedBy (int?), UpdatedBy (int?)

**Hobbies** — Id, UserId, Name, Description, IconName, ImageUrl, DisplayOrder, IsDeleted + audit

**EntryStatuses** *(seeded lookup)* — Id, Name
- Seeded: Not Started (1), In Progress (2), Completed (3), Abandoned (4)

**EntryTypes** *(user-defined)* — Id, UserId, Name, Color, IsGlobal + audit

**Entries** — Id, HobbyId, EntryStatusId, EntryTypeId (nullable), Title, Description, StartDate, EndDate, DisplayOrder, IsDeleted + audit

**EntryLogs** — Id, EntryId, Content, IsDeleted, CreatedOn, UpdatedOn

**Tags** — Id, UserId, Name, Color + audit

**EntryTags** *(mapping)* — EntryId, TagId, CreatedOn, UpdatedOn

**HobbyTags** *(mapping)* — HobbyId, TagId, CreatedOn, UpdatedOn

### Key design decisions
- Entry counts (total, in progress, completed) computed via EF `Select` projections — not stored columns
- `EntryType` is user-defined — not a fixed enum/lookup
- `EntryStatusNames` constants class used everywhere instead of magic strings
- `OnDelete(DeleteBehavior.NoAction)` configured on `HobbyTag → Tag` and `EntryTag → Tag` to avoid SQL Server multiple cascade paths error
- Global Query Filters on `Hobby`, `Entry`, `EntryLog` for automatic soft delete filtering
- History tables (_HS) deferred — audit columns cover MVP needs
- File/image uploads deferred to post-MVP
- Auth deferred to post-MVP — UserId on Hobby is in place to support it later

## Implemented API endpoints

| Method | Route | Description |
|--------|-------|-------------|
| GET | /hobbies | All hobbies with computed entry counts |
| GET | /hobbies/{hobbyId}/entries | Entries for a hobby |
| POST | /entries | Create a new entry |
| GET | /entry-statuses | All entry statuses |
| GET | /entry-types/{userId} | Entry types for a user |
| POST | /entry-types | Create an entry type |
| GET | /tags/{userId} | Tags for a user |
| POST | /tags | Create a tag |

## Planned frontend phases

1. **React Router + hobby detail page** ← NEXT
2. Entry list and entry cards
3. Add/edit forms (hobbies and entries)
4. Entry logs
5. Tags and filtering
6. Drag-to-reorder (using float DisplayOrder)

## Deferred / post-MVP

- Authentication
- History tables (_HS)
- File/image upload support
- Add/delete hobby and entry type endpoints

## Background context

- User is comfortable with C# / .NET / SQL Server — go fast, generate code directly
- User is learning React/TypeScript/JS — explain concepts, ask leading questions, let them write the code
- CSS is not a learning goal — generate CSS directly
- Commit to git frequently
- For React/TypeScript: lead the user to answers with questions and hints, don't just give solutions
- For .NET/backend/CSS: generate code directly and move quickly
