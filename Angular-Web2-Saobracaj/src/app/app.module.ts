import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';
import { FormsModule } from "@angular/forms";
import { RouterModule } from '@angular/router';
import { AgmCoreModule } from '@agm/core';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginFormComponent } from './login-form/login-form.component';
import { NavigationBarComponent } from './navigation-bar/navigation-bar.component';
import { RedVoznjeComponent } from './red-voznje/red-voznje.component';
import { HomepageContentComponent } from './homepage-content/homepage-content.component';
import { CenovnikComponent } from './cenovnik/cenovnik.component';
import { RegisterFormComponent } from './register-form/register-form.component';
import { MrezaLinijaComponent } from './mreza-linija/mreza-linija.component';
import { JwtInterceptor } from './Auth/jwt-interceptor';
import { ValidateTicketsComponent } from './validate-tickets/validate-tickets.component';
import { VerifyUserComponent } from './verify-user/verify-user.component';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { AdminManagmentComponent } from './admin-managment/admin-managment.component';
import { AdminTableComponent } from './admin-table/admin-table.component';
import { AddCenaStavkeComponent } from './add-cena-stavke/add-cena-stavke.component';
import { AddKontrolorComponent } from './add-kontrolor/add-kontrolor.component';
import { LinijeComponent } from './linije/linije.component';
import { MojeKarteComponent } from './moje-karte/moje-karte.component';


@NgModule({
  declarations: [
    AppComponent,
    LoginFormComponent,
    NavigationBarComponent,
    RedVoznjeComponent,
    HomepageContentComponent,
    CenovnikComponent,
    RegisterFormComponent,
    MrezaLinijaComponent,
    ValidateTicketsComponent,
    VerifyUserComponent,
    UserProfileComponent,
    
    AdminManagmentComponent,
    
    AdminTableComponent,
    
    AddCenaStavkeComponent,
    
    AddKontrolorComponent,
    
    LinijeComponent,
    
    MojeKarteComponent  
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    RouterModule,
    AgmCoreModule.forRoot({apiKey: 'AIzaSyDnihJyw_34z5S1KZXp90pfTGAqhFszNJk'})
  ],
  providers: [ 
    {
      provide: HTTP_INTERCEPTORS,
      useClass: JwtInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
