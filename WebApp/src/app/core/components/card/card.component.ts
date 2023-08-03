import { Component,Input,OnInit } from '@angular/core';

@Component({
  selector: 'literado-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.scss']
})
export class CardComponent {
  @Input({ required: true }) name!: String;
  @Input({ required: true }) title!: String;
  @Input({ required: true }) image!: String;
  @Input({ required: true }) content!: String;

  ngOnInit(): void {
  }
}