import { Component, OnInit, SimpleChanges } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { reduce, retry } from 'rxjs';
import { CategoryService } from 'src/app/service/category.service';
import { ConvertImagesService } from 'src/app/service/convertimage.service';
import { ProductService } from 'src/app/service/product.service';
import { SupplierService } from 'src/app/service/supplier.service';
import { CKEditor4 } from 'ckeditor4-angular/ckeditor';

@Component({
  selector: 'app-product-add',
  templateUrl: './product-add.component.html',
  styleUrls: ['./product-add.component.css']
})
export class ProductAddComponent implements OnInit {

  imageList: any = [];
  listCate: any;
  listSupli: any;
  editDescription: any;
  constructor(
    public service: ProductService,
    private route: Router,
    private fb: FormBuilder,
    private convert: ConvertImagesService,
    private supplier: SupplierService,
    private category: CategoryService
    ) { }


  ngOnInit(): void {
    this.getListCateAndSupli();
  }


  formData = this.fb.group({
    name: ['', Validators.required],
    price: ['', Validators.required],
    priceInput: ['', Validators.required],
    sale: ['', Validators.required],
    inventory: ['', Validators.required],
    insurance: ['', Validators.required],
    accessory: ['', Validators.required],
    imageProcessor: ['', Validators.required],
    screen: ['', Validators.required],
    iso: ['', Validators.required],
    shutterSpeed: ['', Validators.required],
    categoryId: ['', Validators.required],
    supplierId: ['', Validators.required],
    sensor: ['', Validators.required],
    
  })

  formImages = new FormGroup({
    name: new FormControl ('',Validators.required),
    file: new FormControl ('',Validators.required),
    fileSource: new FormControl ('',Validators.required)
  })
  saveAdd(){
    //debugger;
    let body = {
      ...this.formData.value,
      description: this.editDescription,
      pictures: this.imageList
    };
    //console.log('productsss',body)
    this.service.addProduct(body);
    this.route.navigateByUrl('/admin/product');
  }

  async getListCateAndSupli()
  {
    this.category.getList().subscribe(item=> {
      this.listCate = item.body.data
    });
    this.supplier.getList().subscribe(item => {
      this.listSupli = item.body.data
    });
  }

  onFileChange(event: any){
    var file = event.target.files.length;
    for(let i = 0; i< file; i++)
    {
      var reader = new FileReader();
      reader.onload = (event:any)=>{
        let imagesObj = {image: event.target.result};
        this.imageList.push(imagesObj);
        this.formImages.patchValue({
          fileSource: this.imageList
        });
      };
      reader.readAsDataURL(event.target.files[i]);
    }
  }
  get f(){
    return this.formImages.controls;
  }

  handleDeleteImage(item){
    this.imageList.splice(item,1);
  }
  onChange(event: CKEditor4.EventInfo){
    this.editDescription = event.editor.getData();
  }
}
