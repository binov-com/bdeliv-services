import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import 'rxjs/add/operator/filter';
import * as auth0 from 'auth0-js';
import { JwtHelper } from 'angular2-jwt';


@Injectable()
export class AuthService {

  profile: any;
  private roles: string[] = [];

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
    this.readUserFromLocalStorage();
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

    console.log(authResult);

    localStorage.setItem('token', authResult.accessToken);
    localStorage.setItem('expires_at', expiresAt);

    this.auth0.client.userInfo(authResult.accessToken, (err, profile) => {
      if(err) 
        throw err;
      
      localStorage.setItem('profile', JSON.stringify(profile));

      this.readUserFromLocalStorage();
    });
  }

  public logout(): void {
    // Remove tokens and expiry time from localStorage
    localStorage.removeItem('token');
    localStorage.removeItem('expires_at');
    localStorage.removeItem('profile');
    this.profile = null;
    this.roles = [];
    // Go back to the home route
    // this.router.navigate(['/']);
  }

  public isAuthenticated(): boolean {
    // Check whether the current time is past the
    // access token's expiry time
    const expiresAt = JSON.parse(localStorage.getItem('expires_at'));
    return new Date().getTime() < expiresAt;
  }

  private readUserFromLocalStorage() {
    this.profile = JSON.parse(localStorage.getItem('profile'));

    var token = localStorage.getItem('token');
    if(token) {
      var jwtHelper = new JwtHelper();
      var decodedToken = jwtHelper.decodeToken(token);
      this.roles = decodedToken['https://bdeliv.com/roles'] || [];
    }
  }

  public isInRole(roleName) {
    return this.roles.indexOf(roleName) > -1;
  }

}