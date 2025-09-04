import { Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { LoginComponent } from './pages/login/login.component';
import { UserComponent } from './user/user.component';

export const routes: Routes = [
    { path: 'client', component:  HomeComponent},
    { path: '', pathMatch: 'full', redirectTo: 'client' },
    { path: 'user', component: UserComponent },
];
