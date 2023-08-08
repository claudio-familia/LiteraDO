import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Detail } from '../../models/story';

@Component({
  selector: 'literado-story-detail',
  templateUrl: './story-detail.component.html',
  styleUrls: ['./story-detail.component.scss']
})
export class StoryDetailComponent {
  @Output() storyDetailForm: EventEmitter<Detail> = new EventEmitter<Detail>;
  @Input() detailForm?: any;

  constructor(
  ) {}

  ngOnInit(): void {
    console.log('Method not implemented.');
  }

  onSubmit(): void {
    if(this.detailForm && this.detailForm.valid) {
      this.detailForm?.emit(this.detailForm.value as unknown as Detail);
    }
  }
}
