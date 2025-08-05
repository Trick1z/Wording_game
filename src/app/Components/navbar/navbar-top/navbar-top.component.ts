import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthRoute } from 'src/app/Constants/routes.const';

@Component({
  selector: 'app-navbar-top',
  templateUrl: './navbar-top.component.html',
  styleUrls: ['./navbar-top.component.scss']
})
export class NavbarTopComponent {
  Username: string = 'Unknown User';
  ngOnInit(): void {
    this.setUser();
  }
  constructor(private route: Router) { }

  setUser() {
    const data = sessionStorage.getItem('user');

    if (data !== null) {
      const parsed = JSON.parse(data);
      // this.Username = parsed.
      this.Username = parsed.user.username;
    } else {
      // กรณี data เป็น null (เช่น ไม่มี key ใน sessionStorage)
    }
  }
  onLogout() {
    sessionStorage.clear();
    return this.route.navigate([AuthRoute.Login]);
  }
}
