import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { InputTextModule } from 'primeng/inputtext';
import { AtencionComponent } from './atencion/atencion.component';
import { FormsModule } from '@angular/forms';
import { FieldsetModule } from 'primeng/fieldset';
import { HttpClientModule } from '@angular/common/http';
import { PersonaService } from './persona/persona.service';
import { MessagesModule } from 'primeng/messages';
import { MessageModule } from 'primeng/message';
import { MessageService } from 'primeng/api';
import { FuncionService } from './global/funcion.service';
import { ColaPersonaService } from './cola-persona/persona.service';
import {CarouselModule} from 'primeng/carousel';
import { CdTimerModule } from 'angular-cd-timer';
import {ToastModule} from 'primeng/toast';
import {ProgressBarModule} from 'primeng/progressbar';

@NgModule({
  declarations: [
    AppComponent,
    AtencionComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    InputTextModule,
    FieldsetModule,
    HttpClientModule,
    MessagesModule,
    MessageModule,
    CarouselModule,
    CdTimerModule,
    ToastModule,
    ProgressBarModule
  ],
  providers: [
    PersonaService,
    MessageService,
    FuncionService,
    ColaPersonaService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
