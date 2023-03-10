import { CartItem } from './../shared/models/cart';
import { NavigationService } from './../shared/services/navigation.service';
import {
  Component,
  ElementRef,
  OnInit,
  Type,
  ViewChild,
  ViewContainerRef,
} from '@angular/core';
import { LoginComponent } from '../login/login.component';
import { RegisterComponent } from '../register/register.component';
import { NavigationItem } from '../shared/models/navigation-item';
import { Category } from '../shared/models/product';

import { UtilityService } from '../shared/services/utility.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent implements OnInit {
  @ViewChild('modalTitle') modalTitle!: ElementRef;
  @ViewChild('container', { read: ViewContainerRef, static: true })
  container!: ViewContainerRef;
  cartItems: number = 0;

  navigationList: NavigationItem[] = [];
  constructor(
    private NavigationService: NavigationService,
    public UtilityService: UtilityService
  ) {}

  ngOnInit(): void {
    this.getCategoryList();
    // Cart
    if (this.UtilityService.isLoggedIn()) {
      this.NavigationService.getActiveCartOfUser(
        this.UtilityService.getUser().id
      ).subscribe((res: any) => {
        this.cartItems = res.cartItems.length;
      });
    }
    this.UtilityService.changeCart.subscribe((res: any) => {
      if (parseInt(res) === 0) {
        this.cartItems = 0;
      } else {
        this.cartItems += parseInt(res);
      }
    });
  }

  getCategoryList() {
    this.NavigationService.getCategoryList().subscribe((list: Category[]) => {
      for (let item of list) {
        let present = false;
        for (let navItem of this.navigationList) {
          if (navItem.category === item.category) {
            navItem.subcategories.push(item.subCategory);
            present = true;
          }
        }
        if (!present) {
          this.navigationList.push({
            category: item.category,
            subcategories: [item.subCategory],
          });
        }
      }
    });
  }

  openModal(name: string) {
    this.container.clear();
    let componentType!: Type<any>;
    if (name === 'login') {
      componentType = LoginComponent;
      this.modalTitle.nativeElement.textContent = 'Enter Login Information';
    }
    if (name === 'register') {
      componentType = RegisterComponent;
      this.modalTitle.nativeElement.textContent = 'Enter Register Information';
    }
    this.container.createComponent(componentType);
  }
}
