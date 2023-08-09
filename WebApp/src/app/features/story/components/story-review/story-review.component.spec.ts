import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StoryReviewComponent } from './story-review.component';

describe('StoryReviewComponent', () => {
  let component: StoryReviewComponent;
  let fixture: ComponentFixture<StoryReviewComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [StoryReviewComponent]
    });
    fixture = TestBed.createComponent(StoryReviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
