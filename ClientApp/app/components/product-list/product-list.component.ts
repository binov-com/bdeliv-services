import { Component, OnInit } from '@angular/core';
import { ProductService } from "../../services/product.service";

import { Product } from "../../models/product";
import { Category } from "../../models/category";

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  categories: Category[];
  products: Product[];

  filter: any = {};
  
  constructor(private productService: ProductService) { }

  ngOnInit() {
    this.productService.getCategories()
      .subscribe(categories => this.categories = categories);

    this.populateProducts();
  }

  onFilterChange() {
    this.populateProducts();
  }

  resetFilter() {
    this.filter = {};

    this.onFilterChange();
  }

  private populateProducts() {
    this.productService.getProducts(this.filter)
      .subscribe(products => this.products = products);
  }
}
