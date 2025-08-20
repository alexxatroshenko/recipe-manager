import { Routes } from '@angular/router';
import { TestComponent } from './components/test/test.component';
import { RecipesComponent } from './components/recipes/recipes.component';
import { CreateRecipeComponent } from './components/recipes/create-recipe/create-recipe.component';

export const routes: Routes = [
  { path: "", component: RecipesComponent, pathMatch: "full" },
  { path: "test", component: TestComponent, pathMatch: "full" },
  { path: "create-recipe", component: CreateRecipeComponent, pathMatch: "full" },
];
