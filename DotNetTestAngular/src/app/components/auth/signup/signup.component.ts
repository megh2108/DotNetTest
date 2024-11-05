import { Component } from '@angular/core';
import { RegisterUser } from '../../../models/registeruser.model';
import { AuthService } from '../../../services/auth.service';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrl: './signup.component.css'
})
export class SignupComponent {

  user: RegisterUser = {
    username: '',
    email: '',
    password: '',
    confirmPassword: '',
    userRoleId: 0
  }

  constructor(private authService: AuthService, private router: Router) { }

  checkPasswords(form: NgForm): void {
    const password = form.controls['password'];
    const confirmPassword = form.controls['confirmPassword'];

    if (password && confirmPassword && password.value !== confirmPassword.value) {
      confirmPassword.setErrors({ passwordMismatch: true });
    } else {
      confirmPassword.setErrors(null);
    }
  }

  onSubmit(signUpForm: NgForm): void {
    if (signUpForm.valid) {
      // this.loading = true;

      console.log(signUpForm.value);
      console.log(this.user);
      this.authService.signUp(this.user).subscribe({
        next: (response) => {
          if (response.success) {
            console.log('User added successfully:', response);
            this.router.navigate(['/signupsuccess']);
          } else {
            alert(response.message);
          }

          // this.loading = false;
        },
        error: (err) => {
          console.error(err.error.message);
          // this.loading = false;
          alert(err.error.message);
        },
        complete: () => {
          // this.loading = false;
          console.log("completed");
        }
      });
    }
  }

}
