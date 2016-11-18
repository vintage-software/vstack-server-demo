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
    super([]);
  }
}