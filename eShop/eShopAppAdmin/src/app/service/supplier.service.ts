import { HttpClient, HttpResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable({
    providedIn:'root'
})
export class SupplierService {
    constructor(private http: HttpClient){}
//http://localhost:5288/api/Supplier/

    readonly baseUrl = 'http://localhost:5288/api/Supplier'
    getList() : Observable<HttpResponse<any>> {
        return this.http.get<any>(this.baseUrl + `/GetAllSupplier`, {observe: 'response'});
    }
    addSupplier(body: any) : Observable<HttpResponse<any>> {
        return this.http.post(this.baseUrl + `/AddSupplier`, body, {observe: 'response'});
    }
    deleteSupplier(id: any) : Observable<HttpResponse<any>>{
        return this.http.delete(this.baseUrl + `/DeleteSupplier?id=${id}`, {observe: 'response'});
    }
    findByIdSupplier(id: any): Observable<HttpResponse<any>>{
        return this.http.get<any>(this.baseUrl + `/GetByIdSupplier?id=${id}`, {observe:'response'});
    }
    updateCategory(body: any) : Observable<HttpResponse<any>>{
        return this.http.post<any>(this.baseUrl + `/UpdateSupplier`, body, {observe: 'response'});
    }
    
}