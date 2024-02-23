import { Injectable } from "@angular/core";
import { NextCallback, ErrorCallback, ServiceHelper } from "../../common/service/service.helper";
import {ErrorModel} from '../../common/models/error.model'
import { ResponseModel } from "../model/common/response.model";
import { CardViewModel } from "../model/game/card-view.model";
import { FlipModel } from "../model/game/flip.model";
import { GameCardViewModel } from "../model/game/game-card-view.model";
import { CardFlipedResultModel } from "../model/game/card-flip-result.model";

@Injectable({
    providedIn: 'root'
  })
  
export class GameService {
    constructor(private _: ServiceHelper){}

    start(callback: NextCallback<ResponseModel<Array<GameCardViewModel>>>, error: ErrorCallback<ErrorModel>) {
        this._.api().url('start').noAuth().get(callback, error)
    }

    flip(callback: NextCallback<CardFlipedResultModel>, error: ErrorCallback<ErrorModel>, data:FlipModel) {
        this._.api().url('flip').noAuth().json(data).post(callback, error)
    }
}