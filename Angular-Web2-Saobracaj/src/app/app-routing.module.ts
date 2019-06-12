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
<<<<<<< HEAD
import { UserProfileComponent } from './user-profile/user-profile.component';
=======
import { AdminManagmentComponent } from './admin-managment/admin-managment.component';
>>>>>>> 50bf6f86bf6b5b2d9fcb001d21e83c16ca472ffb

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
  }
    path: 'managment',
    component: AdminManagmentComponent 
  },
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
