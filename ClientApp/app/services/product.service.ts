import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';
import { SaveProduct } from "../models/save-product";

@Injectable()
export class ProductService {
  private readonly productsEndpoint = 'api/products';

  constructor(private http: Http) { }

  getCategories() {
    return this.http.get('api/categories')
      .map(res => res.json());
  }

  getProducts(filter) {
    return this.http.get(this.productsEndpoint + '?' + this.toQueryString(filter))
      .map(res => res.json());
  }

  getProduct(id) {
    return this.http.get(this.productsEndpoint + '/' + id)
      .map(res => res.json());
  }

  create(product) {
    return this.http.post(this.productsEndpoint, product)
      .map(res => res.json());
  }

  update(product: SaveProduct) {
    return this.http.put(this.productsEndpoint + '/' + product.id, product)
      .map(res => res.json());
  }

  delete(id: number) {
    return this.http.delete(this.productsEndpoint + '/' + id)
      .map(res => res.json());
  }

  getTags() {
    return this.http.get('api/tags').map(res => res.json());
  }

  toQueryString(obj) {
    var parts = [];

    for(var property in obj) {
      var value = obj[property];
      if(value != null && value != undefined) 
        parts.push(encodeURIComponent(property) + '=' + encodeURIComponent(value))
    }

    return parts.join('&');
  }

}
