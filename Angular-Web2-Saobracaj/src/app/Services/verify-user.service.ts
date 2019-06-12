import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { RegStatus } from '../Models/RegStatus.model';

@Injectable({
  providedIn: 'root'
})
export class VerifyUserService {

  constructor(private http:HttpClient) { }

  getAccounts(): Observable<RegStatus[]> {
     return this.http.get<RegStatus[]>('http://localhost:52295/api/RegistrationStatus');
      // console.log('iz servisa: '+ d);
      // return d;
  }

  verifyUser(email): any{
    let user = new RegStatus();
    user.UserEmail = email;
    user.Status = "Potvrdjen";
    //console.log('putovao serivs');
    return this.http.put("http://localhost:52295/api/RegistrationStatus?id="+email, user);
  }

  denyUser(email):any{
    let user = new RegStatus();
    user.UserEmail = email;
    user.Status = "Odbijen";
    return this.http.put("http://localhost:52295/api/RegistrationStatus?id="+email, user);
  }

  
}
