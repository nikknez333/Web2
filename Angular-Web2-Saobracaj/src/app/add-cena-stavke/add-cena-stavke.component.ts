import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AdminService } from '../Services/admin.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-cena-stavke',
  templateUrl: './add-cena-stavke.component.html',
  styleUrls: ['./add-cena-stavke.component.css']
})
export class AddCenaStavkeComponent implements OnInit {

  constructor(private adminService:AdminService, private router:Router) { }

  ngOnInit() {
  }

  onSubmit(f:NgForm){
    this.adminService.addCenaStavke(f).subscribe(res =>{
      this.router.navigate(['/managment'])
    }, error=>{console.log(error)})
  }

}
