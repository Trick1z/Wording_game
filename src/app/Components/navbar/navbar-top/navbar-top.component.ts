import { Component } from '@angular/core';
import { Router } from '@angular/router';
// import { AdminRoute, AuthRoute } from 'src/app/Constants/routes.const';

import { AdminRoute, AuthRoute, UserRoute } from 'src/app/Constants/routes.const';



@Component({
  selector: 'app-navbar-top',
  templateUrl: './navbar-top.component.html',
  styleUrls: ['./navbar-top.component.scss']
})
export class NavbarTopComponent {
  Username: string = 'Unknown User';

  // AdminRoute :Array<string> = [AdminRoute.AdminFormFullPath , AdminRoute.AdminAddCategoriesFullPath]; 

  adminRoutes: any = [
    {
      name: AdminRoute.AdminFormName,
      path: AdminRoute.AdminFormFullPath
    },
    {
      name: AdminRoute.AdminAddCategoriesName,
      path: AdminRoute.AdminAddCategoriesFullPath
    },
    {
      name: AdminRoute.AdminUserCategoriesName,
      path: AdminRoute.AdminUserCategoriesFullPath
    },
  ]
  userRoutes: any = [
    {
      name:  UserRoute.UserFormName,
      path:  UserRoute.UserFormFullPath
    }
  ]

  // dropdown state
  adminDropdownOpen = false;
  userDropdownOpen = false;


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

  
// set dropdown f
  adminToggleDropdown() {
    this.adminDropdownOpen = !this.adminDropdownOpen;
  }
   userToggleDropdown() {
    this.userDropdownOpen = !this.userDropdownOpen;
  }

   CloseDropdown() {
    this.adminDropdownOpen = false;
    this.userDropdownOpen = false;
  }
 


  navigateTo(path: string) {
    console.log(path);
    this.route.navigate([path]);
  }
  // AdminRoute = AuthRoute.AdminFormFullPath;

  onLogout() {
    sessionStorage.clear();
    return this.route.navigate([AuthRoute.Login]);
  }
}
