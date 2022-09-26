import { Injectable } from "@angular/core";
import {HttpClient,HttpHeaders, HttpResponse} from "@angular/common/http";
import { Category } from "../model/category.model";
import { Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
})

export class CategoryService {

    constructor(private http: HttpClient) {}

    readonly baseURL = 'http://localhost:5288/api/Category'


    getList(): Observable<HttpResponse<any>>{
       // this.http.get(this.baseURL+'/GetAllCategory')
       // .toPromise()
        //.then(res=> this.listCategory = res as Category[]);
        
        return this.http.get<any>(this.baseURL + `/GetAllCategory`, {observe: 'response'});
    }

    addCategory(body: any) : Observable<HttpResponse<any>>{
        return this.http.post(this.baseURL + `/AddCategory`,body, {observe: 'response'});
    }
    deleteCategory(id: any) : Observable<HttpResponse<any>>{
        return this.http.delete(this.baseURL + `/DeleteCategory?id=${id}`, {observe: 'response'});
    }
}