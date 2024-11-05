import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiResponse } from '../models/ApiResponse{T}';
import { Projects } from '../models/peoject.model';

@Injectable({
  providedIn: 'root'
})
export class ProjectService {

  private apiUrl = 'http://localhost:5031/api/Project/';

  constructor(private http: HttpClient) { }

  getAllProjects(): Observable<ApiResponse<Projects[]>> {
    return this.http.get<ApiResponse<Projects[]>>(this.apiUrl + 'GetAllProjects');
  }
}
