import { Injectable } from '@angular/core';
import { BaseGraphService, ServiceConfig, Relation } from 'vstack-graph';

import { Account, Note, Notebook } from './../../shared/dto';

import { AccountService } from './account.service';
import { NoteService } from './note.service';
import { NotebookService } from './notebook.service';

export class Graph {
  accounts: Account[];
  notes: Note[];
  notebooks: Notebook[];
}

@Injectable()
export class GraphService extends BaseGraphService<Graph> {
  constructor(
    public accountService: AccountService,
    public noteService: NoteService,
    public notebookService: NotebookService
  ) {
    super([
      new ServiceConfig<Account, Graph>(accountService, (graph, collection) => graph.accounts = collection, []),
      new ServiceConfig<Note, Graph>(noteService, (graph, collection) => graph.notes = collection, [
        // new Relation('notebooks', notebookService, 'notebookId', false)
      ]),
      new ServiceConfig<Notebook, Graph>(notebookService, (graph, collection) => graph.notebooks = collection, [
        // new Relation('account', accountService, 'accountId', false),
        // new Relation('note', noteService, 'notes', true)
      ]),
    ]);
  }
}