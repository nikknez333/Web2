import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { HttpParams } from "@angular/common/http";
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http: HttpClient) { }

  login(username, password): Observable<any>{

   var data = "userName=" +username+ "&password=" +password+ "&grant_type=password";
    return this.http.post('http://localhost:52295/oauth/token', data);
  }
}
