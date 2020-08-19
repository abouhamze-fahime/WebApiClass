import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GetCodeComponent } from './get-code/get-code.component';
import { VerifyCodeComponent } from './verify-code/verify-code.component';
import { HomeComponent } from './home/home.component';

const routes: Routes = [{
  path: '',
  component: GetCodeComponent
},
{
  path: 'verify-code',
  component: VerifyCodeComponent
},
{
  path: 'home',
  component: HomeComponent
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
