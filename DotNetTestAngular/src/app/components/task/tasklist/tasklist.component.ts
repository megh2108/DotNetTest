import { Component, OnInit } from '@angular/core';
import { TaskService } from '../../../services/task.service';
import { Router } from '@angular/router';
import { Tasks } from '../../../models/tasks.model';
import { ApiResponse } from '../../../models/ApiResponse{T}';

@Component({
  selector: 'app-tasklist',
  templateUrl: './tasklist.component.html',
  styleUrl: './tasklist.component.css'
})
export class TasklistComponent implements OnInit {


  tasks: Tasks[] | undefined;
  taskId: number | undefined;

  constructor(private taskService: TaskService, private router: Router) { }

  ngOnInit(): void {
    this.loadTasks();
  }

  loadTasks(): void {
    this.taskService.getAllTasks().subscribe({
      next: (response: ApiResponse<Tasks[]>) => {
        if (response.success) {
          this.tasks = response.data;
          console.log(this.tasks);
        }
        else {
          console.error('Falied to fetch tasks', response.message);
        }
      },
      error: (error => {
        console.error('Error fetching categories.', error);
      })

    })
  }

  updateTask(taskId: number): void {
    this.router.navigate(['/updatetask', taskId]);
  }

  confirmDelete(taskId: number): void {
    if (confirm('Are you sure want to delete ?')) {
      this.taskId = taskId;
      this.deleteTask();
    }
  }

  deleteTask(): void {
    this.taskService.deleteTask(this.taskId).subscribe({
      next: (response) => {
        if (response.success) {
          this.loadTasks();
        } else {
          alert(response.message);
        }
      },
      error: (err) => {
        alert(err.error.message);
      },
      complete: () => {
        console.log("Completed");
      }
    })
  }
}
