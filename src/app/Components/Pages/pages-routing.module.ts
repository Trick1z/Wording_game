import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { AuthRoute } from 'src/app/Constants/routes.const';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [

    {
        path: AuthRoute.Login ,
        component: LoginComponent
    },
    {
        path: AuthRoute.Register ,
        component: RegisterComponent
    },
]


@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class PagesRoutingModule { }
