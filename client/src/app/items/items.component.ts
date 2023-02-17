import { Component } from '@angular/core';
import { ColDef } from 'ag-grid-community';

@Component({
  selector: 'app-items',
  templateUrl: './items.component.html',
  styleUrls: ['./items.component.css'],
})
export class ItemsComponent {
  rowData: any[] = [
    { id: '1', name: 'cucc1', quantity: '0' },
    { id: '2', name: 'cucc2', quantity: '0' },
  ];

  colDefs: ColDef[] = [
    { field: 'id' },
    { field: 'name' },
    { field: 'quantity' },
  ];

  rowSelection: 'single' | 'multiple' = 'single';
}
