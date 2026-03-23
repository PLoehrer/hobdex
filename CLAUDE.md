# Project Memory — Hobby Tracker App

## What this project is

A personal hobby tracking web app. The user can keep track of all their hobbies and the projects within each hobby. The home page shows hobby cards with a name, image, and basic stats (total projects, completed, in progress). Eventually users will be able to click into a hobby to see its projects, add/edit hobbies and projects, upload images, and more.

## Learning goals

The primary purpose of this project is hands-on learning. The user is an experienced C# / .NET / SQL developer who is new to frontend development. Key things being learned:

- **React** — components, props, JSX, hooks (useState, useEffect), component composition
- **TypeScript** — interfaces, type annotations, generics, import type syntax
- **JavaScript** — modern JS patterns, destructuring, array methods (.map, .filter, etc.)
- **Vite** — dev server, hot module replacement, project structure
- **CSS** — styling React components, CSS modules or plain CSS, responsive layout
- **.NET backend (future)** — will be added later once frontend is comfortable; REST API, CORS, EF Core

## Current tech stack

- React 19 + TypeScript (Vite scaffolded)
- Plain CSS (no UI library yet)
- No backend yet — all data is hardcoded

## Project structure so far

```
src/
  components/
    Header.tsx       — top branding bar
    HobbyCard.tsx    — card component for a single hobby
  types/
    Hobby.ts         — Hobby interface (id, name, imageUrl, description, totalProjects, completedProjects, inProgressProjects)
  App.tsx            — root component, hardcoded hobbies array, renders Header + HobbyCard list
  App.css            — global styles (being cleaned up)
```

## Conventions established

- Use `import type` for TypeScript type/interface imports (verbatimModuleSyntax is enabled)
- Explicit type annotations on arrays/variables (e.g. `const hobbies: Hobby[]`) rather than relying on inference
- One component per file, `export default` at the bottom
- Props interfaces defined in the same file as the component (e.g. `HobbyCardProps`)

## Design direction

- Dark, minimal, clean aesthetic
- No UI library — hand-written CSS
- Card-based layout for hobbies on the home page

## Where we left off

About to write fresh CSS — wiping `App.css` and creating `HobbyCard.css` for a dark minimal card UI.

## Background context

- User is comfortable with C# / .NET / SQL Server
- Analogies to C# concepts are helpful (e.g. interfaces, typed parameters, async/await)
- User likes to type code themselves rather than paste — walk through steps, don't just generate files
- User asks great clarifying questions — answer them fully before moving on
- Commit to git frequently
