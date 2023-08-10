import { Component, OnInit, inject } from '@angular/core';
import { Breakpoints, BreakpointObserver } from '@angular/cdk/layout';
import { map } from 'rxjs/operators';
import { StoryService } from 'src/app/features/story/services/story.service';

@Component({
  selector: 'literado-explore',
  templateUrl: './explore.component.html',
  styleUrls: ['./explore.component.scss']
})
export class ExploreComponent implements OnInit {
  
  constructor(private storyService: StoryService) {}
  stories: any[] = []

  ngOnInit(): void {
    this.storyService.getPublished().subscribe((res: any) => {
      this.stories = res;
    });
  }

}
