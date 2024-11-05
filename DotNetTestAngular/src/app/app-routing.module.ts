import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { SigninComponent } from './components/auth/signin/signin.component';
import { SignupComponent } from './components/auth/signup/signup.component';
import { SignupsuccessComponent } from './components/auth/signupsuccess/signupsuccess.component';
import { TasklistComponent } from './components/task/tasklist/tasklist.component';
import { AddtaskComponent } from './components/task/addtask/addtask.component';
import { UpdatetaskComponent } from './components/task/updatetask/updatetask.component';
import { ProjectlistComponent } from './components/project/projectlist/projectlist.component';
import { AddprojectComponent } from './components/project/addproject/addproject.component';
import { UpdateprojectComponent } from './components/project/updateproject/updateproject.component';
import { AdminComponent } from './components/admin/admin.component';
import { ManagerComponent } from './components/manager/manager.component';
import { EmployeeComponent } from './components/employee/employee.component';
import { managerGuard } from './guards/manager.guard';
import { adminGuard } from './guards/admin.guard';
import { employeeGuard } from './guards/employee.guard';
import { authGuard } from './guards/auth.guard';

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'signin', component: SigninComponent },
  { path: 'signup', component: SignupComponent },
  { path: 'signupsuccess', component: SignupsuccessComponent },
  { path: 'tasklist', component: TasklistComponent, canActivate: [authGuard] },
  { path: 'addtask', component: AddtaskComponent, canActivate: [authGuard] },
  { path: 'updatetask/:TaskId', component: UpdatetaskComponent, canActivate: [authGuard] },
  { path: 'projectlist', component: ProjectlistComponent, canActivate: [authGuard] },
  { path: 'addproject', component: AddprojectComponent, canActivate: [authGuard] },
  { path: 'updateproject/:ProjectId', component: UpdateprojectComponent, canActivate: [authGuard] },
  { path: 'admin', component: AdminComponent, canActivate: [adminGuard] },
  { path: 'manager', component: ManagerComponent, canActivate: [managerGuard] },
  { path: 'employee', component: EmployeeComponent, canActivate: [employeeGuard] },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
