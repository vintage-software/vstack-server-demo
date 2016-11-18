/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { NotebookService } from './notebook.service';

describe('Service: Notebook', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [NotebookService]
    });
  });

  it('should ...', inject([NotebookService], (service: NotebookService) => {
    expect(service).toBeTruthy();
  }));
});
