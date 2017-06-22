import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import 'rxjs/add/operator/filter';
import * as auth0 from 'auth0-js';
import { JwtHelper } from 'angular2-jwt';


@Injectable()
export class AuthService {

  profile: any;
  private roles: string[] = [];

  jwtHelper: JwtHelper = new JwtHelper();

  public isInRole(roleName) {
    return this.roles.indexOf(roleName) > -1;
  }

  auth0 = new auth0.WebAuth({
    clientID: 'MgNB9xdWAs06k31QJq8gjEv2Xe06WoYH',
    domain: 'bdeliv.auth0.com',
    responseType: 'token id_token',
    audience: 'https://bdeliv.auth0.com/userinfo',
    redirectUri: 'http://localhost:5000/home',      
    //redirectUri: 'http://localhost:4200/callback',      
    scope: 'openid profile email'
  });

  constructor(public router: Router) {
    this.profile = JSON.parse(localStorage.getItem('profile'));

    var token = localStorage.getItem('access_token');

    if(token) {
      var decodedToken = this.jwtHelper.decodeToken(token);
      this.roles = decodedToken['https://bdeliv.com/roles'];
    }
  }

  public login(): void {
    this.auth0.authorize();
  }

  public handleAuthentication(): void {
    this.auth0.parseHash((err, authResult) => {
      if (authResult && authResult.accessToken) { // && authResult.idToken) {
        window.location.hash = '';
        this.setSession(authResult);
        this.router.navigate(['/home']);
      } else if (err) {
        this.router.navigate(['/home']);
        console.log(err);
      }
    });
  }

  private setSession(authResult): void {
    // Set the time that the access token will expire at
    const expiresAt = JSON.stringify((authResult.expiresIn * 1000) + new Date().getTime());
    
    localStorage.setItem('access_token', authResult.accessToken);
    //localStorage.setItem('id_token', authResult.idToken);
    localStorage.setItem('expires_at', expiresAt);

    var decodedToken = this.jwtHelper.decodeToken(authResult.accessToken);
    this.roles = decodedToken['https://bdeliv.com/roles'];

    this.auth0.client.userInfo(authResult.accessToken, (err, profile) => {
      if(err)
        throw err;
      
      localStorage.setItem('profile', JSON.stringify(profile));
      this.profile = profile;
    });
  }

  public logout(): void {
    // Remove tokens and expiry time from localStorage
    localStorage.removeItem('access_token');
    //localStorage.removeItem('id_token');
    localStorage.removeItem('expires_at');
    localStorage.removeItem('profile');
    this.profile = null;
    this.roles = [];
    // Go back to the home route
    this.router.navigate(['/']);
  }

  public isAuthenticated(): boolean {
    // Check whether the current time is past the
    // access token's expiry time
    const expiresAt = JSON.parse(localStorage.getItem('expires_at'));
    return new Date().getTime() < expiresAt;
  }

}