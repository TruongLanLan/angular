import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { SupplierService } from 'src/app/service/supplier.service';

@Component({
  selector: 'app-supplier-add',
  templateUrl: './supplier-add.component.html',
  styleUrls: ['./supplier-add.component.css']
})
export class SupplierAddComponent implements OnInit {

  constructor(public service: SupplierService,
    private fb: FormBuilder,
    private toastr: ToastrService,
    private route: Router
    ) { }

  ngOnInit(): void {
  }

  addForm = this.fb.group({
    companyName: ['', Validators.compose([Validators.required])],
    address: ['', Validators.compose([Validators.required])],
    phone: ['', Validators.compose([Validators.required, Validators.minLength(10)])]

  })

  saveAdd(){
    let body = {
      ...this.addForm.value
    }
    this.service.addSupplier(body).subscribe(item => {
      this.toastr.success('add success', 'add new supplier');
    });
    this.route.navigateByUrl('/admin/supplier');
  }
  
}
