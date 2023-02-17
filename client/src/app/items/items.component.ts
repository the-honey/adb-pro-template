import { Component } from '@angular/core';
import { ColDef, GridApi, GridReadyEvent } from 'ag-grid-community';
import { Item } from '../models/item';
import { Location } from '@angular/common';
import { ItemsService } from '../services/items.service';

@Component({
  selector: 'app-items',
  templateUrl: './items.component.html',
  styleUrls: ['./items.component.css'],
})
export class ItemsComponent {
  items: Item[] = [];
  location: Location[] = [];
  selectedItem?: Item;

  private gridApi!: GridApi<Item>;

  rowData: any[] = this.items;

  colDefs: ColDef[] = [
    { field: 'itemId', headerName: 'Id' },
    { field: 'name' },
    { field: 'quantity' },
  ];

  rowSelection: 'single' | 'multiple' = 'single';

  constructor(private itemService: ItemsService) {}

  ngOnInit(): void {
    this.itemService
      .getItems()
      .subscribe((result: Item[]) => (this.rowData = result));
  }

  onGridReady(params: GridReadyEvent<Item>) {
    this.gridApi = params.api;

    this.itemService
      .getItems()
      .subscribe((data: Item[]) => (this.rowData = data));
  }

  onSelectionChanged() {
    const selectedRows = this.gridApi.getSelectedRows();
    console.log(selectedRows[0].itemId);
  }
}
