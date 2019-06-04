import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule} from '@angular/common/http';
import { FormsModule } from "@angular/forms";

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginFormComponent } from './login-form/login-form.component';
import { NavigationBarComponent } from './navigation-bar/navigation-bar.component';
import { RedVoznjeComponent } from './red-voznje/red-voznje.component';
import { HomepageContentComponent } from './homepage-content/homepage-content.component';
import { CenovnikComponent } from './cenovnik/cenovnik.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginFormComponent,
    NavigationBarComponent,
    RedVoznjeComponent,
    HomepageContentComponent,
    CenovnikComponent,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent, HomepageContentComponent]
})
export class AppModule { }
