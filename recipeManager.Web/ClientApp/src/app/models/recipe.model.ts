export class Recipe {
  id: number = 0;
  title: string = '';
  description: string = '';
  cookingTime: number = 0;
  tags: string[] = [];
  isSaved: boolean = false;
  likesCount: number = 0;
  commentsCount: number = 0;
  author: string = '';
  created: Date = new Date();
}

export class PaginatedList<T> {
  items: T[] = [];
  pageNumber: number = 1;
  totalCount: number = 0;
  totalPages: number = 0;
}
