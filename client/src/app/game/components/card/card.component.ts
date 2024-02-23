import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { CardViewModel } from '../../model/game/card-view.model';
import { GameService } from '../../service/game.service';
import { GameCardViewModel } from '../../model/game/game-card-view.model';
import { CardFlipedResultModel } from '../../model/game/card-flip-result.model';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrl: './card.component.scss'
})
export class CardComponent implements OnInit {

  @Input('_card') _card!: GameCardViewModel;
  @Input('_playerId') _playerId!: number;
  @Output() _playerChanged = new EventEmitter<number>();
  @Output() change_player_score = new EventEmitter<any>();


  constructor(private _gameService: GameService) { }

  ngOnInit() {
    this.card_image = `${(window as any).apiHost}cdn/cards/${this._card.image}`;
  }
  card_image: string = ""

  flip_card(index: number) {
    this._gameService.flip((r: CardFlipedResultModel) => {
      console.log(r);
      
      this.card_image = `${(window as any).apiHost}cdn/cards/${r.card.image}`;
      
      if (!r.isHaveAnotherChance) {
        this._playerId = this._playerId == 1 ? 2 : 1
        this._playerChanged.emit(this._playerId)
      }

      if (r.isMatch) {
        this.change_player_score.emit({playerId:this._playerId, score:r.score})
      }
    }, e => {
    }, { gameCardId: this._card.id, playerId: this._playerId })
  }
}
