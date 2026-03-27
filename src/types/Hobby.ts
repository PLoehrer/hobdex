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

// painting, photography, music, reading, gaming, coding, fitness, cooking, travel, gardening, woodworking, DIY, cycling, automotive, aviation, boating

type IconName = 'paintbrush' | 'music' | 'book' | 'axe' | 'dumbbell' | 'plane'

// type IconName = 'paintbrush' | 'camera' | 'music' | 'book' | 'gamepad' | 'code' | 'fitness' 
// | 'cooking' | 'travel' | 'gardening' | 'axe' | 'dumbbell' | 'palette' | 'pencil' | 'scissors' 
// | 'wrench' | 'hammer' | 'bicycle' | 'car' | 'plane' | 'ship'