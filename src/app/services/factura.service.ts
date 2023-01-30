import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { FacturasCliente } from '../Models/Facturas';

@Injectable({
  providedIn: 'root'
})
export class FacturaService {

  url: string = 'https://localhost:44357/api/Factura'

  constructor(
    private _http: HttpClient
  ) { }

  public getFacturas(): Observable<FacturasCliente[]> {
    return this._http.get<FacturasCliente[]> (this.url);
  }
}
