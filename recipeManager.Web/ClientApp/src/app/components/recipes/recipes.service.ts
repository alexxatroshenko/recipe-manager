import {inject, Injectable, signal} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {catchError, of, tap} from 'rxjs';
import {PaginatedList, Recipe} from '../../models/recipe.model';

@Injectable({
  providedIn: 'root'
})
export class RecipesService {
  private http = inject(HttpClient);
  recipes = signal<PaginatedList<Recipe>>({ items: [], pageNumber: 1, totalCount:0, totalPages: 0 });

  getRecipesPaginated(pageNumber: number, pageSize: number){
    this.http.get<PaginatedList<Recipe>>(`/api/recipes/GetRecipesWithPagination?pageNumber=${pageNumber}&pageSize=${pageSize}`)
      .pipe(tap(recipes => {
        this.recipes.set(recipes);
        console.log(this.recipes())
      }), catchError(error => {
        console.error(error);
        return of([]);
      })).subscribe()
  }
}
