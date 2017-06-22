import { Component, OnInit } from '@angular/core';
import { ProductService } from "../../services/product.service";

import { Product } from "../../models/product";
import { Category } from "../../models/category";
import { AuthService } from "../../services/auth.service";

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  private readonly PAGE_SIZE = 3;

  categories: Category[];
  queryResult: any = {};

  query: any = {
    pageSize: this.PAGE_SIZE
  };

  columns = [
    { title: 'Id' },
    { title: 'Categorie', key: 'category', isSortable: true },
    { title: 'Référence', key: 'reference', isSortable: true },
    { title: 'Libellé', key: 'name', isSortable: true },
  ];
  
  constructor(private productService: ProductService, private auth: AuthService) { }

  ngOnInit() {
    this.productService.getCategories()
      .subscribe(categories => this.categories = categories);

    this.populateProducts();
  }

  onFilterChange() {
    this.query.page = 1;
    this.populateProducts();
  }

  resetFilter() {
    this.query = {
      page: 1,
      pageSize: this.PAGE_SIZE
    };

    this.populateProducts();
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
