import { ChangeDetectorRef, Component } from '@angular/core';
import { AddTask } from '../../../models/addtask.model';
import { Projects } from '../../../models/peoject.model';
import { Router } from '@angular/router';
import { ProjectService } from '../../../services/project.service';
import { ApiResponse } from '../../../models/ApiResponse{T}';
import { NgForm } from '@angular/forms';
import { TaskService } from '../../../services/task.service';
import { User } from '../../../models/user.model';
import { AuthService } from '../../../services/auth.service';

@Component({
  selector: 'app-addtask',
  templateUrl: './addtask.component.html',
  styleUrl: './addtask.component.css'
})
export class AddtaskComponent {


  tasks: AddTask = {
    projectId: 0,
    title: '',
    description: '',
    priority: 'Low',
    status: 'To Do',
    dueDate: null,
    assignedTo: 0,
    createdAt: new Date,
    createdBy: 0
  };

  projects: Projects[] = [];
  users: User[] = []

  userId: string | null | undefined;

  constructor(private taskService: TaskService, private authService: AuthService, private router: Router, private projectService: ProjectService, private cdr: ChangeDetectorRef) { }





  ngOnInit(): void {
    this.loadProjects();
    this.loadUsers();

    this.authService.getUserRoleId().subscribe((userId: string | null | undefined) => {
      this.tasks.createdBy = Number(userId);
      this.cdr.detectChanges()
    });
  }


  loadProjects(): void {
    this.projectService.getAllProjects().subscribe({
      next: (response: ApiResponse<Projects[]>) => {
        if (response.success) {
          this.projects = response.data;
        }
        else {
          console.error('Failed to fetch projects', response.message);
        }
      },
      error: (error => {
        console.error('Failed to fetch projects', error);
      })
    });
  }

  loadUsers(): void {
    this.authService.getAllUsers().subscribe({
      next: (response: ApiResponse<User[]>) => {
        if (response.success) {
          this.users = response.data;
          console.log(this.users);
        }
        else {
          console.error('Failed to fetch users', response.message);
        }
      },
      error: (error => {
        console.error('Failed to fetch users', error);
      })
    });
  }

  onSubmit(addTaskForm: NgForm): void {
    if (addTaskForm.valid) {

      this.taskService.addTask(this.tasks).subscribe({
        next: (response) => {
          console.log("res" + response);
          if (response.success) {
            console.log('Task added successfully:', response);
            this.router.navigate(['/tasklist']);
            // addContactForm.resetForm();
          } else {
            alert(response.message);
          }

        },
        error: (err) => {
          // console.log(err);
          console.error(err.error.message);
          alert(err.error.message);
        },
        complete: () => {
          console.log("completed");
        }

      });
    }
  }
}
