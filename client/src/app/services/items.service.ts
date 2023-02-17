import { Injectable } from '@angular/core';
import { Item } from '../models/item';

@Injectable({
  providedIn: 'root',
})
export class ItemsService {
  constructor() {}

  public getItems(): Item[] {
    let item = new Item();

    item.id = 1;
    item.name = 'Item 1';
    item.quantity = 0;
    item.locationId = 1;

    return [item];
  }
}
