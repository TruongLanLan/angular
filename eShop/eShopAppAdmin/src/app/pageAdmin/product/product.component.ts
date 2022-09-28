import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { ConvertImagesService } from 'src/app/service/convertimage.service';
import { ProductService } from 'src/app/service/product.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  constructor(
    public service: ProductService,
    private fb: FormBuilder,
    private convert: ConvertImagesService,
    private toastr: ToastrService
  ) { }

  listProduct: any = [];
  ngOnInit(): void {
    this.init();
    
  }

  async init() {
    await this.service.getList().subscribe(item => {
      this.listProduct = item.body.data.map(idx => {
        return {
          id: idx.id,
          name: idx.name,
          price: idx.price,
          priceInput: idx.priceInput,
          pictures: idx.pictures,
          categoryName: idx.category.categoryName
        }
      });
      //console.log(this.listProduct);
    });
    
  }
  deleteProduct(id: any){
    if(confirm('Are you sure delete?'))
    {
      this.service.deleteProduct(id).subscribe(item => {
        this.toastr.success('delete success', 'Delete');
      }
        );
    }
    
    window.location.reload();
    //console.log(id);
  }
}
