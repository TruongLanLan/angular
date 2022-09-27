import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Supplier } from 'src/app/model/supplier.model';
import { SupplierService } from 'src/app/service/supplier.service';

@Component({
  selector: 'app-supplier-edit',
  templateUrl: './supplier-edit.component.html',
  styleUrls: ['./supplier-edit.component.css']
})
export class SupplierEditComponent implements OnInit {

  data: Supplier = {
    id: 0,
    companyName: '',
    address: '',
    phone: ''
  }
  supplierId: any;
  constructor(public service: SupplierService,
    private toastr: ToastrService,
    private spin: NgxSpinnerService,
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private navi: Router) {
      this.supplierId = this.route.snapshot.paramMap.get('id');

     }

  ngOnInit(): void {
    this.service.findByIdSupplier(this.supplierId).subscribe(item => {
      this.data = item.body.data;
    });
  }


  updateForm = this.fb.group({
    companyName: ['',Validators.compose([
      Validators.required
    ])],
    address: ['',Validators.compose([
      Validators.required
    ])],
    phone: ['',Validators.compose([
      Validators.required
    ])]
  });

  saveEdit()
  {
    let body = {
      ...this.data
    }
    this.service.updateCategory(body).subscribe(item => {
      this.toastr.success('edit success', 'edit category');
    });
    this.navi.navigateByUrl('/admin/supplier');
  }

}
