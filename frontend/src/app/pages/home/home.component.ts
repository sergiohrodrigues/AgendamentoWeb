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
    professionals: ResponseComDados<Professional[]> | undefined;
    date: Date | undefined;
    month: number | undefined;
    year: number | undefined;

    constructor(private professionalService: ProfessionalService, private dayWithTimesService: DayWithTimesService) {}

    async ngOnInit(): Promise<void> {
        this.professionals = await firstValueFrom(this.professionalService.getAllProfessionals());

        this.month = new Date().getMonth()+1;
        this.year = new Date().getFullYear();

        const teste = [this.converterParaDataCompleta(1, this.month, this.year)];
        this.date = teste[0];
    }

    converterParaDataCompleta(dia: number, mes: number, ano: number): Date {
        return new Date(ano, mes - 1, dia);
    }

    async buscarDiasDisponiveis() {        
        const response = await firstValueFrom(this.dayWithTimesService.getDayWithTimes(1));
        this.dayWithTimes = response.filter(item => item.month === this.month);
    }
}