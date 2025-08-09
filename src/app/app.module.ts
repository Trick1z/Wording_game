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
import { DxButtonModule, DxDataGridModule, DxDropDownBoxModule, DxFormModule, DxPopupModule, DxSelectBoxModule } from 'devextreme-angular';
import { NavbarTopComponent } from './Components/navbar/navbar-top/navbar-top.component';
import { LandingComponent } from './Components/Pages/landing/landing.component';
import dxForm from 'devextreme/ui/form';
import { EditPopupComponent } from './Components/games/word-scoring/edit-popup/edit-popup.component';
import { GridCustomerComponent } from './Components/shared/grid-customer/grid-customer.component';
import { CustomerPageComponent } from './Components/customer/customer-page/customer-page.component';
import { ButtonComponent } from './Components/shared/button/button.component';
import { PopupComponent } from './Components/shared/popup/popup.component';
import { HeadUnderlineComponent } from './Components/shared/head-underline/head-underline.component';
import { TextBoxComponent } from './Components/shared/text-box/text-box.component';
import { CustomerAddPageComponent } from './Components/customer/customer-add-page/customer-add-page.component';
import { UserMainComponent } from './Components/user/user-main/user-main.component';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    HomeComponent,
    WordScoringComponent,
    NavbarTopComponent,
    LandingComponent,
    EditPopupComponent,
    GridCustomerComponent,
    CustomerPageComponent,
    ButtonComponent,
    PopupComponent,
    HeadUnderlineComponent,
CustomerAddPageComponent,
    TextBoxComponent,
    UserMainComponent
  ],
  imports: [
    BrowserModule, FormsModule,
    DxSelectBoxModule,AppRoutingModule,
    DxDataGridModule, DxButtonModule,
    DxFormModule,DxPopupModule,DxDropDownBoxModule
  ],
  providers: [],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]  // 👈 เพิ่มบรรทัดนี้เข้าไป

})
export class AppModule { }
