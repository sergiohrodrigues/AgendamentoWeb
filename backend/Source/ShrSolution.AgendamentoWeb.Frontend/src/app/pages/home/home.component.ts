import { Component, OnInit } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { CommonModule } from '@angular/common';
import { ButtonModule } from 'primeng/button';
import { PanelModule } from 'primeng/panel';
import { ImageModule } from 'primeng/image';
import { ProfessionalService, ResponseComDados } from '../../services/professional/professional.service';
import { Professional } from '../../interfaces/professional/professional';
import { StepperModule } from 'primeng/stepper';
import { AvatarModule } from 'primeng/avatar';
import { DayWithTimesService } from '../../services/dayWithTimes/dayWithTimes';
import { DayWithTimes } from '../../interfaces/dayWithTimes/dayWithTimes';
import { DatePickerModule } from 'primeng/datepicker';
import { FormsModule } from '@angular/forms';

@Component({
    selector: 'app-home',
    imports: [CommonModule, ButtonModule, PanelModule, ImageModule, StepperModule, AvatarModule, DatePickerModule, FormsModule],
    templateUrl: './home.component.html',
    styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {
    dayWithTimes: DayWithTimes[] = [];
    dayWithTimesFiltrados: DayWithTimes[] = [];
    professionals: ResponseComDados<Professional[]> | undefined;
    date: Date | undefined;
    month: number = 0;
    year: number = 2025;
    day: number |undefined;
    horariosDoDiaSelecionado: string[] = [];
    horario: string | undefined;
    profissionalSelecionadoId: number | null = null;
    minMonth: Date = new Date();


    constructor(private professionalService: ProfessionalService, private dayWithTimesService: DayWithTimesService) {}

    async ngOnInit(): Promise<void> {
        this.professionals = await firstValueFrom(this.professionalService.getAllProfessionals());

        this.month = new Date().getMonth()+1;
        this.year = new Date().getFullYear();

        const teste = [this.converterParaDataCompleta(1, this.month)];
        this.date = teste[0];

        const hoje = new Date();
        this.minMonth = new Date(hoje.getFullYear(), hoje.getMonth(), 1); 

        console.log(this.horario)
    }

    converterParaDataCompleta(pDia: number, pMes: number): Date {
        return new Date(this.year, pMes - 1, pDia);
    }

    mudarMes() {
        if (this.date) {
            const mesId = this.date.getMonth() + 1;
            this.month = mesId;
            this.exibirHorarios(mesId);
          }
    }

    exibirHorarios(pMonth: number){
        this.dayWithTimesFiltrados = this.dayWithTimes.filter(item => item.month === pMonth);
    }

    diaSelecionado(pDay: number) {
      this.day = pDay;
      const itemSelecionado = this.dayWithTimesFiltrados.find(item => item.day === pDay);
      this.horariosDoDiaSelecionado = itemSelecionado ? itemSelecionado.horarios : [];
    }

    selecionarHorario(pHorario: string){
        console.log(pHorario)
        this.horario = pHorario
        console.log(this.horario)
    }

    resetar(){
        this.day = undefined
        this.horario = undefined
    }

    voltar() {
        this.day = undefined
        this.horario = undefined
    }

    async buscarDiasDisponiveis(pProfissionalId: number) {
        this.resetar()
        console.log(this.profissionalSelecionadoId)
        this.profissionalSelecionadoId = pProfissionalId;
        console.log(this.profissionalSelecionadoId)
        const response = await firstValueFrom(this.dayWithTimesService.getDayWithTimes(pProfissionalId));

        console.log(response)
        this.dayWithTimes = response;
        this.exibirHorarios(this.month);
    }
}