import { NgModule,CUSTOM_ELEMENTS_SCHEMA  } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './Components/Pages/login/login.component';
import { RegisterComponent } from './Components/Pages/register/register.component';
import { HomeComponent } from './Components/views/home/home.component';
import { WordScoringComponent } from './Components/games/word-scoring/word-scoring.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    HomeComponent,
    WordScoringComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]  // 👈 เพิ่มบรรทัดนี้เข้าไป

})
export class AppModule { }
