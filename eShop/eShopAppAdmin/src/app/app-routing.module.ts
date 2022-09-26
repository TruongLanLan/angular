import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './pageAdmin/admin/admin.component';
import { CategoryAddComponent } from './pageAdmin/category/category-add/category-add.component';
import { CategoryEditComponent } from './pageAdmin/category/category-edit/category-edit.component';
import { CategoryComponent } from './pageAdmin/category/category.component';
import { DashboardComponent } from './pageAdmin/dashboard/dashboard.component';
import { ProductComponent } from './pageAdmin/product/product.component';

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
        {path:'edit/:id', component:CategoryEditComponent},
        {path:'delete/:id', component:CategoryComponent}
      ]}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
