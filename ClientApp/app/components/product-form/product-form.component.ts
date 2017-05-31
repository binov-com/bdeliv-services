import { Component, OnInit } from '@angular/core';
import { ProductService } from "../../services/product.service";
import { ToastyService } from "ng2-toasty";

@Component({
  selector: 'app-product-form',
  templateUrl: './product-form.component.html',
  styleUrls: ['./product-form.component.css']
})
export class ProductFormComponent implements OnInit {
  categories: any[];
  products: any[];
  users: any[];

  product: any = {
    users: []
  };
  
  constructor(
    private productService: ProductService,
    private toastyService: ToastyService) { }

  ngOnInit() {
    this.productService.getCategories().subscribe(
      categories => this.categories = categories
    );

    this.productService.getUsers().subscribe(
      users => this.users = users
    );
  }

  onCategoryChange() {
    // console.log("PRODUCT", this.product);
    var selectedCategorie = this.categories.find(c => c.id == this.product.categoryId);
    this.products = selectedCategorie ? selectedCategorie.products : [];
  }

  onUserToggle(userId, $event) {
    if($event.target.checked)
      this.product.users.push(userId);
    else {
      var index = this.product.users.indexOf(userId);
      this.product.users.splice(index, 1);
    }
  }

  submit() {
    this.productService.create(this.product)
      .subscribe(x => console.log(x));
  }

}
