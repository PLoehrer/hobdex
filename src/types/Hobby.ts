export interface Hobby {
    id: number
    name: string
    imageUrl?: string
    description?: string
    totalProjects: number
    completedProjects: number
    inProgressProjects: number
    iconName: IconName
}

type IconName = 'paintbrush' | 'camera' | 'music' | 'book' | 'axe' | 'dumbbell'

// type IconName = 'paintbrush' | 'camera' | 'music' | 'book' | 'gamepad' | 'code' | 'fitness' 
// | 'cooking' | 'travel' | 'gardening' | 'axe' | 'dumbbell' | 'palette' | 'pencil' | 'scissors' 
// | 'wrench' | 'hammer' | 'bicycle' | 'car' | 'plane' | 'ship'