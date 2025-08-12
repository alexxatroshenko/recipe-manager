import { Component } from '@angular/core';
import { AboutComponent } from "../about/about.component";

@Component({
  selector: 'app-recipes',
  imports: [AboutComponent],
  templateUrl: './recipes.component.html',
  styleUrl: './recipes.component.scss'
})
export class RecipesComponent {

}
