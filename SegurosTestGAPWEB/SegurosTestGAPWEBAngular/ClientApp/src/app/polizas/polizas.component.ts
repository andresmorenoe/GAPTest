import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { PhttpService } from '../servicios/consultardatos.servicios';

@Component({
  selector: 'app-polizas',
  templateUrl: './polizas.component.html',
    styleUrls: ['./polizas.component.css'],
    providers: [PhttpService]
})
export class PolizasComponent implements OnInit {

    constructor(private phttp: PhttpService) { }

    tipoCubrimiento: string;

    tiposCubrimientos = [];

    ngOnInit() {
        this.phttp.consultarListas().subscribe((data) => {
            console.log(data);
            for (let tipo in data) {
                this.tiposCubrimientos.push(tipo["nombre"]);
            }
            console.log(this.tiposCubrimientos);
        })
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


}
