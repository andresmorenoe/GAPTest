import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-clientes',
  templateUrl: './clientes.component.html',
  styleUrls: ['./clientes.component.css']
})
export class ClientesComponent implements OnInit {
  displayedColumns = ['id', 'title', 'state', 'url', 'created_at', 'updated_at', 'actions'];
  //exampleDatabase: DataService | null;
  //dataSource: ExampleDataSource | null;
  dataSource = new MatTableDataSource<PeriodicElement>(ELEMENT_DATA);
  index: number;
  id: number;
  existeCliente: boolean;
  documento: string;


  constructor() { }

  ngOnInit() {
  }

  formControl = new FormControl('', [
    Validators.required
    // Validators.email,
  ]);

  getErrorMessage() {
    return this.formControl.hasError('required') ? 'Required field' :
      this.formControl.hasError('email') ? 'Not a valid email' :
        '';
  }

  onSearch(documento: string) {
    this.existeCliente = false;
    if (documento == '123') {
      this.existeCliente = true;
    }     
  }

  submit() {
    // emppty stuff
  }

}

export interface PeriodicElement {
  tipoDocumento: string;
  numeroDocumento: string;
  nombres: string;
  apellidos: string;
  email: string;
}

const ELEMENT_DATA: PeriodicElement[] = [

];

