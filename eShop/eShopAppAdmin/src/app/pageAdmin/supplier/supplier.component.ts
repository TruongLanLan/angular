import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { SupplierService } from 'src/app/service/supplier.service';

@Component({
  selector: 'app-supplier',
  templateUrl: './supplier.component.html',
  styleUrls: ['./supplier.component.css']
})
export class SupplierComponent implements OnInit {

  listSupplier: any = [];
  constructor(public service: SupplierService, private toastr: ToastrService, private spin: NgxSpinnerService) { }

  ngOnInit(): void {
    this.init();
  }

  async init()
  {
    this.spin.show();
    await this.service.getList().subscribe((item) => {
      this.listSupplier = item.body.data.map(idx => {
        return{
          id: idx.id,
          companyName: idx.companyName,
          address: idx.address,
          phone: idx.phone
        }
      })
    })
  }

  deleteSupplier(id: any){
    if(confirm('Are you sure to delete'))
    {
      this.service.deleteSupplier(id).subscribe(item => {
        this.toastr.success('delete success', 'Delete');
      });
    }
    window.location.reload();
  }
}
