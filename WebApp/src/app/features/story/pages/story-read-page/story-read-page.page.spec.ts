import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StoryReadPagePage } from './story-read-page.page';

describe('StoryReadPagePage', () => {
  let component: StoryReadPagePage;
  let fixture: ComponentFixture<StoryReadPagePage>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [StoryReadPagePage]
    });
    fixture = TestBed.createComponent(StoryReadPagePage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
