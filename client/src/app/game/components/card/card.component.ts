import { Component, EventEmitter, Input, OnInit, Output, SimpleChange } from '@angular/core';
import { GameCardViewModel } from '../../model/game/game-card-view.model';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrl: './card.component.scss'
})
export class CardComponent implements OnInit {

  @Input('_card') _card!: GameCardViewModel;
  @Output() _card_flipped = new EventEmitter<GameCardViewModel>();


  constructor() { }

  ngOnInit() {
    this.setCardImage()
  }
  card_image: string = ""

  flip_card(index: number) {
    // user not able to select matched cards
    if(this._card.isMatch) {
      return;
    }
    this.card_image = `${(window as any).apiHost}cdn/cards/${this._card.image}`;
    this._card_flipped.emit(this._card);
  }

  ngOnChanges(changes: SimpleChange) {
    // console.log(changes);
  }

  setCardImage() {
    if (!this._card.isMatch) {
      this.card_image = `${(window as any).apiHost}cdn/cards/${this._card.imageDefault}`;
    } else {
      this.card_image = `${(window as any).apiHost}cdn/cards/${this._card.image}`;
    }
  }
}
