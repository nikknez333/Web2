import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { korisnik } from '../Models/korisnik.model';
import { Observable } from 'rxjs';
import { NgForm } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http:HttpClient) { }

  getUserData(email): Observable<korisnik>{
    return this.http.get<korisnik>('http://localhost:52295/api/Korisniks?id='+email);
  }

  saveUserChanges(user): any{
    return this.http.put('http://localhost:52295/api/Korisniks?id='+user.Email, user);
  }

  uploadImage(data: FormData, email:string):any{
    return this.http.post('http://localhost:52295/api/account/UploadImage?email='+email, data).subscribe((val) => {
    });
  }

  changePassword(data:NgForm):any{
    return this.http.post('http://localhost:52295/api/Account/ChangePassword', data.value);
  }
}
