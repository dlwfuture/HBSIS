import { Injectable } from '@angular/core';
import { Component, NgModule } from '@angular/core';
import { Http, Headers, RequestOptions } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { Observable } from 'rxjs/Observable';
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
import { SharedServices } from '../shared/shared.services';

@Component({
    selector: 'listagem',
    templateUrl: "./listagem.component.html"
})
export class ListagemComponent {
    Url: string = "http://localhost/Teste_Hbsis.WebApi/api/Cliente/GetClientes";
    Http: Http;
    SharedServices: SharedServices;
    constructor(http: Http, sharedSevices: SharedServices) {
        this.Http = http;
        this.SharedServices = sharedSevices;
        this.SharedServices.GetListagem().subscribe(data => { this.ListagemModel = data.json().Return; });
    }

    public ListagemModel = [{
        Codigo: 0,
        Nome: "Daniel",
        Documento: "376.040.898-28",
        Telefone: "(19) 3245-0892",
        Excluido: false}];
}
