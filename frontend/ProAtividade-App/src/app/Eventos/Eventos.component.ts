import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-Eventos',
  templateUrl: './Eventos.component.html',
  styleUrls: ['./Eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos: any;

  constructor() { }

  ngOnInit() {
    this.getEventos();
  }

  public getEventos(): void{
    this.eventos = [
      {
        tema: "Angular",
        local: "Belo Horizonte"
      },
      {
        tema: ".NET",
        local: "São Paulo"
      }
    ]
  }

}
