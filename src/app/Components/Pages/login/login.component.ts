import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthRoute, ViewsRoute } from 'src/app/Constants/routes.const';
import Swal from 'sweetalert2';
import { UserData } from '../../models/auth.model';
import { ApiService } from 'src/app/Services/api-service.service';
import { AuthServiceService } from 'src/app/Services/auth-service.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  constructor(
    private Route: Router,
    private api: ApiService,

    private authService: AuthServiceService

  ) { }

  passwordMode: string = "password";
  userData: UserData = {
    username: "",
    password: ""
  }

  usernameError:string ="" ;


  NavigateToRegisterPage() {

    return this.Route.navigate([AuthRoute.RegisterFullPath])
  }

  //   onSubmit() {
  //    this.api.post('api/User/login',this.userData ).subscribe((res :any) =>{
  //     console.log(res); 
  //    })
  //   }

  onSubmit() {
    this.authService.login(this.userData).subscribe({
      next: () => {
        this.usernameError = ''
        this.Route.navigate([ViewsRoute.HomeFullPath]);
      },
      error: (err) => {
       if (err.error && err.error.messages) {
          this.usernameError = err.error.messages.username || '';
        }
      }
    });
  }
}

