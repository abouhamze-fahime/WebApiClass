import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { GetCodeComponent } from './get-code/get-code.component';
import { VerifyCodeComponent } from './verify-code/verify-code.component';
import { HomeComponent } from './home/home.component';
import { UserInfoComponent } from './user-info/user-info.component';
import { InstalmentComponent } from './instalment/instalment.component';

@NgModule({
  declarations: [
    AppComponent,
    GetCodeComponent,
    VerifyCodeComponent,
    HomeComponent,
    UserInfoComponent,
    InstalmentComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
