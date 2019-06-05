import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { RegisterService } from '../Services/register.service';

@Component({
  selector: 'app-register-form',
  templateUrl: './register-form.component.html',
  styleUrls: ['./register-form.component.css']
})
export class RegisterFormComponent implements OnInit {

  constructor(private registerService: RegisterService) { }

  ngOnInit() {
  }

  onSubmit(f:NgForm): void{
    this.registerService.register(f).subscribe(res => {
      console.log(res);
    });
  }
}
