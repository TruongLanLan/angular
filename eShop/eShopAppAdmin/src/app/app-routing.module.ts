import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './pageAdmin/admin/admin.component';
import { CategoryAddComponent } from './pageAdmin/category/category-add/category-add.component';
import { CategoryEditComponent } from './pageAdmin/category/category-edit/category-edit.component';
import { CategoryComponent } from './pageAdmin/category/category.component';
import { DashboardComponent } from './pageAdmin/dashboard/dashboard.component';
import { ProductAddComponent } from './pageAdmin/product/product-add/product-add.component';
import { ProductComponent } from './pageAdmin/product/product.component';
import { SupplierAddComponent } from './pageAdmin/supplier/supplier-add/supplier-add.component';
import { SupplierEditComponent } from './pageAdmin/supplier/supplier-edit/supplier-edit.component';
import { SupplierComponent } from './pageAdmin/supplier/supplier.component';

const routes: Routes = [
  {
    path: 'admin',
    component: AdminComponent,
    children: [
      {path:'dashboard', component:DashboardComponent},
      {path: 'product', children: [
        {path: '', component: ProductComponent},
        {path:'addnew', component:ProductAddComponent}
      ]},
      {path: 'category', children: [
        {path:'', component:CategoryComponent},
        {path:'addnew', component: CategoryAddComponent},
        {path:'edit/:id', component:CategoryEditComponent}
      ]},
      {path:'supplier', children: [
        {path:'', component:SupplierComponent},
        {path:'addnew', component:SupplierAddComponent},
        {path: 'edit/:id', component: SupplierEditComponent}
      ]}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
