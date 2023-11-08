import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { ReactiveFormsModule } from '@angular/forms';
import { ModalModule } from 'ngx-bootstrap/modal';

import { AeroportosService } from './services/Aeroportos/aeroportos.service';
import { AeroportosComponent } from './components/aeroportos/aeroportos.component';

import { AvioesService } from './services/Aviaos/avioes.service';
import { AvioesComponent } from './components/avioes/avioes.component';

import { CompanhiaAereasService } from './services/CompanhiaAereas/companhias-aereas.service';
import { CompanhiaAereasComponent } from './components/companhia-aereas/companhia-aereas.component';

import { FuncionariosService } from './services/Funcionarios/funcionarios.service';
import { FuncionariosComponent } from './components/funcionarios/funcionarios.component';

import { BagagensService } from './services/Bagagems/bagagens.service';
import { BagagemsComponent } from './components/bagagems/bagagems.component';

import { PagamentosService } from './services/Pagamentos/pagamentos.service';
import { PagamentosComponent } from './components/pagamentos/pagamentos.component';

import { PassageirosService } from './services/Passageiros/passageiros.service';
import { PassageirosComponent } from './components/passageiros/passageiros.component';

import { PassagensService } from './services/Passagems/passagens.service';
import { PassagemsComponent } from './components/passagems/passagems.component';

import { PortoesService } from './services/Portaos/portoes.service';
import { PortaosComponent } from './components/portaos/portaos.component';

import { VoosService } from './services/Voos/voos.service';
import { VoosComponent } from './components/voos/voos.component';


@NgModule({
  declarations: [AppComponent, AeroportosComponent, AvioesComponent, BagagemsComponent, CompanhiaAereasComponent, FuncionariosComponent, PagamentosComponent, PassagemsComponent, BagagemsComponent, PortaosComponent, VoosComponent, PassageirosComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    ModalModule.forRoot(),
  ],
  providers: [
    AeroportosService,
    AvioesService,
    BagagensService,
    CompanhiaAereasService,
    FuncionariosService,
    PagamentosService,
    PassageirosService,
    PassagensService,
    PortoesService,
    VoosService,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
