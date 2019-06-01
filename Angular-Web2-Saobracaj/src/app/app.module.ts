import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule} from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginFormComponent } from './login-form/login-form.component';
import { RedVoznjeComponent } from './red-voznje/red-voznje.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginFormComponent,
    RedVoznjeComponent,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
  ],
  providers: [],
  bootstrap: [AppComponent, LoginFormComponent, RedVoznjeComponent]
})
export class AppModule { }
