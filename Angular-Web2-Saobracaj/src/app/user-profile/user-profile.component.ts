import { Component, OnInit } from '@angular/core';
import { UserService } from '../Services/user.service';
import { korisnik } from '../Models/korisnik.model';
import { NgForm } from '@angular/forms';
import { DecodeJwtDataService } from '../Services/decode-jwt-data.service';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {

  constructor(private userService: UserService, private decoder:DecodeJwtDataService) { }

  user = new korisnik();
  email;
  datum;
  selectedFile;
  still = "";
  passwordMismatch = false;
  NewPassword = "";
  ConfirmPassword = "";

  ngOnInit() {
    this.email = this.decoder.getEmailFromToken();
    this.getData();
  }

  getData(){
    this.userService.getUserData(this.email).subscribe(result =>{
      this.user = result;
      switch(this.user.Status){
        case "Potvrdjen": 
          this.still = "green";
          break;
        case "Odbijen":
          this.still = "red";
          break;
        case "Expecting verification":
          this.still = "orange";
          break;
      }

      let datum = new Date(result.DatumRodjenja);
      let mesec = datum.getMonth() + 1;
      let formatMonth = mesec.toLocaleString().length < 2 ? '0' : '';
      let formatDay = datum.getDate().toLocaleString().length < 2 ? '0' : '';
      this.user.DatumRodjenja = datum.getFullYear()+'-' + formatMonth + mesec +'-'+formatDay+ datum.getDate();
    }, 
    error=>{
      console.log("error: " + error);
    })
  }

  onSaveChangesClicked(f:NgForm){
    // if(this.NewPassword != "" || this.ConfirmPassword!="")
    // {
    //   console.log(this.NewPassword);
    //   console.log(this.ConfirmPassword);
    //   console.log('ima nesto u pasvordima');
    //     if(this.NewPassword != this.ConfirmPassword)
    //     {
    //       console.log('mismatch');
    //       this.passwordMismatch=true;
    //       return;
    //     }
    //     else{
    //       this.passwordMismatch = false;
    //     }
    // }
    this.userService.saveUserChanges(this.user).subscribe(res =>
      {
        if(this.selectedFile != null)
        {
          let imageData = new FormData;
          imageData.append('file', this.selectedFile, this.selectedFile.name);
          this.userService.uploadImage(imageData, this.user.Email).subscribe(res=>{
            this.getData(); //ne prikazuje novu sliku jer je browser iskesirao staru pod istim imenom
          });          
        }

        
        // data.append('NewPassword', this.tbPassword);
        // data.append('ConfirmPassword', this.tbPasswordConfirm);
        this.userService.changePassword(f).subscribe(res =>{
          console.log(res);
        }, error=>{console.log(error)});

        
      });
  }

  onFileSelected(event)
  {
      this.selectedFile = <File>event.target.files[0];
  }

}
