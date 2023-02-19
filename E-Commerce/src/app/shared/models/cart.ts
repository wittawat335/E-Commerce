import { Product } from './product';
import { User } from './user';

export interface CartItem {
  id: number;
  product: Product;
}

export interface Cart {
  id: number;
  user: User;
  cartItems: CartItem[];
  ordered: boolean;
  orderedOn: string;
}
