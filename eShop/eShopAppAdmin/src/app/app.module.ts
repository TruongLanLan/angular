import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AdminComponent } from './pageAdmin/admin/admin.component';
import { DashboardComponent } from './pageAdmin/dashboard/dashboard.component';
import { ProductComponent } from './pageAdmin/product/product.component';

@NgModule({
  declarations: [
    AppComponent,
    AdminComponent,
    DashboardComponent,
    ProductComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
