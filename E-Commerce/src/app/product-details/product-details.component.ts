import { Product, Review } from './../shared/models/product';
import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { NavigationService } from '../shared/services/navigation.service';
import { UtilityService } from '../shared/services/utility.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css'],
})
export class ProductDetailsComponent implements OnInit {
  imageIndex: number = 1;
  product!: Product;
  reviewControl = new FormControl('');
  showError = false;
  reviewSaved = false;
  otherReviews: Review[] = [];
  constructor(
    private route: ActivatedRoute, //ใช้
    private navService: NavigationService,
    public utService: UtilityService
  ) {}
  ngOnInit(): void {
    this.route.queryParams.subscribe((params: any) => {
      let id = params.id;
      console.log(id);
      this.navService.getProduct(id).subscribe((res: any) => {
        this.product = res;
        this.fetchAllReviews();
      });
    });
  }

  submitReview() {
    let review = this.reviewControl.value;
    if (review === '' || review === null) {
      this.showError = true;
      return;
    }

    // let userid = this.utService.getU;
  }

  fetchAllReviews() {
    this.otherReviews = [];
    this.navService
      .getAllReviewsOfProduct(this.product.id)
      .subscribe((res: any) => {
        for (let review of res) {
          this.otherReviews.push(review);
        }
      });
  }
}
