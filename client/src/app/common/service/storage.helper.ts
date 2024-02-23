import { Injectable } from "@angular/core";

@Injectable({
    providedIn: 'root'
})
export class StorageHelper {
    public add(key: string, value: any): void {
        localStorage.setItem(key, JSON.stringify(value));
    }

    public get(key: string): any {
        var item = localStorage.getItem(key);
        if (item) { return JSON.parse(item) }
        return null
    }
}
