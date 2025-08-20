import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormArray, ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatChipsModule } from '@angular/material/chips';
import { MatDividerModule } from '@angular/material/divider';
import {MatTooltip} from '@angular/material/tooltip';

interface Ingredient {
  name: string;
  quantity: string;
}

export class CustomErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: any): boolean {
    return !!(control && control.invalid && control.touched);
  }
}

@Component({
  selector: 'app-create-recipe',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule,
    MatChipsModule,
    MatDividerModule,
    MatTooltip
  ],
  templateUrl: './create-recipe.component.html',
  styleUrl: './create-recipe.component.scss'
})
export class CreateRecipeComponent implements OnInit {
  recipeForm: FormGroup;
  tags: string[] = [];
  currentTag: string = '';
  imagePreview: string | ArrayBuffer | null = null;
  maxFileSize = 5 * 1024 * 1024; // 5MB in bytes
  matcher = new CustomErrorStateMatcher();

  constructor(
    private fb: FormBuilder,
    private router: Router
  ) {
    this.recipeForm = this.fb.group({
      title: ['', [Validators.required, Validators.maxLength(30)]],
      shortDescription: ['', [Validators.required, Validators.maxLength(100)]],
      ingredients: this.fb.array([]),
      tags: [[]],
      fullDescription: ['', Validators.required],
      image: [null]
    });
  }

  ngOnInit(): void {
    this.addIngredient();
  }

  get ingredients(): FormArray {
    return this.recipeForm.get('ingredients') as FormArray;
  }

  addIngredient(): void {
    const ingredientGroup = this.fb.group({
      name: ['', Validators.required],
      quantity: ['', Validators.required]
    });
    this.ingredients.push(ingredientGroup);
  }

  removeIngredient(index: number): void {
    if (this.ingredients.length > 1) {
      this.ingredients.removeAt(index);
    }
  }

  addTag(): void {
    if (this.currentTag.trim() && this.tags.length < 10 && !this.tags.includes(this.currentTag.trim())) {
      this.tags.push(this.currentTag.trim());
      this.currentTag = '';
      this.recipeForm.patchValue({ tags: this.tags });
    }
  }

  removeTag(tag: string): void {
    const index = this.tags.indexOf(tag);
    if (index >= 0) {
      this.tags.splice(index, 1);
      this.recipeForm.patchValue({ tags: this.tags });
    }
  }

  onImageSelected(event: any): void {
    const file: File = event.target.files[0];
    if (file) {
      if (file.size > this.maxFileSize) {
        alert('Размер файла превышает 5 МБ. Пожалуйста, выберите файл меньшего размера.');
        return;
      }

      if (file.type.match('image.*')) {
        const reader = new FileReader();
        reader.onload = () => {
          this.imagePreview = reader.result;
          this.recipeForm.patchValue({ image: file });
        };
        reader.readAsDataURL(file);
      } else {
        alert('Пожалуйста, выберите файл изображения.');
      }
    }
  }
  closeImagePreview(){
    this.imagePreview = null;
}
  onSubmit(): void {
    if (this.recipeForm.valid) {
      // Here you would typically send the data to your backend
      console.log('Recipe data:', this.recipeForm.value);
      console.log('Tags:', this.tags);

      // For now, we'll just navigate back to the recipes page
      // In a real app, you would handle the form submission properly
      this.router.navigate(['/']);
    } else {
      // Mark all fields as touched to show validation errors
      this.markFormGroupTouched();
    }
  }

  onCancel(): void {
    this.router.navigate(['/']);
  }

  private markFormGroupTouched(): void {
    Object.keys(this.recipeForm.controls).forEach(key => {
      const control = this.recipeForm.get(key);
      if (control) {
        if (control instanceof FormArray) {
          control.controls.forEach(c => c.markAsTouched());
        } else {
          control.markAsTouched();
        }
      }
    });
  }
  getErrorMessage(fieldName: string): string {
    const field = this.recipeForm.get(fieldName);
    if (field?.errors?.['required']) {
      return 'Это поле обязательно для заполнения';
    }
    if (field?.errors?.['maxlength']) {
      if (fieldName === 'title') {
        return 'Название не должно превышать 30 символов';
      }
      if (fieldName === 'shortDescription') {
        return 'Краткое описание не должно превышать 100 символов';
      }
    }
    return '';
  }
}
