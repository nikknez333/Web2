import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { NgForm } from '@angular/forms';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  constructor(private http:HttpClient) { }

  register(form: NgForm) : Observable<any> {
    console.log(form.value);
    var data = "userName=" +'username'+ "&password=" +'password'+ "&grant_type=password";
    return this.http.post('http://localhost:52295/api/account/register', form.value);
      
    
}
}
