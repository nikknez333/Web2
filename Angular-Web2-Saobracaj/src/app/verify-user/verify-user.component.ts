import { Component, OnInit } from '@angular/core';
import { VerifyUserService } from '../Services/verify-user.service';
import { RegStatus } from '../Models/RegStatus.model';
import { Observable } from 'rxjs';
import { Router, NavigationEnd } from '@angular/router';

@Component({
  selector: 'app-verify-user',
  templateUrl: './verify-user.component.html',
  styleUrls: ['./verify-user.component.css']
})
export class VerifyUserComponent implements OnInit {
  accounts: RegStatus[];

  constructor(private service: VerifyUserService, private router:Router) { }

  ngOnInit() {
    this.getAccounts();
  }

  getAccounts(){
    this.service.getAccounts()
    .subscribe(accounts => this.accounts = accounts);
  }

  onVerifyClick(email){
      this.service.verifyUser(email).subscribe(res => 
        this.getAccounts() //refresh data
        );
  }

  onDenyClick(email){
    this.service.denyUser(email).subscribe(res => 
      this.getAccounts() //refresh data
      );
  }

}
