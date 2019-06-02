import { Component, OnInit } from '@angular/core';
import { RedVoznjeService } from '../red-voznje.service';

@Component({
  selector: 'app-red-voznje',
  templateUrl: './red-voznje.component.html',
  styleUrls: ['./red-voznje.component.css']
})
export class RedVoznjeComponent implements OnInit {

  polasci: string[];

  constructor(private rvService: RedVoznjeService) { }

  ngOnInit() {
    this.getPolasci();
  }

  getPolasci(): void{
    //this.polasci = this.rvService.getPolasci();
    this.rvService.getPolasci()
    .subscribe(polasci => this.polasci = polasci);
  }

}
