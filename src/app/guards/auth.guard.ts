// import { CanActivateFn } from '@angular/router';

// export const authGuard: CanActivateFn = (route, state) => {

  
//   return true;
// };



import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthRoute } from '../Constants/routes.const';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private router: Router) {}

  canActivate(): boolean {
    const token = sessionStorage.getItem('token');

    if (token) {
      return true;
    } else {
      this.router.navigate([AuthRoute.LoginFullPath]);
      return false;
    }
  }
}