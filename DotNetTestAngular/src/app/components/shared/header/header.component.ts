import { ChangeDetectorRef, Component } from '@angular/core';
import { AuthService } from '../../../services/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent {

  isAuthenticated: boolean = false;

  username: string | null | undefined;
  userRoleId: string | null | undefined;

  constructor(private authService: AuthService, private cdr: ChangeDetectorRef) { }

  ngOnInit(): void {
    this.authService.isAuthenticated().subscribe((authState: boolean) => {
      this.isAuthenticated = authState;
      this.cdr.detectChanges();
    });
    this.authService.getUsername().subscribe((username: string | null | undefined) => {
      this.username = username;
      this.cdr.detectChanges()
    });
    this.authService.getUserRoleId().subscribe((userRoleId: string | null | undefined) => {
      this.userRoleId = userRoleId;
      this.cdr.detectChanges()
    });
  }

  signOut() {
    this.authService.signOut();
  }

}
