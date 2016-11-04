import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RouterModule } from '@angular/router';

import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { PageTitleComponent } from './page-title/page-title.component';
import { CardComponent } from './card/card.component';

@NgModule({
  imports: [
    CommonModule,
    RouterModule
  ],
  declarations: [
    HeaderComponent,
    FooterComponent,
    PageTitleComponent,
    CardComponent
  ],
  exports: [
    HeaderComponent,
    FooterComponent,
    PageTitleComponent,
    CardComponent
  ],
  providers: []
})
export class SharedModule { }
