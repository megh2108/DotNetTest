import { ChangeDetectorRef, Component } from '@angular/core';
import { AuthService } from '../../../services/auth.service';
import { Router } from '@angular/router';
import { LocalstorageService } from '../../../services/helpers/localstorage.service';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrl: './signin.component.css'
})
export class SigninComponent {
  username: string = '';
  password: string = '';

  constructor(private authService: AuthService, private localStorageHelper: LocalstorageService, private router: Router, private cdr: ChangeDetectorRef) { }

  login() {
    this.authService.signIn(this.username, this.password).subscribe({
      next: (response) => {
        if (response.success) {

          this.cdr.detectChanges();
          this.router.navigate(['/home']);

        }
        else {
          alert(response.message);
        }
      },
      error: (err) => {
        alert(err.error.message);
      }
    });
  }
}
