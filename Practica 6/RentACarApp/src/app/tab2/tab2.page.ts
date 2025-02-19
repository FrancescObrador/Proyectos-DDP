import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { StorageService } from '../shared/storage.service';
import { ClienteService } from '../shared/cliente.service';
import { Factura } from '../shared/cliente.model';

@Component({
  selector: 'app-tab2',
  templateUrl: 'tab2.page.html',
  styleUrls: ['tab2.page.scss']
})
export class Tab2Page {

  facutra?: Factura
  constructor(
    private router: Router,
    private storage: StorageService,
    private service: ClienteService,
  ) {
    this.getData();
  }

  async getData() {
    this.facutra = await this.storage.get('currentFactura');
  }

}
