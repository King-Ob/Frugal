import { Injectable } from '@angular/core';
import { ItemDetail } from './item-detail.model';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class ItemDetailService {
 formData: ItemDetail;
 readonly rootURL='http://localhost:50909/api';
 list:ItemDetail[];
  constructor(private http: HttpClient) { }

  // postItemDetail(formData:ItemDetail){
  // return this.http.post(this.rootURL+'/ItemDetail',this.formData)
  // }

  postItemDetail() {
   return this.http.post(this.rootURL + '/ItemDetails', this.formData);
 }
 putItemDetail() {
   return this.http.put(this.rootURL + '/ItemDetails/'+ this.formData.Id, this.formData);
 }
 deleteItemDetail(id) {
   return this.http.delete(this.rootURL + '/ItemDetails/'+ id);
 }

 refreshList(){
   this.http.get(this.rootURL + '/ItemDetails')
   .toPromise()
   .then(res => this.list = res as ItemDetail[]);
 }
}
