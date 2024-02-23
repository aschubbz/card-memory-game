import { Component, OnInit } from '@angular/core';
import { GameService } from '../../service/game.service';
import { ResponseModel } from '../../model/common/response.model';
import { GameCardViewModel } from '../../model/game/game-card-view.model';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrl: './main.component.scss'
})
export class MainComponent implements OnInit {

  cards: Array<GameCardViewModel> = []

  constructor(private _gameService: GameService) {
  }

  ngOnInit() {
    this._gameService.start(
      (r: ResponseModel<Array<GameCardViewModel>>) => {
        this.cards = r.data;
        console.log(r.data);
      }, (e) => {
        console.log(e);
      }
    )
  }

}
