import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Item } from '../models/item';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ItemsService {
  private url = 'Item';

  constructor(private http: HttpClient) {}

  public getItems(): Observable<Item[]> {
    return this.http.get<Item[]>(`${environment.apiUrl}/${this.url}`);
  }

  public updateItem(item: Item): Observable<Item[]> {
    return this.http.put<Item[]>(`${environment.apiUrl}/${this.url}`, item);
  }

  public createItem(item: Item): Observable<Item[]> {
    return this.http.post<Item[]>(`${environment.apiUrl}/${this.url}`, item);
  }

  public deleteItem(item: Item): Observable<Item[]> {
    return this.http.delete<Item[]>(
      `${environment.apiUrl}/${this.url}/${item.itemId}`
    );
  }
}
