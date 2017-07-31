import { NgModule, Input, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';  
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule, Headers, RequestOptions } from '@angular/http';
import { AppComponent } from './app.component';
import { Observable } from 'rxjs/Observable';
import 'rxjs/Rx';

import { SharedServices } from './shared/shared.services';
import { CadastroComponent } from './cadastro/cadastro.component';
import { ListagemComponent } from './listagem/listagem.component';



@NgModule({
    imports: [BrowserModule, HttpModule, FormsModule  ],
  declarations: [ AppComponent, CadastroComponent, ListagemComponent ],
  bootstrap: [AppComponent],
  providers: [SharedServices]
})
export class AppModule { }
