import { User } from './user';

export interface Product {
  id: number;
  title: string;
  description: string;
  productCategory: Category;
  offer: Offer;
  price: number;
  quantity: number;
  imageName: string;
}

export interface Offer {
  id: number;
  title: string;
  discount: number;
}

export interface Category {
  id: number;
  category: string;
  subCategory: string;
}

export interface Review {
  id: number;
  user: User;
  product: Product;
  value: string;
  createdAt: string;
}
