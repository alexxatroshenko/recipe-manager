import { Component } from '@angular/core';
import {ThemeService} from '../../common/services/theme.service';
import {CommonModule} from '@angular/common';

@Component({
  selector: 'app-nav',
  imports: [CommonModule],
  templateUrl: './navigation.component.html',
  styleUrl: './navigation.component.scss'
})
export class NavigationComponent {

  constructor(private themeService: ThemeService) {
  }

  get isDark(): boolean {
    return this.themeService.isDarkMode();
  }

  toggleTheme(){
    this.themeService.toggleTheme();
  }
}
