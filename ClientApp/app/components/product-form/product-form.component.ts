import { Component, OnInit } from '@angular/core';
import { CategorieService } from "../../services/categorie.service";

@Component({
  selector: 'app-product-form',
  templateUrl: './product-form.component.html',
  styleUrls: ['./product-form.component.css']
})
export class ProductFormComponent implements OnInit {
  categories: any[];
  products: any[];
  product: any = {};
  

  constructor(private categorieService: CategorieService) { }

  ngOnInit() {
    this.categorieService.getCategories().subscribe(
      categories => this.categories = categories
    );
  }

  onCategorieChange() {
    // console.log("PRODUCT", this.product);
    var selectedCategorie = this.categories.find(c => c.id == this.product.categorie);
    this.products = selectedCategorie ? selectedCategorie.products : [];
  }

}
