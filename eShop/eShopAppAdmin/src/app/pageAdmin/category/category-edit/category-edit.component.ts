import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Category } from 'src/app/model/category.model';
import { CategoryService } from 'src/app/service/category.service';

@Component({
  selector: 'app-category-edit',
  templateUrl: './category-edit.component.html',
  styleUrls: ['./category-edit.component.css']
})
export class CategoryEditComponent implements OnInit {

  data: Category = {
    id: 0,
    categoryName: '',
    active: false
  } 
  categoryId : any;
  constructor(public service: CategoryService, private toastr: ToastrService, private spin: NgxSpinnerService,
    private route: ActivatedRoute,private fb: FormBuilder,
    private navi: Router
    ) { 
    this.categoryId = this.route.snapshot.paramMap.get('id');

  }

  ngOnInit(): void {
    this.service.findByIdCategory(this.categoryId).subscribe((item)=>{
      this.data = item.body.data;
      });
  }


  
  updateForm = this.fb.group({
    categoryName: ['', Validators.compose([
      Validators.required
    ])],
    active: ['', Validators.required]
  });
  async init()
  {
    await this.service.findByIdCategory(this.categoryId).subscribe( res => {
      let body = {
        ...this.updateForm.value
      };
      this.service.updateCategory(this.categoryId).subscribe((item) => {
        this.toastr.success('delete success', 'Delete');
      });
    })
  }

  saveEdit()
  {
    let body = {
      ...this.data
    }
    this.service.updateCategory(body).subscribe((item) => {
      this.toastr.success("Edit success", "Edit category");
    });
    this.navi.navigateByUrl('/admin/category');
  }



}
