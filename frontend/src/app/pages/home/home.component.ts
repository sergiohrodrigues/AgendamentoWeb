import { Component, OnInit } from '@angular/core';
import { ClientService } from '../../services/client/client.service';
import { DayWithTimes } from '../../interfaces/client/dayWithTimes';
import { firstValueFrom } from 'rxjs';
import { CommonModule } from '@angular/common';
import { ButtonModule } from 'primeng/button';

@Component({
    selector: 'app-home',
    imports: [CommonModule, ButtonModule],
    templateUrl: './home.component.html',
    styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {
    dayWithTimes: DayWithTimes[] = [];

    constructor(private clientService: ClientService) {}

    async ngOnInit(): Promise<void> {
        this.dayWithTimes = await firstValueFrom(this.clientService.getDayWithTimes('dayWithTimes'));
        console.log(this.dayWithTimes)
    }
}
