import { Component, OnInit } from '@angular/core';
import { DecodeJwtDataService } from '../Services/decode-jwt-data.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navigation-bar',
  templateUrl: './navigation-bar.component.html',
  styleUrls: ['./navigation-bar.component.css']
})
export class NavigationBarComponent implements OnInit {

  constructor(private decodeService:DecodeJwtDataService, private router:Router) { }
  isLoggedIn = false;

  ngOnInit() {
    this.rola = this.decodeService.getRoleFromToken();
    if(this.rola != "")
    {
      console.log('rola nije prazna');
      console.log(this.rola);
      this.isLoggedIn = true;
    }
     
  }

  LogOut(){
    this.isLoggedIn = false;
    this.rola="";
    localStorage.removeItem('token');   
    this.router.navigate(['/home']); 
  }

  rola = "";
}
