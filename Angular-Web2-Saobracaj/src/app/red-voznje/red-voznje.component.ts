import { Component, OnInit } from '@angular/core';
import { RedVoznjeService } from '../Services/red-voznje.service';

@Component({
  selector: 'app-red-voznje',
  templateUrl: './red-voznje.component.html',
  styleUrls: ['./red-voznje.component.css']
})
export class RedVoznjeComponent implements OnInit {

  polasci: string[];
  tipSaobracaja = '';
  tipDana = '';
  linija = '';

  linije : string[];
  tipoviDana : string[];
  tipoviSaobracaja : string[];
  
  constructor(private rvService: RedVoznjeService) { }

  ngOnInit() {
    //this.getPolasci();
    this.getInitialData();
  }

  getInitialData(): void{
    this.rvService.getInitialData().subscribe(res => {

      var info = JSON.parse(JSON.stringify(res));
      this.linije = info.Linije;
      this.tipoviDana = info.Dani;
      this.tipoviSaobracaja = info.Saobracaji;
    });
  }

  getPolasci(): void{
    this.rvService.getPolasci(this.tipSaobracaja, this.tipDana, this.linija)
    .subscribe(polasci => this.polasci = polasci);
  }

  onSubmit(): void{
    this.getPolasci();
  }

}
