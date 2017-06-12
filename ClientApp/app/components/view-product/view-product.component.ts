import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from "@angular/router";
import { ProductService } from "../../services/product.service";
import { ToastyService } from "ng2-toasty";

@Component({
  selector: 'app-view-product',
  templateUrl: './view-product.component.html',
  styleUrls: ['./view-product.component.css']
})
export class ViewProductComponent implements OnInit {
  product: any;
  productId: number;
  
  constructor(
    private route: ActivatedRoute,
    private router: Router, // redirect to home when "id" isn't exist //
    private productService: ProductService,
    private toastyService: ToastyService
  ) { 
    route.params.subscribe(p => {
      this.productId = +p['id']; // the sign "+" convert "id" param to an integer //
      if(isNaN(this.productId) || this.productId <= 0) {
        router.navigate(['/products']);
        return;
      }
    });
  }

  ngOnInit() {
    this.productService.getProduct(this.productId)
      .subscribe(
        p => this.product = p,
        err => {
          if(err.status == 404) {
            this.router.navigate(['/products']);
            return;
          }
        });
  }

  delete() {
    if(confirm("Are you sure ?")) {
      this.productService.delete(this.product.id)
        .subscribe(x => {
          this.router.navigate(['/products']);
        });
    }
  }

}
