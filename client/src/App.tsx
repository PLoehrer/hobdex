import { useState, useEffect } from 'react'
import './App.css'
import Header from './components/Header'
import HobbyCard from './components/HobbyCard'
import type { Hobby } from './types/Hobby'

function App() {
  const [hobbies, setHobbies] = useState<Hobby[]>([]);
  const API_URL = import.meta.env.VITE_API_URL;
  useEffect(() => {
    fetch(`${API_URL}/hobbies`)
      .then(res => res.json())
      .then(data => setHobbies(data))
      .catch(err => console.error('Error fetching hobbies:', err));
  }, []);

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
