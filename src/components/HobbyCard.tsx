import type { Hobby } from '../types/Hobby'

interface HobbyCardProps {
    hobby: Hobby
}

function HobbyCard({ hobby }: HobbyCardProps) {
    return (
        <div>
            <img src={hobby.imageUrl} alt={hobby.name} />
            <h2>{hobby.name}</h2>
            <p>{hobby.description}</p>
            <p>Total Projects: {hobby.totalProjects}</p>
            <p>Completed: {hobby.completedProjects}</p>
            <p>In Progress: {hobby.inProgressProjects}</p>
        </div>
    )
}

export default HobbyCard