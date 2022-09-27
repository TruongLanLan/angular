import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { CategoryService } from 'src/app/service/category.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { Router } from '@angular/router';
import { Category } from 'src/app/model/category.model';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {

  listCategory: any = [];
  constructor(public service: CategoryService, private toastr: ToastrService, private spin: NgxSpinnerService,private route: Router) { }

  ngOnInit(): void {
    
    this.init();
    
  }
  async init()
  {
    
    this.spin.show();
    await this.service.getList().subscribe( (item) => {
      let dt = item.body.data.map((item) => {
        return {
          id: item.id,
          categoryName: item.categoryName,
          active: item.active
        };
      });
      this.listCategory = dt;
    });

  }
  deleteCategory(id: any){
    //debugger;
    if(confirm('Are you sure to delete'))
    {
      this.service.deleteCategory(id).subscribe((item) => {
        this.toastr.success('delete success', 'Delete');
      });
      
    }
    window.location.reload();
    
  }


 
}
