import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateChapterPage } from './create-chapter.page';

describe('CreateChapterPage', () => {
  let component: CreateChapterPage;
  let fixture: ComponentFixture<CreateChapterPage>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CreateChapterPage]
    });
    fixture = TestBed.createComponent(CreateChapterPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
