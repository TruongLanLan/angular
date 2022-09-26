import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { CategoryService } from 'src/app/service/category.service';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {

  listCategory: any = [];
  constructor(public service: CategoryService, private toastr: ToastrService) { }

  ngOnInit(): void {
    
    this.init();

  }

  async init()
  {
    this.service.getList().subscribe( (item) => {
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
    this.service.deleteCategory(id).subscribe((item) => {
      this.toastr.success('delete success', 'Delete');
    });
  }
}
