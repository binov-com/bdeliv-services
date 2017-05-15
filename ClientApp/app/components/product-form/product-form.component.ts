import { Component, OnInit } from '@angular/core';
import { CategorieService } from "../../services/categorie.service";
import { UserService } from "../../services/user.service";

@Component({
  selector: 'app-product-form',
  templateUrl: './product-form.component.html',
  styleUrls: ['./product-form.component.css']
})
export class ProductFormComponent implements OnInit {
  categories: any[];
  products: any[];
  users: any[];

  product: any = {};
  
  constructor(
    private categorieService: CategorieService,
    private userService: UserService
    ) { }

  ngOnInit() {
    this.categorieService.getCategories().subscribe(
      categories => this.categories = categories
    );

    this.userService.getUsers().subscribe(
      users => this.users = users
    );
  }

  onCategorieChange() {
    // console.log("PRODUCT", this.product);
    var selectedCategorie = this.categories.find(c => c.id == this.product.categorie);
    this.products = selectedCategorie ? selectedCategorie.products : [];
  }

}
