import {Component, OnInit, Inject, ViewEncapsulation} from '@angular/core';
import { AboutComponent } from "../about/about.component";
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatDialog, MatDialogModule, MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatPaginatorModule,MatPaginatorIntl, PageEvent } from '@angular/material/paginator';

interface Recipe {
  id: number;
  title: string;
  description: string;
  tags: string[];
  likes: number;
  comments: number;
  isLiked: boolean;
  isSaved: boolean;
}

interface Comment {
  id: number;
  author: string;
  text: string;
  date: string;
}

interface RecipeDetail {
  id: number;
  title: string;
  description: string;
  ingredients: string[];
  instructions: string[];
  comments: Comment[];
}

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
  encapsulation: ViewEncapsulation.None
})
export class RecipesComponent implements OnInit {
  recipes: Recipe[] = [];
  paginatedRecipes: Recipe[] = [];
  pageSize = 12;
  currentPage = 0;
  totalRecipes = 0;

  constructor(private dialog: MatDialog,private paginator: MatPaginatorIntl) { }

  ngOnInit(): void {
    this.generateMockRecipes();
    this.updatePaginatedRecipes();

    this.paginator.itemsPerPageLabel = 'Элементов на странице';
    this.paginator.nextPageLabel = 'Следующая  страница';
    this.paginator.previousPageLabel = 'Предыдущая страница';

  }

  generateMockRecipes(): void {
    const tags = ['Десерт', 'Основное блюдо', 'Завтрак', 'Вегетарианское', 'Быстрое', 'Праздничное'];
    const recipeTitles = [
      'Шоколадный торт', 'Овощной салат', 'Куриный суп', 'Борщ', 'Плов', 'Спагетти',
      'Омлет с сыром', 'Фруктовый десерт', 'Грибной суп', 'Салат Цезарь', 'Картофельное пюре',
      'Жареная курица', 'Рыба на пару', 'Свинина в соусе', 'Говядина по-строгановски',
      'Морковный торт', 'Чизкейк', 'Маффины', 'Печенье', 'Пирог с яблоками', 'Кексы',
      'Тирамису', 'Панкейки', 'Вафли', 'Круассаны', 'Сэндвич', 'Бургер', 'Пицца',
      'Суши', 'Роллы'
    ];

    this.recipes = Array.from({ length: 30 }, (_, i) => {
      const randomTags = tags.sort(() => 0.5 - Math.random()).slice(0, Math.floor(Math.random() * 3) + 1);
      return {
        id: i + 1,
        title: recipeTitles[i],
        tags: randomTags,
        likes: Math.floor(Math.random() * 100),
        comments: Math.floor(Math.random() * 50),
        isLiked: false,
        isSaved: false,
        description: 'Краткое описание рецепта'
      };
    });
    this.recipes[0].description = 'Откройте для себя мир кулинарии с YourRecipe - вашим личным помощником в создании и хранении рецептов. Просматривайте вдохновляющие рецепты, сохраняйте любимые блюда и создавайте свои кулинарные шедевры. Просто, удобно и вкусно!';
    this.recipes[1].description = 'Откройте для себя мир кулинарии с YourRecipe - вашим личным помощником в создании и хранении рецептов.'
    this.totalRecipes = this.recipes.length;
  }

  updatePaginatedRecipes(): void {
    const startIndex = this.currentPage * this.pageSize;
    this.paginatedRecipes = this.recipes.slice(startIndex, startIndex + this.pageSize);
  }

  onPageChange(event: PageEvent): void {
    this.currentPage = event.pageIndex;
    this.pageSize = event.pageSize;
    this.updatePaginatedRecipes();
  }

  toggleSave(recipe: Recipe): void {
    //if unauthorized - need to authorize, otherwise - add to favorites
    recipe.isSaved = !recipe.isSaved;
    // Empty method as requested
  }

}

