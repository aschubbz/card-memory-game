import { CardViewModel } from "./card-view.model"

export interface CardFlipedResultModel {

    card: CardViewModel
    isMatch: boolean,
    success: boolean,
    message: string,
    isHaveAnotherChance: boolean
    score:number

}