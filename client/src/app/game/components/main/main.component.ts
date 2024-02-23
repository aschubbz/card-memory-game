import { Component, OnInit } from '@angular/core';
import { GameService } from '../../service/game.service';
import { ResponseModel } from '../../model/common/response.model';
import { GameCardViewModel } from '../../model/game/game-card-view.model';
import { GameViewModel } from '../../model/game/game-view.model';
import { GamePlayerViewModel } from '../../model/game/game-player-view.model';
import { timeInterval } from 'rxjs';
import { CardFlipedResultModel } from '../../model/game/card-flip-result.model';
import { StorageHelper } from '../../../common/service/storage.helper';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrl: './main.component.scss'
})
export class MainComponent implements OnInit {

  cards: Array<GameCardViewModel> = []
  players: Array<GamePlayerViewModel> = []

  player_id: number = 1;

  current_flipped_game_cards: Array<GameCardViewModel> = [];

  constructor(private _gameService: GameService, private _store: StorageHelper) {
  }

  ngOnInit() {

    var game = this._store.get('game_id');

    if (game) {
      // is there a game id get that game
      this._gameService.get_game(
        (r: ResponseModel<GameViewModel>) => {
          this.cards = r.data.card;
          this.players = r.data.player
          this.set_random_player()
        }, (e) => {
          console.log(e);
        }, game.game_id
      )
    } else {
      // else create new game
      this.create_new_game()
    }

  }

  create_new_game() {
    this._gameService.start(
      (r: ResponseModel<GameViewModel>) => {
        this.cards = r.data.card;
        this.players = r.data.player
        this._store.add('game_id', { game_id: r.data.id })
        this.set_random_player()
      }, (e) => {
        console.log(e);
      }
    )
  }

  set_random_player() {
    // select random player
    this.player_id = this.players[Math.floor(Math.random() * this.players.length)].playerId;
  }

  change_player(event: any) {
    this.player_id = event
  }

  change_player_score(event: any) {
    let idx = this.players.findIndex(x => x.playerId == event.playerId)
    this.players[idx].score = event.score;
  }

  card_flipped($event: GameCardViewModel) {

    // do not add same card two times
    var idx = this.current_flipped_game_cards.find(o => o.id == $event.id)

    if (idx)
      return;

    this.current_flipped_game_cards.push($event)


    // match cards
    if (this.current_flipped_game_cards.length >= 2) {
      setTimeout(() => {

        var _cards: Array<GameCardViewModel> = []

        this.cards.forEach(val => _cards.push(Object.assign({}, val)));

        var isMatched = this.current_flipped_game_cards[0].cardType == this.current_flipped_game_cards[1].cardType

        // find this cards in array and update matched status
        for (const card of this.current_flipped_game_cards) {
          var idx = _cards.findIndex(o => o.id == card.id)
          _cards[idx].isMatch = isMatched
        }

        if (isMatched) {
          // set player marks
          var i = this.players.findIndex(o => o.playerId == this.player_id)
          this.players[i].score = this.players[i].score + 1

          // update the record
          var game_card_ids = this.current_flipped_game_cards.map(o => o.id);
          this._gameService.flip((r: CardFlipedResultModel) => {
            console.log(r);
          }, (e) => {
            console.log(e);
          }, { gameCardIds: game_card_ids, playerId: this.player_id })

        } else {
          // change player
          this.player_id = this.player_id == 1 ? 2 : 1;
        }

        this.current_flipped_game_cards = [];
        this.cards = _cards;


      }, 500);
    }
  }
}
