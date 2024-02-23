import { CardViewModel } from "./card-view.model"

export interface GameViewModel {
    message: string
    success: boolean
    data: Array<CardViewModel>
}