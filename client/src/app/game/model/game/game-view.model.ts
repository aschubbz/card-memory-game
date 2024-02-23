import { GameCardViewModel } from "./game-card-view.model";
import { GamePlayerViewModel } from "./game-player-view.model";

export interface GameViewModel {
    card:Array<GameCardViewModel>
    player:Array<GamePlayerViewModel>
}