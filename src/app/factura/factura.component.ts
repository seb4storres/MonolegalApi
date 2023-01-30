import { Component, OnInit } from '@angular/core';
import { FacturaService } from '../services/factura.service';
import { FacturasCliente } from '../Models/Facturas';

@Component({
  selector: 'app-factura',
  templateUrl: './factura.component.html',
  styleUrls: ['./factura.component.css']
})
export class FacturaComponent implements OnInit{

    
    public columnas: string[]= ['id', 'name', 'codigoFactura', 'ciudad', 'totalFactura', 'subtotal', 'iva', 'estado', 'pagada'];
    public facturas: FacturasCliente []=[];
    constructor (private monolegal: FacturaService ){
      
      

  }
    ngOnInit(): void {
       this.getFacturas();
    }
      
    getFacturas(){
      this.monolegal.getFacturas().subscribe( response => {
        this.facturas= response;
      } )
    }
    
    
    
}
