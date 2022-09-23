import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './pageAdmin/admin/admin.component';
import { DashboardComponent } from './pageAdmin/dashboard/dashboard.component';
import { ProductComponent } from './pageAdmin/product/product.component';

const routes: Routes = [
  {
    path: 'admin',
    component: AdminComponent,
    children: [
      {path:'dashboard', component:DashboardComponent},
      {path: 'product', component: ProductComponent}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
