import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { StorageService } from '../shared/storage.service';
import { ClienteService } from '../shared/cliente.service';
import { Reserva } from '../shared/cliente.model';

@Component({
  selector: 'app-tab3',
  templateUrl: 'tab3.page.html',
  styleUrls: ['tab3.page.scss']
})
export class Tab3Page {

  reserva?: Reserva;

  constructor(
    private router: Router,
    private storage: StorageService,
    private service: ClienteService,
  ) {
    this.getData();
  }

  async getData() {
    this.reserva = await this.storage.get('currentReserva');
  }

  getEstadoText(estado: number): string {
    switch (estado) {
      case 1: return 'Libre';
      case 2: return 'Alquilado';
      default: return 'Desconocido';
    }
  }

  getCategoriaText(categoria: number): string {
    switch (categoria) {
      case 1: return 'Económico';
      case 2: return 'Estándar';
      case 3: return 'Lujo';
      default: return 'Desconocido';
    }
  }
}
