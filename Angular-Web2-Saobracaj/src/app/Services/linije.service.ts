import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { linija } from '../Models/linija.model';

@Injectable({
  providedIn: 'root'
})
export class LinijeService {

  constructor(private http:HttpClient) { }

  getLinija(broj): Observable<linija>{
    return this.http.get<linija>('http://localhost:52295/api/Linijas?broj='+broj);
  }
}
