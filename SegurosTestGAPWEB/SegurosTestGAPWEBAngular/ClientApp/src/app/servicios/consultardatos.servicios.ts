import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class PhttpService {
    //"http://localhost:10080/rest/aigrodata.php";
    //"https://aigro.com.co/rest/aigrodata.php";
    //private ip: string = "http://localhost:10080/rest/";
    private ip: string = "https://localhost:44320/v1/";

    constructor(private http: HttpClient) { }

    consultarListas(): Observable<ResponseG[]> {
        const httpOptions = {
            headers: new HttpHeaders({
                'Access-Control-Allow-Origin': '*'
            })
        };
        let listas = this.ip + "TipoCubrimientos" ;
        return this.http.get<ResponseG[]>(listas, httpOptions);
    }
}

export class ResponseG {
    public nombre: String;
}
