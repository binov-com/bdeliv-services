import { Component, OnInit } from '@angular/core';
import { CategorieService } from "../../services/categorie.service";

@Component({
  selector: 'app-product-form',
  templateUrl: './product-form.component.html',
  styleUrls: ['./product-form.component.css']
})
export class ProductFormComponent implements OnInit {
  categories;

  constructor(private categorieService: CategorieService) { }

  ngOnInit() {
    this.categorieService.getCategories().subscribe(
      categories => {
        this.categories = categories;
        console.log("CATEGORIES", this.categories);
      }
    );

    

  }

}
