import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RouterModule } from '@angular/router';

import { HeaderComponent } from './layout/header/header.component';
import { FooterComponent } from './layout/footer/footer.component';
import { PageTitleComponent } from './components/page-title/page-title.component';
import { CardComponent } from './components/card/card.component';
import { ControlMessagesComponent } from './components/control-messages/control-messages.component';

import { AuthService } from './services/auth.service';
import { NoteService } from './services/note.service';
import { NotebookService } from './services/notebook.service';
import { ErrorService } from './services/error.service';
import { NotificationService } from './services/notification.service';
import { ValidationService } from './services/validation.service';

@NgModule({
  imports: [
    CommonModule,
    RouterModule
  ],
  declarations: [
    HeaderComponent,
    FooterComponent,
    PageTitleComponent,
    CardComponent,
    ControlMessagesComponent
  ],
  exports: [
    HeaderComponent,
    FooterComponent,
    PageTitleComponent,
    CardComponent,
    ControlMessagesComponent
  ]
})
export class SharedModule {
  static forRoot(): ModuleWithProviders {
    return {
      ngModule: SharedModule,
      providers: [
        AuthService,
        NoteService,
        NotebookService,
        ErrorService,
        NotificationService,
        ValidationService
      ]
    };
  }
}
