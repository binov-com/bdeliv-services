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
  queryResult: any = {};

  query: any = {
    pageSize: 3
  };

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
      .subscribe(result => this.queryResult = result);
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

  onPageChange(page) {
    this.query.page = page;
    this.populateProducts();
  }
}
