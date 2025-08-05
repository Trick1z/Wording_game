import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './Components/Pages/login/login.component';
import { AuthRoute, GamesRoute, ViewsRoute } from './Constants/routes.const';
import { ViewsRoutingModule } from './Components/views/views-routing.module';
import { AuthGuard } from './guards/auth.guard';
import { NoAuthGuard } from './guards/no-auth.guard';
import { RedirectGuard } from './guards/redirect.guard';

const routes: Routes = [

  {

    path: '',
    children: [
      {
        path: AuthRoute.prefix,
        loadChildren: () => import('./Components/Pages/pages-routing.module').then(m => m.PagesRoutingModule)

        , canActivate: [NoAuthGuard],
      },
      {
        canActivate: [AuthGuard],

        path: ViewsRoute.prefix,
        loadChildren: () => import('./Components/views/views-routing.module').then(m => m.ViewsRoutingModule)
      },
      {
        canActivate: [AuthGuard],
        path: GamesRoute.prefix,
        loadChildren: () => import('./Components/games/games-routing.module').then(m => m.GamesRoutingModule)
      }
    ]


  },

  {
    path: '',
    component: LoginComponent,
    canActivate: [RedirectGuard],
    pathMatch: 'full',
  },
  {
    path: '**',
    component: LoginComponent,
    canActivate: [RedirectGuard],
  },





];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
