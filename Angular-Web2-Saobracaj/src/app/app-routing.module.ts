import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


import {CenovnikComponent} from './cenovnik/cenovnik.component'
import {HomepageContentComponent} from './homepage-content/homepage-content.component'
import {LoginFormComponent} from './login-form/login-form.component'
import {NavigationBarComponent} from './navigation-bar/navigation-bar.component'
import {RedVoznjeComponent} from './red-voznje/red-voznje.component'
import {RegisterFormComponent} from './register-form/register-form.component'
import { MrezaLinijaComponent } from './mreza-linija/mreza-linija.component';

import { AuthGuard } from './auth/auth.guard';
import { ValidateTicketsComponent } from './validate-tickets/validate-tickets.component';
import { VerifyUserComponent } from './verify-user/verify-user.component';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { AdminManagmentComponent } from './admin-managment/admin-managment.component';
import { AddCenaStavkeComponent } from './add-cena-stavke/add-cena-stavke.component';
import { AddKontrolorComponent } from './add-kontrolor/add-kontrolor.component';


const routes: Routes = [
  {
    path: '',
    redirectTo: '/home',
    pathMatch: 'full'
  },
  {
    path: 'home',
    component: HomepageContentComponent
  },
  {
    path: 'busLines',
    component: MrezaLinijaComponent
  },
  {
    path: 'timetable',
    component: RedVoznjeComponent,
    //canActivate: [AuthGuard]
  },
  {
    path: 'pricing',
    component: CenovnikComponent
  },
  {
    path: 'login',
    component: LoginFormComponent 
  },
  {
    path: 'signUp',
    component: RegisterFormComponent
  },
  {
    path: 'validate',
    component: ValidateTicketsComponent
  },
  {
    path: 'verify',
    component: VerifyUserComponent
  },
  {
    path:'profile',
    component: UserProfileComponent
  },
  {
    path: 'managment',
    component: AdminManagmentComponent 
  },
  {
    path: 'CenaStavke',
    component:AddCenaStavkeComponent
  },
  {
    path:'Kontrolori',
    component:AddKontrolorComponent
  },  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
