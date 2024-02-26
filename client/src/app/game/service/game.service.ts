import { Injectable } from "@angular/core";
import { NextCallback, ErrorCallback, ServiceHelper } from "../../common/service/service.helper";
import { ErrorModel } from '../../common/models/error.model'
import { ResponseModel } from "../model/common/response.model";
import { FlipModel } from "../model/game/flip.model";
import { CardFlipedResultModel } from "../model/game/card-flip-result.model";
import { GameViewModel } from "../model/game/game-view.model";

@Injectable({
    providedIn: 'root'
})

export class GameService {
    constructor(private _: ServiceHelper) { }

    start(callback: NextCallback<ResponseModel<GameViewModel>>, error: ErrorCallback<ErrorModel>) {
        this._.api().url('start').noAuth().get(callback, error)
    }

    flip(callback: NextCallback<CardFlipedResultModel>, error: ErrorCallback<ErrorModel>, data: FlipModel) {
        this._.api().url('flip').noAuth().json(data).post(callback, error)
    }

    get_game(callback: NextCallback<ResponseModel<GameViewModel>>, error: ErrorCallback<ErrorModel>, game_id: number) {
        this._.api().url(`game/${game_id}`).noAuth().get(callback, error)
    }

    end_game(callback: NextCallback<ResponseModel<boolean>>, error: ErrorCallback<ErrorModel>, game_id: number) {
        this._.api().url(`end-game/${game_id}`).noAuth().get(callback, error)
    }
}