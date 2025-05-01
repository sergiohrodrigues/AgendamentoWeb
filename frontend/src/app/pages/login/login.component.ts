import { MatDividerModule } from '@angular/material/divider';
import { MatButtonModule } from '@angular/material/button';
import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import {MatInputModule} from '@angular/material/input';
import {MatIconModule} from '@angular/material/icon';
import {} from '@angular/common/http';
import { Router } from '@angular/router';
import { ApiService } from '../../services/api.service';

@Component({
    selector: 'app-login',
    imports: [],
    templateUrl: './login.component.html',
    styleUrl: './login.component.css'
})
export class LoginComponent {
  title = 'frontend';
  /*hide: boolean = true;
  results: any[] = [];*/

  constructor(private apiService: ApiService, 
    // private router: Router
  ) {}

  private router = inject(Router);

  googleSignIn(){
    this.router.navigate(['/user']);
  }
  
  /*user: any = {
    login: '',
    password: ''
  }

  Login(){
    this.apiService.loginUser('User/LoginUser', this.user).subscribe({
      next: (data) => {
        if(data.dados == null){
          console.log(data.mensagem)
        } else {
          setInterval(() => {
            this.router.navigate(['home']);
            this.user.login = '';
            this.user.password = '';
          }, 3000)
        }
      },
      error: (err) => {
        console.error('Erro ao buscar dados:', err);
      },
    });
  }*/


  }
