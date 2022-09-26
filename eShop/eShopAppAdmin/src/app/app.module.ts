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

@NgModule({
  declarations: [
    AppComponent,
    AdminComponent,
    DashboardComponent,
    ProductComponent,
    CategoryComponent,
    CategoryAddComponent,
    CategoryEditComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    ToastrModule.forRoot()
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
