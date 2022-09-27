import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AdminComponent } from './pageAdmin/admin/admin.component';
import { DashboardComponent } from './pageAdmin/dashboard/dashboard.component';
import { ProductComponent } from './pageAdmin/product/product.component';
import { CategoryComponent } from './pageAdmin/category/category.component';
import { HttpClientModule } from '@angular/common/http';
import { CategoryAddComponent } from './pageAdmin/category/category-add/category-add.component';
import { CategoryEditComponent } from './pageAdmin/category/category-edit/category-edit.component';
import { ToastrModule } from 'ngx-toastr';
import { NgxSpinnerModule } from 'ngx-spinner';
import { NgxPaginationModule } from 'ngx-pagination';
import { SupplierComponent } from './pageAdmin/supplier/supplier.component';
import { SupplierAddComponent } from './pageAdmin/supplier/supplier-add/supplier-add.component';
import { SupplierEditComponent } from './pageAdmin/supplier/supplier-edit/supplier-edit.component';

@NgModule({
  declarations: [
    AppComponent,
    AdminComponent,
    DashboardComponent,
    ProductComponent,
    CategoryComponent,
    CategoryAddComponent,
    CategoryEditComponent,
    SupplierComponent,
    SupplierAddComponent,
    SupplierEditComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    NgxPaginationModule,
    ToastrModule.forRoot()
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
