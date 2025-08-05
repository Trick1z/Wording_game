import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthRoute } from 'src/app/Constants/routes.const';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  constructor(
    private Route: Router
  ) { }


  userData: UserData = {
    username: null,
    password: null
  }


  NavigateToRegisterPage() {

    return this.Route.navigate([AuthRoute.RegisterFullPath])
  }

  onSubmit() {

    if (this.userData.username == null || this.userData.password == null) {

      return Swal.fire({
        title: "กรุณาใส่ข้อมูลให้ครบถ้วน",
        icon: "error",
        draggable: true
      });
      

    }
// true
    return  console.log(this.userData);

    

  }
}

interface UserData {
  username: string | null
  password: string | null
}
