import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import {
  AuthRoute,
  ViewsRoute,
  GamesRoute,
  CustomerRoute,
  AdminRoute,
} from 'src/app/Constants/routes.const';
import { MasterComponent } from './master/master.component';
import { AddCategoriesProductMainComponent } from './add-category-product/add-categories-product-main/add-categories-product-main.component';

const routes: Routes = [

    {
        path: AdminRoute.AdminForm,
        component: MasterComponent,
      },
    {
        path: AdminRoute.AdminAddCategories,
        component: AddCategoriesProductMainComponent,
      },
 
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule {}
