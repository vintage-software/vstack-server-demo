import { Injectable } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Observable } from 'rxjs/Observable';

import 'rxjs/add/observable/of';

import { environment } from '../../../environments/environment';
import { Account, Note, Notebook } from '../dto';
import { GraphService } from './graph.service';

export interface UserSession {
  account?: Account;
}

@Injectable()
export class AuthService {
  private _userSession: BehaviorSubject<UserSession>;
  private userSessionStore: UserSession;

  static getDefaultApiHeaders() {
    return new Headers({ 'X_XSRF': 'X_XSRF', 'Content-Type': 'application/json' });
  }

  constructor(private http: Http, private graphService: GraphService) {
    this.userSessionStore = { account: null };
    this._userSession = new BehaviorSubject(this.userSessionStore);
    this.subscribeToGraphForUpdates();
  }

  get userSession() {
    return this._userSession.asObservable();
  }

  private subscribeToGraphForUpdates() {
    this.graphService.graph.map(graph => graph.accounts).subscribe(accounts => {
      accounts.forEach(account => {
        if (account.id === this.userSessionStore.account.id) {
          let session = this.userSessionStore;
          this.userSessionStore = { account: session.account };
          this._userSession.next(session);
        }
      });
    });
  }

  private getAccount(accountId) {
    if (accountId) {
      const headers = AuthService.getDefaultApiHeaders();
      return this.http.get(`${environment.api}/accounts/${accountId}`, { headers }).map(res => res.json());
    } else {
      return Observable.of(null);
    }
  }

}
