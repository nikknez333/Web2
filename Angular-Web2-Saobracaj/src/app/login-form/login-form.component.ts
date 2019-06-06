import { Component, OnInit } from '@angular/core';
import { LoginService } from '../Services/login.service';
import { Routes, RouterModule } from '@angular/router';
import {Router} from "@angular/router"
import { AppRoutingModule } from '../app-routing.module';


@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent implements OnInit {

  constructor(private loginService: LoginService, private router: Router) { }

  ngOnInit() {
  }

  username = '';
  password = '';

  onSubmit(): void{
    this.loginService.login(this.username, this.password).subscribe(res => 
      {
        var accessToken = res.access_token;
        localStorage.setItem('token', accessToken);
        
        this.router.navigate(['/home']);

      }, error => {
        console.log(error);
      });
  }

}
