import { Component, OnInit } from '@angular/core';
import { GameService } from '../../service/game.service';
import { ResponseModel } from '../../model/common/response.model';
import { GameCardViewModel } from '../../model/game/game-card-view.model';
import { GameViewModel } from '../../model/game/game-view.model';
import { GamePlayerViewModel } from '../../model/game/game-player-view.model';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrl: './main.component.scss'
})
export class MainComponent implements OnInit {

  cards: Array<GameCardViewModel> = []
  players:Array<GamePlayerViewModel> = []

  player_id:number = 1;

  constructor(private _gameService: GameService) {
  }

  ngOnInit() {
    this._gameService.start(
      (r: ResponseModel<GameViewModel>) => {
        this.cards = r.data.card;
        this.players = r.data.player
        console.log(r.data);
      }, (e) => {
        console.log(e);
      }
    )
  }

  change_player(event:any){
    this.player_id = event
  }

  change_player_score(event:any){
    let idx = this.players.findIndex(x => x.playerId == event.playerId)
    this.players[idx].score = event.score;
  }
}
