import { Injectable } from '@angular/core';
import { DecodeJwtDataService } from '../Services/decode-jwt-data.service';
import {
  CanActivate, Router,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
  CanActivateChild,
} from '@angular/router';
import { AuthService } from '../Services/auth.service';

@Injectable({
  providedIn: 'root',
})
export class AuthGuard implements CanActivate, CanActivateChild {
  constructor(private router: Router, private decodeService:DecodeJwtDataService) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean { 
    let rola = this.decodeService.getRoleFromToken();
    if (rola === 'Admin') {
      return true;
    }
    // not logged in so redirect to home page
    else {
      console.error("Can't access, not admin");
      this.router.navigate(['/home']);
      return false;
    }
  }

  canActivateChild(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    return this.canActivate(route, state);
  }

}
