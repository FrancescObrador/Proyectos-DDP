import { throwError } from 'rxjs';
import { Cliente, Factura, Reserva } from './../shared/cliente.model';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { StorageService } from '../shared/storage.service';
import { ClienteService } from '../shared/cliente.service';

@Component({
  selector: 'app-tab1',
  templateUrl: 'tab1.page.html',
  styleUrls: ['tab1.page.scss']
})
export class Tab1Page {

  cliente?: Cliente
  reservas?: Reserva[]

  constructor(
    private router: Router,
    private storage: StorageService,
    private service: ClienteService,
  ){

    this.getData();
  }

  async getData(){
    this.cliente = await this.storage.get('cliente');

    this.service.getReservas(this.cliente!.dni).subscribe((result) => {
      this.reservas = result as Reserva[];
    });
  }

  clickFactura(factura: Factura) {
    this.storage.set('currentFactura', factura);
    this.router.navigate(['/tabs/tab2']);
  }
clickReserva(reserva: Reserva) {
  this.storage.set('currentReserva', reserva);
  this.router.navigate(['/tabs/tab3']);
}
}
