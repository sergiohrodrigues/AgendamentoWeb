import { Component, OnInit } from '@angular/core';
import { ClientService } from '../../services/client/client.service';
import { DayWithTimes } from '../../interfaces/client/dayWithTimes';
import { firstValueFrom } from 'rxjs';
import { CommonModule } from '@angular/common';
import { ButtonModule } from 'primeng/button';
import { PanelModule } from 'primeng/panel';
import { ImageModule } from 'primeng/image';
import { ProfessionalService, ResponseComDados } from '../../services/professional/professional.service';
import { Professional } from '../../interfaces/professional/professional';
import { StepperModule } from 'primeng/stepper';
import { AvatarModule } from 'primeng/avatar';

@Component({
    selector: 'app-home',
    imports: [CommonModule, ButtonModule, PanelModule, ImageModule, StepperModule, AvatarModule],
    templateUrl: './home.component.html',
    styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {
    dayWithTimes: DayWithTimes[] = [];
    professionals: ResponseComDados<Professional[]> | undefined;

    constructor(private professionalService: ProfessionalService) {}

    async ngOnInit(): Promise<void> {
        this.professionals = await firstValueFrom(this.professionalService.getAllProfessionals());
    }
}