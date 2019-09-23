import { Component, OnInit } from '@angular/core';
import { ItemDetail } from './../../shared/item-detail.model';
import { ItemDetailService } from './../../shared/item-detail.service';
import {animate, state, style, transition, trigger} from '@angular/animations';
//import { ItemDetailService } from './../../shared/item-detail.service';
//import { ItemsDetailService } from './../../shared/item-detail.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-item-detail-list',
  templateUrl: './item-detail-list.component.html',
  styles: [],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({height: '0px', minHeight: '0'})),
      state('expanded', style({height: '*'})),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],

})
export class ItemDetailListComponent implements OnInit {

  constructor(
    public service: ItemDetailService,
    private toastr: ToastrService,


  ) { }

  ngOnInit() {
    this.service.refreshList();
  }

}
