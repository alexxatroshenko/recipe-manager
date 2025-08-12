import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { LoginDialogComponent } from './login-dialog/login-dialog.component';
import { RegisterDialogComponent } from './register-dialog/register-dialog.component';

@Component({
  standalone: true,
  selector: 'app-user-info',
  imports: [],
  templateUrl: './user-info.component.html',
  styleUrl: './user-info.component.scss'
})
export class UserInfoComponent {
  isOpened: boolean = false;

  constructor(private dialog: MatDialog) { }

  toggleUserInfo() {
    this.isOpened = !this.isOpened;
  }

  closeInfo() {
    console.log("clos info")
    this.isOpened = false;
  }

  openLoginDialog(): void {
    this.dialog.open(LoginDialogComponent, {
      width: '350px',
      panelClass: 'custom-dialog-container'
    });
  }

  openRegisterDialog(): void {
    this.dialog.open(RegisterDialogComponent, {
      width: '400px',
      panelClass: 'custom-dialog-container'
    });
  }
}
