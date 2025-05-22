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

    constructor(private professionalService: ProfessionalService, private dayWithTimesService: DayWithTimesService) {}

    async ngOnInit(): Promise<void> {
        this.professionals = await firstValueFrom(this.professionalService.getAllProfessionals());

        this.month = new Date().getMonth()+1;
        this.year = new Date().getFullYear();

        const teste = [this.converterParaDataCompleta(1, this.month)];
        this.date = teste[0];
    }

    converterParaDataCompleta(dia: number, mes: number): Date {
        return new Date(this.year, mes - 1, dia);
    }

    mudarMes() {
        if (this.date) {
            const mesId = this.date.getMonth() + 1;
            this.exibirHorarios(mesId);
          }
    }

    exibirHorarios(month: number){
        this.dayWithTimesFiltrados = this.dayWithTimes.filter(item => item.month === month);
    }

    async buscarDiasDisponiveis() {        
        const response = await firstValueFrom(this.dayWithTimesService.getDayWithTimes(1));
        this.dayWithTimes = response;
        this.exibirHorarios(this.month);
    }
}