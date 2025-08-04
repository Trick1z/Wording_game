import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './Components/Pages/login/login.component';
import { AuthRoute, GamesRoute, ViewsRoute} from './Constants/routes.const';
import { ViewsRoutingModule } from './Components/views/views-routing.module';

const routes: Routes = [

  {

    path: '',
    children: [
      {
        path: AuthRoute.prefix,
        loadChildren: () => import('./Components/Pages/pages-routing.module').then(m => m.PagesRoutingModule)
      },
      {
        path : ViewsRoute.prefix,
        loadChildren :() => import ('./Components/views/views-routing.module').then(m => m.ViewsRoutingModule)
      },
      {
        path : GamesRoute.prefix,
        loadChildren :() => import ('./Components/games/games-routing.module').then(m => m.GamesRoutingModule)
      }
    ]
  }




];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
