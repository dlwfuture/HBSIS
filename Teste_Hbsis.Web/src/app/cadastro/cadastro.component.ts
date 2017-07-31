import { Injectable } from '@angular/core';
import { Component, NgModule, Input, Output, EventEmitter  } from '@angular/core';
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
    selector: 'cadastro',
    templateUrl: "./cadastro.component.html"
})
export class CadastroComponent {
    Url: string = "http://localhost/Teste_Hbsis.WebApi/api/Cliente/AddCliente";
    public CadastroModel: Cliente;
    SharedServices: SharedServices;
    Http: Http;
    constructor(http: Http, sharedSevices: SharedServices) {
        this.CadastroModel = new Cliente();
        this.Http = http;
        this.SharedServices = sharedSevices;
    }


    private handleErrorObservable(error: Response | any): any {
        console.error(error.message || error);
        return;
    }

    Limpar(): void {
        this.CadastroModel = new Cliente();
    }

    NotifyEmit(): void {
        this.SharedServices.GetListagem();
    }

    Salvar(): void{
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let model: string = JSON.stringify(this.CadastroModel);
        let options = new RequestOptions({ headers: headers, url: this.Url, body: model });
        this.Http.post(this.Url, model, options)
            .subscribe((x) => this.NotifyEmit());
        this.Limpar();
    }
}
export class Cliente {
    constructor(codigo: number = null, nome: string = null, documento: string = null, telefone: string = null, excluido: boolean = false, isCpf: boolean = true) {
        this.Codigo = codigo;
        this.Documento = documento;
        this.Excluido = excluido;
        this.IsCpf = isCpf;
        this.Nome = nome;
        this.Telefone = telefone;
    }
    Codigo: number;
    Nome: string;
    Documento: string;
    Telefone: string;
    Excluido: boolean;
    IsCpf: boolean;
}