import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { HttpParams } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class RedVoznjeService {

  constructor(
    private http: HttpClient
  ) { }


  getPolasci(saobracaj:string, dan:string, linija:string): Observable<string[]> {
    let params = new HttpParams().set("saobracaj", saobracaj).set("dan", dan).set("linija", linija); //Create new HttpParams

    return this.http.get<string[]>(this.polasciUrl, {params: params});
  }

  getInitialData(): Observable<string[]>
  {
    return this.http.get<string[]>(this.polasciUrl);
  }

  private polasciUrl = 'http://localhost:52295/api/RedVoznjes'
}
