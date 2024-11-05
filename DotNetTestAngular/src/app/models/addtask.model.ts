export interface AddTask {
    projectId: number,
    title: string,
    description: string,
    priority: 'Low' | 'Medium' | 'High',
    status: 'To Do' | 'In Progress' | 'Completed',
    dueDate: Date | null,
    assignedTo: number | null,
    createdAt: Date,
    createdBy: number
}

