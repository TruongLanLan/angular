import { Injectable } from "@angular/core";

@Injectable({
    providedIn: 'root'
})
export class ConvertImagesService {

    constructor(){}
    createImagePath = (serverPath: string) => {
        return `http://localhost:5288/${serverPath}`;
    }
}