import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';

import {HttpClientModule} from "@angular/common/http";
import { apiService } from './services/api.service';
import { CountdownTimerComponent } from './countdown-timer/countdown-timer.component';
import { ItemCardComponent } from './item-card/item-card.component';

@NgModule({
  declarations: [
    AppComponent,
    CountdownTimerComponent,
    ItemCardComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  providers: [apiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
