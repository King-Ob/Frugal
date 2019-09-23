import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ToastrService } from 'ngx-toastr';

import { ItemDetailService } from './../../shared/item-detail.service';

import { NgForm } from '@angular/Forms';
@Component({
  selector: 'app-item-detail',
  templateUrl: './item-detail.component.html',
  styles: []
})
export class ItemDetailComponent implements OnInit {

  constructor(public service:ItemDetailService,
  private toastr: ToastrService) { }

  ngOnInit() {
    this.resetForm();
  }

resetForm(form?:NgForm){
  if(form!=null)
  form.resetForm();
  this.service.formData={
    Id: 0,
    ItemUrl: '',
    ItemCurrentPrice: '',
    ItemSalesPrice : '',
    ItemWantedPrice : '',
    ItemStore: '',
    UserId: 0,
    ItemName: '',
  }
}
onSubmit(form: NgForm) {
    if (this.service.formData.Id == 0)
      this.insertRecord(form);
    else
      this.updateRecord(form);
  }

  insertRecord(form: NgForm) {
   this.service.postItemDetail().subscribe(
     res => {
       debugger;
       this.resetForm(form);
       this.toastr.success('Submitted successfully', 'Item Detail Register');
       this.service.refreshList();
     },
     err => {
       debugger;
       console.log(err);
     }
   )
 }

 updateRecord(form: NgForm) {
   this.service.putItemDetail().subscribe(
     res => {
       this.resetForm(form);
       this.toastr.info('Submitted successfully', 'Item Detail Register');
       this.service.refreshList();
     },
     err => {
       console.log(err);
     }
   )
 }
}
