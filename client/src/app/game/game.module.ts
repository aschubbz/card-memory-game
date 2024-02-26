import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { GameRoutingModule } from './game-routing.module';
import { MainComponent } from './components/main/main.component';
import { CardComponent } from './components/card/card.component';
import { BrowserModule } from '@angular/platform-browser';


@NgModule({
  declarations: [
    MainComponent,
    CardComponent,
  ],
  imports: [
    CommonModule,
    GameRoutingModule
  ]
})
export class GameModule { }
