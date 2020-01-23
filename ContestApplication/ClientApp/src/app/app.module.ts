import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { ContestComponent } from './contest/contest.component';
import {ContestService} from './contest.service';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ContestComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'contest', component: ContestComponent },
    ])
  ],
  providers: [ContestService],
  bootstrap: [AppComponent]
})
export class AppModule { }
