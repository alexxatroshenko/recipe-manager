import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TestService {
  private apiUrl = '/api/weatherforecast'
  constructor(private http: HttpClient) { }

  testGet(){
    return this.http.get(this.apiUrl);
  }
}
