import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { VSCollectionService, AngularHttpMapper } from 'vstack-graph';

import { environment } from '../../../environments/environment';
import { AuthService } from './auth.service';
import { ErrorService } from './error.service';
import { Notebook } from '../dto';

@Injectable()
export class NotebookService extends VSCollectionService<Notebook> {

  constructor(private http: Http, private errorService: ErrorService) {
    super(new AngularHttpMapper<Notebook>({
      http,
      baseUrl: `${environment.api}/notebooks`,
      options: { headers: AuthService.getDefaultApiHeaders() }
    }));
  }

}
