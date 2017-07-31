import { Injectable } from "@angular/core";
import { Component, NgModule } from '@angular/core';
import { Http, Headers, RequestOptions } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs/Subject';
import 'rxjs/add/observable/of';
import 'rxjs/add/observable/throw';

// Observable operators
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/debounceTime';
import 'rxjs/add/operator/distinctUntilChanged';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/filter';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/switchMap';

@Injectable()
export class SharedServices {
    Url: string = "http://localhost/Teste_Hbsis.WebApi/api/Cliente/GetClientes";
    Http: Http;
    constructor(http: Http) {
        this.Http = http;
        this.GetListagem();
    }
    private data1 = new Subject();


    private handleErrorObservable(error: Response | any): any {
        console.error(error.message || error);
        return;
    }

    public GetListagem(): Observable<any> {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers, url: this.Url });
        return this.Http.get(this.Url, options);
    }

    public ListagemModel = [{
        Codigo: 0,
        Nome: "Daniel",
        Documento: "376.040.898-28",
        Telefone: "(19) 3245-0892",
        Excluido: false
    }];
}