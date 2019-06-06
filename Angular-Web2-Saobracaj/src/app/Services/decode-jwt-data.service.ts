import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DecodeJwtDataService {

  constructor() { }

  getRoleFromToken():string{
    let jwt = localStorage.getItem('token');
    let rola = "";
      if( jwt != null)
      {
        let jwtData = jwt.split('.')[1];
        let decodedJwtJsonData = window.atob(jwtData);
        let decodedJwtData = JSON.parse(decodedJwtJsonData);
  
        rola = decodedJwtData.role;
      }

      return rola;
  }
}
