import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StoryQuotePagePage } from './story-quote-page.page';

describe('StoryQuotePagePage', () => {
  let component: StoryQuotePagePage;
  let fixture: ComponentFixture<StoryQuotePagePage>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [StoryQuotePagePage]
    });
    fixture = TestBed.createComponent(StoryQuotePagePage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
