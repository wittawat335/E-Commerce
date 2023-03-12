/* work with Reactive Forms */
import { ReactiveFormsModule } from '@angular/forms';
/* work with http Requests  */
import { HttpClientModule } from '@angular/common/http';

/* By "ng add @angular/material" && npm i moment --s && npm i @angular/material-moment-adapter*/
/* work with material table */
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
/* work with form controls */
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MomentDateModule } from '@angular/material-moment-adapter';
/* work with alerts */
import { MatSnackBarModule } from '@angular/material/snack-bar';
/* work with icons */
import { MatIconModule } from '@angular/material/icon';
/* work with Modals */
import { MatDialogModule } from '@angular/material/dialog';
/* work with Grid */
import { MatGridListModule } from '@angular/material/grid-list';

import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CartComponent } from './cart/cart.component';
import { FooterComponent } from './footer/footer.component';
import { HeaderComponent } from './header/header.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { OrderComponent } from './order/order.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { ProductComponent } from './product/product.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { ProductsComponent } from './products/products.component';
import { RegisterComponent } from './register/register.component';
import { SuggestedProductsComponent } from './suggested-products/suggested-products.component';
import { OpenProductDetailsDirective } from './shared/directives/open-product-details.directive';
import { OpenProductsDirective } from './shared/directives/open-products.directive';
import { RouterModule } from '@angular/router';
import { JwtModule } from '@auth0/angular-jwt';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { UsersComponent } from './masters/users/users.component';
import { DialogComponent } from './shared/dialog/dialog.component';
import { GetStatusNamePipe } from './shared/pipes/get-status-name.pipe';

@NgModule({
  declarations: [
    AppComponent,
    CartComponent,
    FooterComponent,
    HeaderComponent,
    HomeComponent,
    LoginComponent,
    OrderComponent,
    PageNotFoundComponent,
    ProductComponent,
    ProductDetailsComponent,
    ProductsComponent,
    RegisterComponent,
    SuggestedProductsComponent,
    OpenProductDetailsDirective,
    OpenProductsDirective,
    UsersComponent,
    DialogComponent,
    GetStatusNamePipe,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule,
    MatTableModule,
    MatPaginatorModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatButtonModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MomentDateModule,
    MatSnackBarModule,
    MatIconModule,
    MatDialogModule,
    MatGridListModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: () => {
          return localStorage.getItem('user');
        },
        allowedDomains: ['localhost:5121'],
      },
    }),
    BrowserAnimationsModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
