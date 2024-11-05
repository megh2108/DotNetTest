import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiResponse } from '../models/ApiResponse{T}';
import { Tasks } from '../models/tasks.model';
import { AddTask } from '../models/addtask.model';

@Injectable({
  providedIn: 'root'
})
export class TaskService {

  private apiUrl = 'http://localhost:5031/api/Task/';

  constructor(private http: HttpClient) { }

  getAllTasks(): Observable<ApiResponse<Tasks[]>> {
    return this.http.get<ApiResponse<Tasks[]>>(this.apiUrl + 'GetAllTasks');
  }

  getTaskByTaskId(taskId: number | undefined): Observable<ApiResponse<Tasks>> {
    return this.http.get<ApiResponse<Tasks>>(this.apiUrl + 'GetTaskByTaskId/' + taskId);
  }

  addTask(addTask: AddTask): Observable<ApiResponse<string>> {
    return this.http.post<ApiResponse<string>>(this.apiUrl + 'AddTask', addTask);
  }

  updateTask(updateTask: Tasks): Observable<ApiResponse<string>> {
    return this.http.put<ApiResponse<string>>(this.apiUrl + 'UpdateTask', updateTask);
  }

  deleteTask(taskId: number | undefined): Observable<ApiResponse<string>> {
    return this.http.delete<ApiResponse<string>>(this.apiUrl + 'DeleteTask/' + taskId);
  }
}
