import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './pageAdmin/admin/admin.component';
import { CategoryAddComponent } from './pageAdmin/category/category-add/category-add.component';
import { CategoryEditComponent } from './pageAdmin/category/category-edit/category-edit.component';
import { CategoryComponent } from './pageAdmin/category/category.component';
import { DashboardComponent } from './pageAdmin/dashboard/dashboard.component';
import { ProductComponent } from './pageAdmin/product/product.component';
import { SupplierAddComponent } from './pageAdmin/supplier/supplier-add/supplier-add.component';
import { SupplierComponent } from './pageAdmin/supplier/supplier.component';

const routes: Routes = [
  {
    path: 'admin',
    component: AdminComponent,
    children: [
      {path:'dashboard', component:DashboardComponent},
      {path: 'product', component: ProductComponent},
      {path: 'category', children: [
        {path:'', component:CategoryComponent},
        {path:'addnew', component: CategoryAddComponent},
        {path:'edit/:id', component:CategoryEditComponent}
      ]},
      {path:'supplier', children: [
        {path:'', component:SupplierComponent},
        {path:'addnew', component:SupplierAddComponent}
      ]}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
