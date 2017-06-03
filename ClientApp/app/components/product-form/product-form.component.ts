import * as _ from 'underscore';
import { Component, OnInit } from '@angular/core';
import { ProductService } from "../../services/product.service";
import { ToastyService } from "ng2-toasty";
import { Router, ActivatedRoute } from "@angular/router";

import { Observable } from "rxjs/Observable";
import 'rxjs/add/Observable/forkJoin';

import { SaveProduct } from "../../models/save-product";
import { Product } from "../../models/product";

@Component({
  selector: 'app-product-form',
  templateUrl: './product-form.component.html',
  styleUrls: ['./product-form.component.css']
})
export class ProductFormComponent implements OnInit {
  categories: any[];
  //products: any[];
  tags: any[];

  product: SaveProduct = {
    id: 0,
    categoryId: 0,
    status: 0,
    reference: '',
    name: '',
    tags: []
  };
  
  constructor(
    private route: ActivatedRoute,
    private router: Router, // redirect to home when "id" isn't exist //
    private productService: ProductService,
    private toastyService: ToastyService) 
  { 
    route.params.subscribe(p => {
      this.product.id = +p['id'] // the sign "+" convert "id" param to an integer //
    });
  }

  ngOnInit() {
    
    var sources = [
      this.productService.getCategories(),
      this.productService.getTags()
    ];

    if(this.product.id)
      sources.push(this.productService.getProduct(this.product.id));

    Observable.forkJoin(sources).subscribe(
      data => {
        this.categories = data[0];
        this.tags = data[1];

        if(this.product.id)
          this.setProduct(data[2]);
      },
      err => {
        if(err.status == 404)
          this.router.navigate(['/home']);
      }
    );
  }

  private setProduct(product: Product) {
    this.product.id = product.id;
    this.product.categoryId = product.category.id;
    this.product.status = product.status;
    this.product.name = product.name;
    this.product.reference = product.reference;
    this.product.tags = _.pluck(product.tags, 'id');
  }

  
  onCategoryChange() {
    /*
    var selectedCategorie = this.categories.find(c => c.id == this.product.categoryId);
    this.products = selectedCategorie ? selectedCategorie.products : [];
    */
  }
  
  
  onTagToggle(tagId, $event) {
    if($event.target.checked)
      this.product.tags.push(tagId);
    else {
      var index = this.product.tags.indexOf(tagId);
      this.product.tags.splice(index, 1);
    }
  }
  

  submit() {
    if(this.product.id) {
      this.productService.update(this.product)
        .subscribe(x => {
          this.toastyService.success({
            title: 'Success',
            msg: 'The product was successfully updated.',
            theme: 'bootstrap',
            showClose: true,
            timeout: 5000
          });
        },
        err => console.log(err)
      );
    } else {
      this.productService.create(this.product)
      .subscribe(x => {
          this.toastyService.success({
            title: 'Success',
            msg: 'The product was successfully added.',
            theme: 'bootstrap',
            showClose: true,
            timeout: 5000
          });
        },
        err => console.log(err)
      );
    }
    
  }

  delete() {

    if(confirm("Are you sure you want delete this product?")) {
      this.productService.delete(this.product.id)
        .subscribe(x => {
          this.toastyService.success({
            title: 'Success',
            msg: 'The product was successfully deleted.',
            theme: 'bootstrap',
            showClose: true,
            timeout: 5000
          });

          this.router.navigate(['/home']);
        });
    }

  }

}
