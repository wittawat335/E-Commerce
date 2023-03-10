import { NavigationService } from './../shared/services/navigation.service';
import { Component, Input, OnInit } from '@angular/core';
import { Category, Product } from '../shared/models/product';
import { ResponseApi } from '../shared/Interfaces/response-api';

@Component({
  selector: 'app-suggested-products',
  templateUrl: './suggested-products.component.html',
  styleUrls: ['./suggested-products.component.css'],
})
export class SuggestedProductsComponent implements OnInit {
  @Input() category: Category = {
    id: 0,
    category: '',
    subCategory: '',
  };
  @Input() count: number = 3;
  products: Product[] = [];

  constructor(private navService: NavigationService) {}
  ngOnInit(): void {
    this.getProduct();
  }

  getProduct() {
    this.navService
      .getProducts(
        this.category.category,
        this.category.subCategory,
        this.count
      )
      .subscribe((res: any[]) => {
        for (let product of res) {
          this.products.push(product);
        }
      });
  }
}
