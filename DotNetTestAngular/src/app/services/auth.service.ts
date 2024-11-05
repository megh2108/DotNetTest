import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { RegisterUser } from '../models/registeruser.model';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { ApiResponse } from '../models/ApiResponse{T}';
import { LocalStorageKeys } from './helpers/localstoragekeys';
import { LocalstorageService } from './helpers/localstorage.service';
import { User } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {


  private apiUrl = 'http://localhost:5031/api/Auth/';

  constructor(private http: HttpClient, private localStorageHelper: LocalstorageService, private router: Router) { }

  private authState = new BehaviorSubject<boolean>(this.localStorageHelper.hasItem(LocalStorageKeys.TokenName));

  private usernameSubject = new BehaviorSubject<string | null | undefined>(this.localStorageHelper.getItem(LocalStorageKeys.UserName));
  private userRoleIdSubject = new BehaviorSubject<string | null | undefined>(this.localStorageHelper.getItem(LocalStorageKeys.UserRoleId));
  private userIdSubject = new BehaviorSubject<string | null | undefined>(this.localStorageHelper.getItem(LocalStorageKeys.UserId));

  getAllUsers(): Observable<ApiResponse<User[]>> {
    return this.http.get<ApiResponse<User[]>>(this.apiUrl + 'GetAllUsers');
  }

  signUp(user: RegisterUser): Observable<ApiResponse<string>> {
    const body = user;
    return this.http.post<ApiResponse<string>>(this.apiUrl + "Register", body);
  }


  signIn(username: string, password: string): Observable<ApiResponse<string>> {
    const body = { username, password };
    return this.http.post<ApiResponse<string>>(this.apiUrl + "Login", body).pipe(
      tap(response => {
        if (response.success) {

          const token = response.data;

          const payload = token.split('.')[1];
          const decodedPayload = JSON.parse(atob(payload));
          const userRoleId = decodedPayload.UserRoleId;
          const userId = decodedPayload.UserId;

          this.localStorageHelper.setItem(LocalStorageKeys.TokenName, token);
          this.localStorageHelper.setItem(LocalStorageKeys.UserName, username);
          this.localStorageHelper.setItem(LocalStorageKeys.UserRoleId, userRoleId);
          this.localStorageHelper.setItem(LocalStorageKeys.UserId, userId);

          //this.authState.next(true);


          this.authState.next(this.localStorageHelper.hasItem(LocalStorageKeys.TokenName));
          this.usernameSubject.next(username);
          this.userRoleIdSubject.next(userRoleId);
          this.userIdSubject.next(userId);
        }
      }),
    );
  }

  signOut() {
    this.localStorageHelper.removeItem(LocalStorageKeys.TokenName);
    this.localStorageHelper.removeItem(LocalStorageKeys.UserName);
    this.localStorageHelper.removeItem(LocalStorageKeys.UserRoleId);
    this.localStorageHelper.removeItem(LocalStorageKeys.UserId);
    this.router.navigate(['/signin']);
    this.authState.next(false);
    this.usernameSubject.next(null);
    this.userRoleIdSubject.next(null);
    this.userIdSubject.next(null);
  }

  getUsername(): Observable<string | null | undefined> {
    return this.usernameSubject.asObservable();
  }
  getUserRoleId(): Observable<string | null | undefined> {
    return this.userRoleIdSubject.asObservable();
  }
  getUserId(): Observable<string | null | undefined> {
    return this.userIdSubject.asObservable();
  }

  isAuthenticated() {
    return this.authState.asObservable();
  }


}
