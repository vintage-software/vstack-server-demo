import { NoteApplicationPage } from './app.po';

describe('note-application App', function() {
  let page: NoteApplicationPage;

  beforeEach(() => {
    page = new NoteApplicationPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
