import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';
import { SaveProduct } from "../models/save-product";

@Injectable()
export class ProductService {

  constructor(private http: Http) { }

  getCategories() {
    return this.http.get('api/categories')
      .map(res => res.json());
  }

  getProduct(id) {
    return this.http.get('api/products/' + id)
      .map(res => res.json());
  }

  create(product: SaveProduct) {
    return this.http.post('api/products', product)
      .map(res => res.json());
  }

  update(product: SaveProduct) {
    return this.http.put('api/products/' + product.id, product)
      .map(res => res.json());
  }

  getTags() {
    return this.http.get('api/tags').map(res => res.json());
  }

}
