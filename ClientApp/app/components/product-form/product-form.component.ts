import { Component, OnInit } from '@angular/core';
import { ProductService } from "../../services/product.service";
import { ToastyService } from "ng2-toasty";
import { Router, ActivatedRoute } from "@angular/router";
import { Observable } from "rxjs/Observable";
import 'rxjs/add/Observable/forkJoin';

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
      this.productService.getUsers()
    ];

    if(this.product.id)
      sources.push(this.productService.getProduct(this.product.id));

    Observable.forkJoin(sources).subscribe(
      data => {
        this.categories = data[0];
        this.users = data[1];

        if(this.product.id)
          this.product = data[2];
      },
      err => {
        if(err.status == 404)
          this.router.navigate(['/home']);
      }
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
