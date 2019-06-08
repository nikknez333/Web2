import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { NgForm, NgModelGroup, NgModel } from '@angular/forms';
import { Observable } from 'rxjs';
import { headersToString } from 'selenium-webdriver/http';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  constructor(private http:HttpClient) { }

register(form: NgForm) : Observable<any> {    
    var data = "userName=" +'username'+ "&password=" +'password'+ "&grant_type=password";
    return this.http.post('http://localhost:52295/api/account/register', form.value);
}

uploadImage(data: FormData, email:string){
    return this.http.post('http://localhost:52295/api/account/UploadImage?email='+email, data).subscribe((val) => {
      console.log(val);
    });
}

}
