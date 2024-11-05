import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/shared/header/header.component';
import { FooterComponent } from './components/shared/footer/footer.component';
import { HomeComponent } from './components/home/home.component';
import { SigninComponent } from './components/auth/signin/signin.component';
import { SignupComponent } from './components/auth/signup/signup.component';
import { SignupsuccessComponent } from './components/auth/signupsuccess/signupsuccess.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { TasklistComponent } from './components/task/tasklist/tasklist.component';
import { AddtaskComponent } from './components/task/addtask/addtask.component';
import { UpdatetaskComponent } from './components/task/updatetask/updatetask.component';
import { ProjectlistComponent } from './components/project/projectlist/projectlist.component';
import { AddprojectComponent } from './components/project/addproject/addproject.component';
import { UpdateprojectComponent } from './components/project/updateproject/updateproject.component';
import { AdminComponent } from './components/admin/admin.component';
import { ManagerComponent } from './components/manager/manager.component';
import { EmployeeComponent } from './components/employee/employee.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    HomeComponent,
    SigninComponent,
    SignupComponent,
    SignupsuccessComponent,
    TasklistComponent,
    AddtaskComponent,
    UpdatetaskComponent,
    ProjectlistComponent,
    AddprojectComponent,
    UpdateprojectComponent,
    AdminComponent,
    ManagerComponent,
    EmployeeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  providers: [
    provideClientHydration()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
