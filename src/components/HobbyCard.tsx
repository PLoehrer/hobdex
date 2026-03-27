import { Axe, Book, Camera, Dumbbell, Music, Paintbrush, Plane } from 'lucide-react'
import type { Hobby } from '../types/Hobby'
import './HobbyCard.css'

interface HobbyCardProps {
    hobby: Hobby
}

const iconMap = {
        paintbrush: Paintbrush,
        camera: Camera,
        music: Music,
        book: Book,
        axe: Axe,
        dumbbell: Dumbbell,
        plane: Plane,
    }

function HobbyCard({ hobby }: HobbyCardProps) {
    const Icon = iconMap[hobby.iconName]

    return (
        <div className="hobby-card">
            {hobby.imageUrl && (
                <img className="hobby-card__image" src={hobby.imageUrl} alt={hobby.name} />
            )}
            {!hobby.imageUrl && (
                <div className="hobby-card__placeholder">
                    <span className="hobby-card__placeholder-icon">
                        {Icon && <Icon size={48} color="currentColor" />}
                    </span>
                </div>
            )}
            <div className="hobby-card__body">
                <h2 className="hobby-card__name">{hobby.name}</h2>
                <p className="hobby-card__description">{hobby.description}</p>
                <div className="hobby-card__stats">
                    <div className="hobby-card__stat">
                        <span className="hobby-card__stat-value">{hobby.totalProjects}</span>
                        <span className="hobby-card__stat-label">Total Projects</span>
                    </div>
                    <div className="hobby-card__stat">
                        <span className="hobby-card__stat-value">{hobby.completedProjects}</span>
                        <span className="hobby-card__stat-label">Completed</span>
                    </div>
                    <div className="hobby-card__stat">
                        <span className="hobby-card__stat-value">{hobby.inProgressProjects}</span>
                        <span className="hobby-card__stat-label">In Progress</span>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default HobbyCard