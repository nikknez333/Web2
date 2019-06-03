import { Component, OnInit } from '@angular/core';
import { LoginService } from '../Services/login.service';


@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent implements OnInit {

  constructor(private loginService: LoginService) { }

  ngOnInit() {
  }

  username = '';
  password = '';

  onSubmit(): void{
    this.loginService.login(this.username, this.password).subscribe(res => 
      {
        var accessToken = res.access_token;
        localStorage.setItem('token', accessToken);
      });
  }

}
