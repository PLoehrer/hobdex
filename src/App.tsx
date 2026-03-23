import './App.css'
import Header from './components/Header'
import HobbyCard from './components/HobbyCard'
import type { Hobby } from './types/Hobby'

function App() {
  const hobbies: Hobby[] = [{ id: 1, name: 'Test Hobby', imageUrl: 'test', description: 'This is a test hobby', totalProjects: 5, completedProjects: 3, inProgressProjects: 2 },
    { id: 2, name: 'Test Hobby 2', imageUrl: 'test', description: 'This is another test hobby', totalProjects: 10, completedProjects: 7, inProgressProjects: 3 },
    { id: 3, name: 'Test Hobby 3', imageUrl: 'test', description: 'This is yet another test hobby', totalProjects: 15, completedProjects: 10, inProgressProjects: 5 }]

  return (
    <>
      <Header />
      {hobbies.map((hobby) => (
        <HobbyCard key={hobby.id} hobby={hobby} />
      ))}

    </>
  )
}

export default App
