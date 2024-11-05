import { ChangeDetectorRef, Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  username: string | null | undefined;

  constructor(private authService: AuthService, private cdr: ChangeDetectorRef) { }

  ngOnInit(): void {

    this.authService.getUsername().subscribe((username: string | null | undefined) => {
      this.username = username;
      this.cdr.detectChanges()
    });

  }
}
