import { HttpClient, HttpResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
})

export class ProductService{

    constructor(private http: HttpClient){}
    baseUrl = 'http://localhost:5288/api/Product';


    getList() : Observable<HttpResponse<any>>{
        return this.http.get<any>(this.baseUrl+`/GetAllProduct`, {observe: 'response'});
    }

    addProduct(body: any) : Observable<HttpResponse<any>>{
        return this.http.post(this.baseUrl +`/AddProduct`, body, {observe: 'response'});
    }
    deleteProduct(id: any) : Observable<HttpResponse<any>>{
        return this.http.delete(this.baseUrl + `/DeteleProduct?Id=${id}`, {observe: 'response'});
    }
    updateProduct(body:any) : Observable<HttpResponse<any>>{
        return this.http.post(this.baseUrl+`/UpdateProduct`, body, {observe: 'response'});
    }
}