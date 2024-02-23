import { Component, Input, OnInit } from '@angular/core';
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

  constructor(private _gameService: GameService) { }

  ngOnInit() {
    this.card_image = `${(window as any).apiHost}cdn/cards/${this._card.image}`;
  }
  card_image: string = ""

  flip_card(index: number) {
    this._gameService.flip((r: CardFlipedResultModel) => {
      this.card_image = `${(window as any).apiHost}cdn/cards/${r.card.image}`;
    }, e => {
    }, { gameCardId: this._card.id, playerId: 1 })
  }
}
