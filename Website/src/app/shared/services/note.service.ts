import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { VSCollectionService, AngularHttpMapper } from 'vstack-graph';

import { environment } from '../../../environments/environment';
import { AuthService } from './auth.service';
import { ErrorService } from './error.service';
import { Note } from '../dto';

@Injectable()
export class NoteService extends VSCollectionService<Note> {

  constructor(private http: Http, private errorService: ErrorService) {
    super(new AngularHttpMapper<Note>({
      http,
      baseUrl: `${environment.api}/notes`,
      options: { headers: AuthService.getDefaultApiHeaders() }
    }));
  }

}
