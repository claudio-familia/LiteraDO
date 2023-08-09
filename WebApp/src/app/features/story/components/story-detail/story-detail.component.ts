import { Component, ElementRef, EventEmitter, Input, Output, ViewChild } from '@angular/core';
import { Detail } from '../../models/story';

@Component({
  selector: 'literado-story-detail',
  templateUrl: './story-detail.component.html',
  styleUrls: ['./story-detail.component.scss']
})
export class StoryDetailComponent {
  @Output() storyDetailForm: EventEmitter<Detail> = new EventEmitter<Detail>;
  @Output() goBackMethod: EventEmitter<any> = new EventEmitter<any>;;
  @Input() detailForm?: any;
  @ViewChild('tagInput') tagInput?: ElementRef<HTMLInputElement>;
  selectedTags: string = '';

  constructor(
  ) {}

  ngOnInit(): void {
    console.log('Method not implemented.');
  }

  addTag(evt: any) {
    const value = evt.value;
    const array = this.selectedTags.split(',');
    array.push(value);
    this.selectedTags = array.filter(v => v).join();
    this.tagInput!.nativeElement.value = "";
  }

  deleteTag(tag: string): void {
    const array = this.selectedTags.split(',');
    this.selectedTags = array.filter(v => v !== tag).join();
  }

  goBack(): void {
    this.goBackMethod.emit("information");
  }

  onSubmit(): void {
    if(this.detailForm && this.detailForm.valid) {
      this.storyDetailForm.emit(this.detailForm.value as unknown as Detail);
    }
  }
}
