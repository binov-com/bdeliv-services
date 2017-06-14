import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from "@angular/router";
import { ProductService } from "../../services/product.service";
import { ToastyService } from "ng2-toasty";
import { PhotoService } from "../../services/photo.service";

@Component({
  selector: 'app-view-product',
  templateUrl: './view-product.component.html',
  styleUrls: ['./view-product.component.css']
})
export class ViewProductComponent implements OnInit {
  @ViewChild('fileInput') fileInput: ElementRef;
  product: any;
  productId: number;

  fileName: any;
  
  constructor(
    private route: ActivatedRoute,
    private router: Router, // redirect to home when "id" isn't exist //
    private toastyService: ToastyService,
    private productService: ProductService,
    private photoService: PhotoService    
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

  uploadPhoto() {
    var nativeElement: HTMLInputElement = this.fileInput.nativeElement;

    this.photoService.upload(this.productId, nativeElement.files[0])
      .subscribe(
          x=> {
            console.log(x);
            console.log(x.fileName);
            this.fileName = x.FileName;
          });
  }

}
