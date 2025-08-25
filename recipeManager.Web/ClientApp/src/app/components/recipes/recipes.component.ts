import {Component, OnInit, Inject, ViewEncapsulation, inject} from '@angular/core';
import { AboutComponent } from "../about/about.component";
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatDialog, MatDialogModule, MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatPaginatorModule,MatPaginatorIntl, PageEvent } from '@angular/material/paginator';
import {RecipesService} from './recipes.service';
import {PaginatedList, Recipe} from '../../models/recipe.model';

@Component({
  selector: 'app-recipes',
  standalone: true,
  imports: [
    CommonModule,
    MatCardModule,
    MatButtonModule,
    MatIconModule,
    MatDialogModule,
    MatPaginatorModule,
    AboutComponent
  ],
  templateUrl: './recipes.component.html',
  styleUrl: './recipes.component.scss',
})
export class RecipesComponent implements OnInit {
  recipes: PaginatedList<Recipe>[] = [];
  pageSize: number = 12;
  currentPage: number = 1;
  private paginator = inject(MatPaginatorIntl);
  recipesService = inject(RecipesService);

  ngOnInit(): void {
    this.GetRecipesPaginated();
    this.russifyPaginator();
  }

  private GetRecipesPaginated(){
    this.recipesService.getRecipesPaginated(this.currentPage, this.pageSize);
    console.log(this.recipesService.recipes())
  }
  private russifyPaginator() {
    this.paginator.itemsPerPageLabel = 'Элементов на странице';
    this.paginator.nextPageLabel = 'Следующая  страница';
    this.paginator.previousPageLabel = 'Предыдущая страница';
  }

  onPageChange(event: PageEvent): void {
    this.currentPage = event.pageIndex;
    this.pageSize = event.pageSize;
    this.GetRecipesPaginated();
  }

  toggleSave(recipe: Recipe): void {
    //if unauthorized - need to authorize, otherwise - add to favorites
    recipe.isSaved = !recipe.isSaved;
    // Empty method as requested
  }

}

