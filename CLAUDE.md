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
      Data/
        HobdexDbContext.cs
      DTOs/
        HobbyDto.cs
      Endpoints/
        HobbyEndpoints.cs
      Models/
        Hobby.cs
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

## Full data model plan

### Naming conventions
- Table names are **plural** (EF Core default)
- Audit columns on all core tables: `CreatedOn`, `UpdatedOn`, `CreatedBy` (FK → Users), `UpdatedBy` (FK → Users)
- Mapping/lookup tables: `CreatedOn`, `UpdatedOn` only (ownership implied by parent)
- Soft delete (`IsDeleted` bool) on: `Hobbies`, `Entries`, `EntryLogs`
- Hard delete on: `Tags`, `EntryTypes`, `EntryTags`, `HobbyTags`
- `DisplayOrder` stored as float/decimal to allow reordering without renumbering all rows

### Tables

**Users**
- Id, Email, DisplayName, CreatedOn, UpdatedOn, CreatedBy, UpdatedBy

**Hobbies**
- Id, UserId (FK → Users), Name, Description, IconName, ImageUrl, DisplayOrder, IsDeleted
- CreatedOn, UpdatedOn, CreatedBy, UpdatedBy

**EntryStatuses** *(seeded lookup)*
- Id, Name
- Seed: Not Started, In Progress, Completed, Abandoned

**EntryTypes** *(user-defined — not a fixed lookup)*
- Id, UserId (FK → Users), Name, Color (hex string), IsGlobal (bool — global vs hobby-scoped)
- CreatedOn, UpdatedOn, CreatedBy, UpdatedBy

**Entries**
- Id, HobbyId (FK → Hobbies), EntryStatusId (FK → EntryStatuses), EntryTypeId (FK → EntryTypes, nullable)
- Title, Description, StartDate (nullable), EndDate (nullable), DisplayOrder, IsDeleted
- CreatedOn, UpdatedOn, CreatedBy, UpdatedBy

**EntryLogs** *(journal entries within an Entry)*
- Id, EntryId (FK → Entries), Content, IsDeleted
- CreatedOn, UpdatedOn

**Tags** *(per user)*
- Id, UserId (FK → Users), Name, Color (hex string)
- CreatedOn, UpdatedOn, CreatedBy, UpdatedBy

**EntryTags** *(mapping)*
- EntryId (FK → Entries), TagId (FK → Tags)

**HobbyTags** *(mapping)*
- HobbyId (FK → Hobbies), TagId (FK → Tags)

### Key design decisions
- Project counts (total, in progress, completed) are computed from Entries — not stored columns
- EntryType is user-defined and flexible — not a fixed enum/lookup. Users create their own types (e.g. "Shoot", "Edit Session", "Race") and can scope them globally or per hobby via `IsGlobal` flag
- History tables (_HS) explicitly deferred — audit columns cover MVP needs
- File/image uploads deferred to post-MVP
- Auth deferred to post-MVP — UserId on Hobby is in place to support it later
- EF Core Global Query Filters to be used for automatic IsDeleted filtering

## Background context

- User is comfortable with C# / .NET / SQL Server — go fast, generate code directly
- User is learning React/TypeScript/JS — explain concepts, ask leading questions, let them write the code
- CSS is not a learning goal — generate CSS directly
- Commit to git frequently
- For React/TypeScript: lead the user to answers with questions and hints, don't just give solutions
- For .NET/backend/CSS: generate code directly and move quickly
