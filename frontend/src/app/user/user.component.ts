import { isPlatformBrowser } from '@angular/common';
import { Component, inject, OnInit, PLATFORM_ID } from '@angular/core';
import { AuthConfig, OAuthLogger, OAuthService } from 'angular-oauth2-oidc';

interface User {
  name: string,
  email: string,
  picture: string
}

@Component({
  selector: 'app-user',
  standalone: true,
  imports: [],
  providers:[OAuthService],
  templateUrl: './user.component.html',
  styleUrl: './user.component.css'
})
export class UserComponent implements OnInit {
  
  private oAuthService = inject(OAuthService);
  private platformId = inject(PLATFORM_ID);

  profile: any;
  
  user : User = {
    name: '',
    email: '',
    picture: ''
  };
  
  ngOnInit(): void {
    this.initConfiguration()
  }
  
  async initConfiguration() {
    if(isPlatformBrowser(this.platformId)) {
      console.log('entrei')
      const authConfig: AuthConfig = {
        issuer: 'https://accounts.google.com',
        clientId: '616616243151-t0at6nqie04o5jjub7ud82pp8iniqebr.apps.googleusercontent.com',
        redirectUri: window.location.origin + '/user',
        scope: 'openid profile email',
        logoutUrl: window.location.origin,
        strictDiscoveryDocumentValidation: false,
      }

      this.oAuthService.configure(authConfig);
      this.oAuthService.setupAutomaticSilentRefresh();
      await this.oAuthService.loadDiscoveryDocumentAndLogin();
      this.profile = this.oAuthService.getIdentityClaims();

      this.user.name = this.profile.given_name;
      this.user.email = this.profile.email;
      this.user.picture = this.profile.picture;
    }
  }

}
