import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { RegisterService } from '../Services/register.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register-form',
  templateUrl: './register-form.component.html',
  styleUrls: ['./register-form.component.css']
})
export class RegisterFormComponent implements OnInit {
  selectedFile: File = null;

  constructor(private registerService: RegisterService, private router:Router) { }

  ngOnInit() {
  }


  onSubmit(f:NgForm): void{
    this.registerService.register(f).subscribe(res => {
      if(this.selectedFile != null)
      {
        let imageData = new FormData;
        imageData.append('file', this.selectedFile, this.selectedFile.name);
        this.registerService.uploadImage(imageData, f.value.Email);
      }
      //display notification "successful register" and redirect to Login page
      this.router.navigate(['/login']);
    });
    
  }

  onFileSelected(event)
  {
      this.selectedFile = <File>event.target.files[0];
  }
}
