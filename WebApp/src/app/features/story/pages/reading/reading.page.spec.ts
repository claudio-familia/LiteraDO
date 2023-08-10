import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReadingPage } from './reading.page';

describe('ReadingPage', () => {
  let component: ReadingPage;
  let fixture: ComponentFixture<ReadingPage>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ReadingPage]
    });
    fixture = TestBed.createComponent(ReadingPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
