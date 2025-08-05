import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './Components/Pages/login/login.component';
import { RegisterComponent } from './Components/Pages/register/register.component';
import { HomeComponent } from './Components/views/home/home.component';
import { WordScoringComponent } from './Components/games/word-scoring/word-scoring.component';
import { FormsModule } from '@angular/forms';
import dxDataGrid from 'devextreme/ui/data_grid';
import { DxButtonModule, DxDataGridModule } from 'devextreme-angular';
import { NavbarTopComponent } from './Components/navbar/navbar-top/navbar-top.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    HomeComponent,
    WordScoringComponent,
    NavbarTopComponent
  ],
  imports: [
    BrowserModule, FormsModule,
    AppRoutingModule
    ,DxDataGridModule,DxButtonModule
  ],
  providers: [],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]  // 👈 เพิ่มบรรทัดนี้เข้าไป

})
export class AppModule { }
