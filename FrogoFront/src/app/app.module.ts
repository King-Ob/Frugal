import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule} from '@angular/forms'
import { AppComponent } from './app.component';
import { ItemDetailsComponent } from './item-details/item-details.component';
import { ItemDetailComponent } from './item-details/item-detail/item-detail.component';
import { ItemDetailListComponent } from './item-details/item-detail-list/item-detail-list.component';
import { ItemDetailService } from './shared/item-detail.service';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { ToastrModule } from 'ngx-toastr';
import { FooterComponent } from './footer/footer.component';

@NgModule({
  declarations: [
    AppComponent,
    ItemDetailsComponent,
    ItemDetailComponent,
    ItemDetailListComponent,
    FooterComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
  ],
  providers: [ItemDetailService],
  bootstrap: [AppComponent]
})
export class AppModule { }
