import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule} from '@angular/common/http';
import { FormsModule } from "@angular/forms";
import { RouterModule } from '@angular/router';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginFormComponent } from './login-form/login-form.component';
import { NavigationBarComponent } from './navigation-bar/navigation-bar.component';
import { RedVoznjeComponent } from './red-voznje/red-voznje.component';
import { HomepageContentComponent } from './homepage-content/homepage-content.component';
import { CenovnikComponent } from './cenovnik/cenovnik.component';
import { RegisterFormComponent } from './register-form/register-form.component';
import { MrezaLinijaComponent } from './mreza-linija/mreza-linija.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginFormComponent,
    NavigationBarComponent,
    RedVoznjeComponent,
    HomepageContentComponent,
    CenovnikComponent,
    RegisterFormComponent,
    MrezaLinijaComponent
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    RouterModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
