import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product } from '../shared/models/product';
import { NavigationService } from '../shared/services/navigation.service';
import { UtilityService } from '../shared/services/utility.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css'],
})
export class ProductsComponent implements OnInit {
  view: 'grid' | 'list' = 'list';
  sortby: 'default' | 'htl' | 'lth' = 'default';
  products: Product[] = [];

  constructor(
    private activatedRoute: ActivatedRoute,
    private navService: NavigationService,
    private utService: UtilityService
  ) {}

  ngOnInit(): void {
    this.activatedRoute.queryParams.subscribe((params: any) => {
      let category = params.category;
      let subcategory = params.subcategory;

      if (category && subcategory)
        this.navService
          .getProducts(category, subcategory, 5)
          .subscribe((res: any) => {
            this.products = res;
          });
    });
  }

  //ใช้ Function Array Sort ของ JavaScript
  sortByPrice(sortKey: string) {
    this.products.sort((a, b) => {
      if (sortKey === 'default') {
        return a.id > b.id ? 1 : -1;
      }
      return (
        (sortKey === 'htl' ? 1 : -1) *
        (this.utService.applyDiscount(a.price, a.offer.discount) >
        this.utService.applyDiscount(b.price, b.offer.discount)
          ? -1
          : 1)
      );
    });
  }
}
