import './App.css'
import Header from './components/Header'
import HobbyCard from './components/HobbyCard'
import type { Hobby } from './types/Hobby'

function App() {
  const hobbies: Hobby[] = [{ id: 1, name: 'Woodworking', imageUrl: undefined, description: undefined, totalProjects: 15, completedProjects: 10, inProgressProjects: 5, iconName: 'axe' },
    { id: 2, name: 'Painting', imageUrl: undefined, description: undefined, totalProjects: 5, completedProjects: 3, inProgressProjects: 2, iconName: 'paintbrush' },
    { id: 3, name: 'Weightlifting', imageUrl: undefined, description: undefined, totalProjects: 10, completedProjects: 7, inProgressProjects: 3, iconName: 'dumbbell' },
    { id: 4, name: 'Music', imageUrl: undefined, description: undefined, totalProjects: 15, completedProjects: 10, inProgressProjects: 5, iconName: 'music' }]

  return (
    <div className="app">
      <Header />
      <main className="main-content">
        <h1 className="section-label">My Hobbies</h1>
        <div className="hobby-grid">
          {hobbies.map((hobby) => (
            <HobbyCard key={hobby.id} hobby={hobby} />
          ))}
        </div>
      </main>
    </div>
  )
}

export default App
