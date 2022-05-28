import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { JobTitleListPageComponent } from './components/job-title-list-page/job-title-list-page.component';
import { LoginPageComponent } from './components/login-page/login-page.component';
import { RegisterPageComponent } from './components/register-page/register-page.component';


const routes: Routes = [
  {path:'register',component:RegisterPageComponent},
  {path:'login',component:LoginPageComponent},
  {path:'danhmucchucdanh',component:JobTitleListPageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
