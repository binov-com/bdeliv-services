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

  query: any = {};

  columns = [
    { title: 'Id' },
    { title: 'Categorie', key: 'category', isSortable: true },
    { title: 'Référence', key: 'reference', isSortable: true },
    { title: 'Libellé', key: 'name', isSortable: true },
  ];
  
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
    this.query = {};

    this.onFilterChange();
  }

  private populateProducts() {
    this.productService.getProducts(this.query)
      .subscribe(products => this.products = products);
  }

  sortBy(columnName) {
    if(this.query.sortBy === columnName) {
      this.query.isSortAscending = !this.query.isSortAscending;
    }
    else {
      this.query.sortBy = columnName;
      this.query.isSortAscending = true;
    }

    this.populateProducts();
  }
}
