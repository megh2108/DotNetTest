import { TasksProject } from "./taskproject.model";
import { TasksUser } from "./taskuser.model";

export interface Tasks {
    taskId: number,
    projectId: number,
    title: string,
    description: string,
    priority: 'Low' | 'Medium' | 'High',
    status: 'To Do' | 'In Progress' | 'Completed',
    dueDate: Date | null,
    assignedTo: number | null,
    createdAt: Date,
    createdBy: number,
    project: TasksProject,
    assignedUser : TasksUser,
    createdByUser: TasksUser
}

