import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CategoryService } from 'src/app/service/category.service';

@Component({
  selector: 'app-category-add',
  templateUrl: './category-add.component.html',
  styleUrls: ['./category-add.component.css']
})
export class CategoryAddComponent implements OnInit {

  constructor(private fb: FormBuilder, public service: CategoryService, private toastr: ToastrService, private route: Router) { }

  ngOnInit(): void {

    
  }

  addForm = this.fb.group({
    categoryName: ['', Validators.compose([
      Validators.required
    ])],
    active: true
  });

  saveAdd(){
    if(this.addForm.value.categoryName == '')
    {
      this.toastr.warning('Category name not null', 'Note');
    }
    else{
      let body = {
        ...this.addForm.value
      }
      this.service.addCategory(body).subscribe((item) => {
        this.toastr.success('Add success', 'Add new category');
      });
      this.route.navigateByUrl('/admin/category');
    }
    
  }

}
