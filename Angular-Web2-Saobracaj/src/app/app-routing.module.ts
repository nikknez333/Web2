import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import {CenovnikComponent} from './cenovnik/cenovnik.component'
import {HomepageContentComponent} from './homepage-content/homepage-content.component'
import {LoginFormComponent} from './login-form/login-form.component'
import {NavigationBarComponent} from './navigation-bar/navigation-bar.component'
import {RedVoznjeComponent} from './red-voznje/red-voznje.component'
import {RegisterFormComponent} from './register-form/register-form.component'
import { MrezaLinijaComponent } from './mreza-linija/mreza-linija.component';

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
    component: RedVoznjeComponent
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
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
