import { Component, OnInit, ViewChild } from '@angular/core';
import { CdTimerComponent } from 'angular-cd-timer';
import { Message, MessageService } from 'primeng/api';
import { lastValueFrom } from 'rxjs';
import { ColaPersona } from '../cola-persona/cola-persona';
import { ColaPersonaService } from '../cola-persona/persona.service';
import { Consulta } from '../global/consulta';
import { FuncionService } from '../global/funcion.service';
import { Persona } from '../persona/persona';
import { PersonaService } from '../persona/persona.service';

@Component({
  selector: 'app-atencion',
  templateUrl: './atencion.component.html',
  styleUrls: ['./atencion.component.scss']
})
export class AtencionComponent implements OnInit {
  @ViewChild('timerCola1') timer1: CdTimerComponent;
  @ViewChild('timerCola2') timer2: CdTimerComponent;

  identificacion: string = "";
  nombre: string = "";
  cola1: any[] = [];
  cola2: any[] = [];
  msgs: Message[];
  consulta: Consulta = new Consulta();


  constructor(
    private personaSrv: PersonaService,
    private funcionSrv: FuncionService,
    private colaPersonaSrv: ColaPersonaService,
    private messageService: MessageService
  ) {

  }

  async ngOnInit() {
    this.consulta.sentenciaSql = `Exec ReasignarHoraPersona`;
    await lastValueFrom(this.funcionSrv.getEjecutarSql(this.consulta));
    this.timer1.autoStart = false;
    this.timer1.autoStart = false;
    this.devolverCola1(0);
    this.devolverCola2(0);

    let timer1 = setInterval(() => {
      this.timer1.countdown = true;
      this.timer1.startTime = 120;
      this.timer1.stop();
      this.timer1.start();
      this.devolverCola1(0);
    },
      120000);


    let timer2 = setInterval(() => {
      this.timer2.countdown = true;
      this.timer2.startTime = 180;
      this.timer2.stop();
      this.timer2.start();
      this.devolverCola2(0);
    }, 180000);

  }


  async grabarAtencion() {
    this.msgs = [];
    var resultado: string = "";
    resultado = this.validarIngreso();
    if (resultado.length > 0) {
      this.msgs.push({ severity: 'error', summary: 'Información', detail: resultado });
      return;
    }

    var idPersona: number = 0;
    var idCola: number = 0;
    this.consulta.sentenciaSql = `Exec ValidarPersona '${this.identificacion}'`;
    idPersona = await lastValueFrom(this.funcionSrv.getDevolverInt(this.consulta));

    if (idPersona == 0) {
      var persona: Persona = new Persona();
      persona.identificacion = this.identificacion;
      persona.nombre = this.nombre;
      persona = await lastValueFrom(this.personaSrv.grabar(persona));
      idPersona = persona.idPersona;
    }

    this.consulta.sentenciaSql = `Exec AsignarPersonaCola`;
    idCola = await lastValueFrom(this.funcionSrv.getDevolverInt(this.consulta));

    var colaPersona: ColaPersona = new ColaPersona();
    colaPersona.idCola = idCola;
    colaPersona.idPersona = idPersona;
    await lastValueFrom(this.colaPersonaSrv.grabar(colaPersona));

    this.identificacion = "";
    this.nombre = "";
    if (idCola == 1)
      this.devolverCola1(1);
    else
      this.devolverCola2(1);
    this.messageService.add({ key: 'tc', severity: 'success', summary: 'Confirmación', detail: 'Ticket asignado satisfactoriamente.' });
  }

  validarIngreso(): string {
    var resultado: string = '';
    if (this.identificacion.trim().length == 0) {
      resultado = "Ingrese el id ";
    }

    if (this.nombre.trim().length == 0) {
      resultado += " - Ingrese el nombre";
    }
    return resultado;
  }


  async devolverCola1(idTipo: number) {
    this.cola1 = [];
    this.consulta.sentenciaSql = `Update ColaPersona Set estado=1 Where GETDATE()>=fechaSalida And idCola=1`;
    await lastValueFrom(this.funcionSrv.getEjecutarSql(this.consulta));
    var resultado: any;

    this.consulta.sentenciaSql = `Exec DevolverCola 1`;
    resultado = await lastValueFrom(this.funcionSrv.getDevolverGrilla(this.consulta));
    this.cola1 = JSON.parse(resultado);
    if (idTipo == 0) {
      if (this.cola1.length == 0) {
        this.timer1.reset();
      }
      else {
        this.timer1.start();
      }
    }
    else {
      if (this.cola1.length == 1) {
        this.timer1.start();
      }
    }
  }

  async devolverCola2(idTipo: number) {
    this.cola2 = [];
    this.consulta.sentenciaSql = `Update ColaPersona Set estado=1 Where GETDATE()>=fechaSalida And idCola=2`;
    await lastValueFrom(this.funcionSrv.getEjecutarSql(this.consulta));
    var resultado: any;

    this.consulta.sentenciaSql = `Exec DevolverCola 2`;
    resultado = await lastValueFrom(this.funcionSrv.getDevolverGrilla(this.consulta));
    this.cola2 = JSON.parse(resultado);

    if (idTipo == 0) {
      if (this.cola2.length == 0) {
        this.timer2.reset();
      }
      else {
        this.timer2.start();
      }
    }
    else {
      if (this.cola2.length == 1) {
        this.timer2.start();
      }
    }

  }
}

