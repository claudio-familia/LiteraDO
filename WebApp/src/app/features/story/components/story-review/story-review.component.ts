import { OnInit, Component, Input, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'literado-story-review',
  templateUrl: './story-review.component.html',
  styleUrls: ['./story-review.component.scss']
})
export class StoryReviewComponent implements OnInit {
  @Input() title: string = '';
  @Input() category: string = '';
  @Input() imgUrl: any;
  @Input() description: string = '';
  @Output() create: EventEmitter<any> = new EventEmitter();

  urlImg: string = "https://placehold.co/750x600"

  ngOnInit(): void {
    if(this.imgUrl) {
      this.urlImg = this.imgUrl;
    }
  }

  submit(): void {
    this.create.emit();
  }
}
