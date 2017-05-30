import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class ProductService {

  constructor(private http: Http) { }

  getCategories() {
    return this.http.get('api/categories')
      .map(res => res.json());
  }

  create(product) {
    return this.http.post('api/products', product)
      .map(res => res.json());
  }

  getUsers() {
    return this.http.get('api/users').map(res => res.json());
  }


}
