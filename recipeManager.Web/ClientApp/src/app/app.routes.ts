import { Routes } from '@angular/router';
import { TestComponent } from './components/test/test.component';
import { RecipesComponent } from './components/recipes/recipes.component';

export const routes: Routes = [
  { path: "", component: RecipesComponent, pathMatch: "full" },
  { path: "test", component: TestComponent, pathMatch: "full" },
];
