# Project Memory — Hobdex

## What this project is

A personal hobby tracking web app called **Hobdex**. The user can keep track of all their hobbies and the projects within each hobby. The home page shows hobby cards with a name, icon, and basic stats (total projects, completed, in progress). Eventually users will be able to click into a hobby to see its projects, add/edit hobbies and projects, upload images, and more.

## Learning goals

The primary purpose of this project is hands-on learning. The user is an experienced C# / .NET / SQL developer who is new to frontend development. Key things being learned:

- **React** — components, props, JSX, hooks (useState, useEffect), component composition
- **TypeScript** — interfaces, type annotations, union types, import type syntax
- **JavaScript** — modern JS patterns, destructuring, array methods (.map, .filter, etc.)
- **Vite** — dev server, hot module replacement, project structure
- **CSS** — styling React components, plain CSS, responsive grid layout
- **.NET backend (next)** — minimal APIs, REST, CORS, EF Core, SQL Server, DTOs

## Current tech stack

- React 19 + TypeScript (Vite scaffolded)
- Plain CSS (no UI library)
- Lucide React for icons
- No backend yet — all data is hardcoded in App.tsx

## Project structure

```
src/
  components/
    Header.tsx         — top branding bar
    HobbyCard.tsx      — card component for a single hobby
  types/
    Hobby.ts           — Hobby interface + IconName union type
  App.tsx              — root component, hardcoded hobbies array, renders Header + HobbyCard grid
  App.css              — global styles, dark minimal theme, CSS variables
  index.css            — minimal reset only (body margin, #root min-height)
```

## Conventions established

- Use `import type` for TypeScript type/interface imports (verbatimModuleSyntax is enabled)
- Explicit type annotations on arrays/variables (e.g. `const hobbies: Hobby[]`) rather than relying on inference
- One component per file, `export default` at the bottom
- Props interfaces defined in the same file as the component (e.g. `HobbyCardProps`)
- Static lookup objects (e.g. `iconMap`) defined outside component functions
- Named imports only for Lucide icons (tree shaking — never `import * as Icons`)

## Data model

```typescript
interface Hobby {
  id: number
  name: string
  imageUrl?: string        // optional — placeholder icon shown when absent
  description?: string     // optional
  totalProjects: number
  completedProjects: number
  inProgressProjects: number
  iconName: IconName
}

type IconName = 'paintbrush' | 'camera' | 'music' | 'book' | 'axe' | 'dumbbell'
// extend this union as new icons are added — keep in sync with iconMap in HobbyCard.tsx
```

## Design direction

- Dark, minimal, clean aesthetic
- App name: **Hobdex**
- CSS variables defined in App.css (--bg-primary, --accent: #c8a96e, etc.)
- Card-based layout with responsive grid (auto-fill, minmax 280px)
- Lucide icons as hobby placeholders until real images are supported
- No UI library — all hand-written CSS

## Backend plan (next up)

- **ASP.NET Core Web API** using .NET 10 minimal APIs (not controllers)
- **Entity Framework Core** for data access
- **SQL Server** as the database
- **DTOs** to separate API contracts from EF models
- CORS configured to allow the Vite dev server (localhost:5173)
- React will fetch data via useEffect + fetch replacing hardcoded arrays

## Background context

- User is comfortable with C# / .NET / SQL Server — analogies to C# are helpful
- User is learning React/TypeScript/JS — this is the primary learning goal
- User likes to type code themselves rather than paste — walk through steps, don't just generate files
- CSS is not a learning goal — just generate CSS directly when needed
- User asks great clarifying questions — answer them fully before moving on
- Commit to git frequently
- Teaching style: lead the user to answers with questions and hints, don't just give solutions