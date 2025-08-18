import {inject, Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TestService {
  private apiUrl = '/api/tests';
  private http = inject(HttpClient);
  testGet(){
    return this.http.get(this.apiUrl + "?count=5");
  }
}
