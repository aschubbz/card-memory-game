import { Component, OnInit } from '@angular/core';
import { GameService } from '../../service/game.service';
import { ResponseModel } from '../../model/common/response.model';
import { GameCardViewModel } from '../../model/game/game-card-view.model';
import { GameViewModel } from '../../model/game/game-view.model';
import { GamePlayerViewModel } from '../../model/game/game-player-view.model';
import { CardFlipedResultModel } from '../../model/game/card-flip-result.model';
import { StorageHelper } from '../../../common/service/storage.helper';
import { FLIPPED_STATE } from '../../model/enum/flipped-state.enum';
import { ErrorModel } from '../../../common/models/error.model';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrl: './main.component.scss'
})
export class MainComponent implements OnInit {
  flipped_state = FLIPPED_STATE

  cards: Array<GameCardViewModel> = []
  players: Array<GamePlayerViewModel> = []

  player_id: number = 1;
  is_game_over: boolean = false
  game_id!: number;

  current_flipped_game_cards: Array<GameCardViewModel> = [];

  constructor(private _gameService: GameService, private _store: StorageHelper) {
  }

  ngOnInit() {
    var game = this._store.get('game_id');
    if (game) {
      this.game_id = game.game_id

      this._gameService.get_game(
        (r: ResponseModel<GameViewModel>) => {
          this.cards = r.data.card;
          this.players = r.data.player
          this.set_random_player();
          this.chekc_game_over();
        }, (e) => {
          console.log(e);
        }, this.game_id
      )
    } else {
      this.create_new_game()
    }

  }

  create_new_game() {
    this._gameService.start(
      (r: ResponseModel<GameViewModel>) => {
        this.cards = r.data.card;
        this.players = r.data.player
        this._store.add('game_id', { game_id: r.data.id })
        this.game_id = r.data.id;
        this.set_random_player()
        this.is_game_over = false;
      }, (e) => {
        console.log(e);
      }
    )
  }

  set_random_player() {
    // select random player
    this.player_id = this.players[Math.floor(Math.random() * this.players.length)].playerId;
  }

  card_flipped($event: GameCardViewModel) {

    // do not add same card two times
    var idx = this.current_flipped_game_cards.find(o => o.id == $event.id)

    if (idx) return;

    this.current_flipped_game_cards.push($event)

    // match cards
    if (this.current_flipped_game_cards.length >= 2) {
      setTimeout(() => {

        var _cards: Array<GameCardViewModel> = []

        this.cards.forEach(val => _cards.push(Object.assign({}, val)));

        var isMatched = this.current_flipped_game_cards[0].cardType == this.current_flipped_game_cards[1].cardType

        for (const card of this.current_flipped_game_cards) {
          var idx = _cards.findIndex(o => o.id == card.id)
          _cards[idx].isMatch = isMatched
          _cards[idx].flipedState = isMatched ? FLIPPED_STATE.MATCHED : 0;
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

        // check game is over with this turn if so update backend
        this.chekc_game_over(true);

      }, 500);
    }
  }

  isGameOver() {
    // group cards
    const card_group = this.cards.reduce((accumulator: any, item: any) => {
      const cadType = `${item.cardType}`
      accumulator[cadType] = accumulator[cadType] ?? []
      if (!item.isMatch) {
        accumulator[cadType].push(item)
      }
      return accumulator
    }, {});

    for (const key in card_group) {
      if (card_group[key].length >= 2) {
        return false
      }

    }
    return true
  }

  // after game over flip all cards
  flip_all_cards() {
    let _cards: Array<GameCardViewModel> = [];
    this.cards.forEach(val => _cards.push(Object.assign({}, val)));

    // find this cards in array and update matched status
    for (const card of _cards) {
      if (!card.isMatch) {
        // mark as not matched and game over
        card.flipedState = FLIPPED_STATE.GAMEOVER_NOT_MATCHED
        card.isMatch = true
      } else {
        card.flipedState = FLIPPED_STATE.MATCHED
      }
    }

    this.cards = _cards;
  }

  chekc_game_over(update_backend: boolean = false) {
    // check if game is over with this flip
    this.is_game_over = this.isGameOver()

    // flip all the card if game is over
    if (this.is_game_over) {
      this.flip_all_cards();
      update_backend ? this.set_game_over() : null;
    }
  }

  set_game_over() {
    // mark game is over in back end
    this._gameService.end_game((r: ResponseModel<boolean>) => {
      console.log(r);
    }, (e: ErrorModel) => {
      console.log(e);
    }, this.game_id)
  }
}
