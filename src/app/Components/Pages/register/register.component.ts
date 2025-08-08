import { Component } from '@angular/core';
import Swal from 'sweetalert2';
import { RegisterData } from '../../models/auth.model';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {
  customerRole = [
    { value: 1, name: 'Customer' },
    { value: 2, name: 'Borrow' },
    { value: 3, name: 'Repair' },
    { value: 4, name: 'Software' },
    { value: 99, name: 'Admin' },


  ];
  registerData: RegisterData = {

    username: null,
    password: null,
    confirmPassword: null,
    isVip: null
  }

  onSubmit() {


    // 1 จำเป็นต้อง validate ตรงหน้าบ้านมั้ย 
    if (!this.registerData.username?.trim() ||
      !this.registerData.password?.trim() ||
      !this.registerData.confirmPassword?.trim() ||
      this.registerData.isVip === null) {

      return Swal.fire({
        title: "กรุณาใส่ข้อมูลให้ครบถ้วน",
        icon: "error",
        draggable: true
      });


    }

    if (this.registerData.password !== this.registerData.confirmPassword) {
      return Swal.fire({
        title: "รหัสผ่านไม่ตรงกัน",
        icon: "error",
        draggable: true
      });
    }


    // true
    return console.log(this.registerData);
  }
}
