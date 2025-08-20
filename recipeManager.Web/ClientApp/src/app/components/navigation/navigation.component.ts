import {Component, ViewChild} from '@angular/core';
import { ThemeService } from '../../common/services/theme.service';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { SidebarComponent } from './sidebar/sidebar.component';
import { UserInfoComponent } from './user-info/user-info.component';

@Component({
  standalone: true,
  selector: 'app-nav',
  imports: [CommonModule, RouterLink, SidebarComponent, UserInfoComponent],
  templateUrl: './navigation.component.html',
  styleUrl: './navigation.component.scss',
})
export class NavigationComponent {
  isSideBarOpened: boolean = false;
  @ViewChild(SidebarComponent) sidebar!: SidebarComponent;
  @ViewChild(UserInfoComponent) userInfo!: UserInfoComponent;


  constructor(private themeService: ThemeService) { }

  get isDark(): boolean {
    return this.themeService.isDarkMode();
  }

  toggleTheme() {
    this.themeService.toggleTheme();
  }

  toggleSideBar() {
    this.sidebar.toggleSidebar()
  }

  toggleUserInfo() {
    this.userInfo.toggleUserInfo()
  }
}
