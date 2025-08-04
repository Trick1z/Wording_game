import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthRoute } from 'src/app/Constants/routes.const';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
 constructor(
  private Route :Router
 ){}



 NavigateToRegisterPage(){

  return this.Route.navigate([AuthRoute.RegisterFullPath])
 }
}
