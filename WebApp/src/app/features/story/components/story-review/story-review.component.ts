import { OnInit, Component, Input } from '@angular/core';

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

  urlImg: string = "https://placehold.co/750x600"

  ngOnInit(): void {
    console.log(this.imgUrl)
    if(this.imgUrl) {
      const src = URL.createObjectURL(this.imgUrl);      
      this.urlImg = src;
    }
    console.log(this.urlImg)
  }
}
