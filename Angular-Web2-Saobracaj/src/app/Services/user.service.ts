import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { korisnik } from '../Models/korisnik.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http:HttpClient) { }

  getUserData(user): Observable<korisnik>{
    return this.http.get<korisnik>('http://localhost:52295/api/Korisniks');
  }

  saveUserChanges(user): any{
    return this.http.put('http://localhost:52295/api/Korisniks?id='+user.Email, user);
  }

  uploadImage(data: FormData, email:string):any{
    return this.http.post('http://localhost:52295/api/account/UploadImage?email='+email, data).subscribe((val) => {
    });
}
}
