import { Injectable } from '@angular/core';
import { AuthService } from "./auth.service";
import { CanActivate } from "@angular/router";

@Injectable()
export class AuthGuardService implements CanActivate {
    constructor(protected auth: AuthService) { }

    canActivate() {
        if(this.auth.isAuthenticated())
            return true;
        
        // to loggin
        window.location.href = 'https://bdeliv.auth0.com/login?client=MgNB9xdWAs06k31QJq8gjEv2Xe06WoYH';
        return false;
    }
}