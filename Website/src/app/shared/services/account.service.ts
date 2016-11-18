import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { VSCollectionService, AngularHttpMapper } from 'vstack-graph';

import { environment } from '../../../environments/environment';
import { AuthService } from './auth.service';
import { ErrorService } from './error.service';
import { Account } from '../dto';

@Injectable()
export class AccountService extends VSCollectionService<Account> {

  constructor(private http: Http, private errorService: ErrorService) {
    super(new AngularHttpMapper<Account>({
      http,
      baseUrl: `${environment.api}/accounts`,
      options: { headers: AuthService.getDefaultApiHeaders() }
    }));
  }

}
