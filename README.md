# Hobdex

A personal hobby tracking tool. Keep all your hobbies in one place, log entries within each hobby, and see your progress at a glance. Built as a hands-on learning project for modern full-stack development.

---

## Tech Stack

| Layer | Technology |
|---|---|
| Frontend | React 19 + TypeScript |
| Build tool / Dev server | Vite |
| Styling | Plain CSS |
| Backend | ASP.NET Core Web API (.NET 10, minimal APIs) |
| ORM | Entity Framework Core |
| Database | SQL Server |
| Version control | Git / GitHub |

---

## Project Structure

```
hobdex/
  client/       — React/Vite frontend
  api/          — ASP.NET Core Web API
```

---

## Getting Started

### Frontend
```bash
cd client
npm install
npm run dev
```
Runs at `http://localhost:5173`

### Backend
```bash
cd api/Hobdex.Api
dotnet run
```
Runs at `http://localhost:5109`

> Connection string is stored in .NET User Secrets and not committed to the repo.
