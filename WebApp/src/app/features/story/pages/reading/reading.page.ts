import { Component } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { AlertService } from 'src/app/core/services/alert.service';
import { StoryService } from '../../services/story.service';
import { StoryChapterService } from '../../services/story-chapter.service';

@Component({
  selector: 'literado-reading',
  templateUrl: './reading.page.html',
  styleUrls: ['./reading.page.scss']
})
export class ReadingPage {
  countChapters: any;
  chapter: any;
  nextChapter: any;
  previousChapter: any;
  constructor(
    private storyService: StoryService, 
    private storyChapterService: StoryChapterService, 
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private alertService: AlertService,
  ) {}

  cover: any;
  storyId: any;
  story: any;
  reads: number = 0;
  reviews: number = 0;
  state: string = 'Borrador';
  publishedDate: string = 'Jueves 10, Agosto 2023';
  isFirstChapter: boolean = false;
  isLastChapter: boolean = false;

  ngOnInit(): void {
    this.activatedRoute.params.subscribe((param: Params) => {
      const id = param['id']
      const chapterId = param['chapterId']
      console.log(param)
      this.storyId = id
      this.storyService.getById(id).subscribe(res => {
        this.story = res;
        this.countChapters = res.chapters.length
        const orderedChapters = res.chapters.sort(function(a:any, b:any) { 
          return a.id - b.id  ||  a.name.localeCompare(b.name);
        });
        this.isFirstChapter = orderedChapters[0].id == chapterId;
        this.isLastChapter = orderedChapters[orderedChapters.length - 1].id == chapterId;
        const currentChapter = orderedChapters.findIndex((i: any) => i.id == chapterId);
        this.previousChapter = orderedChapters[currentChapter-1]
        this.nextChapter = orderedChapters[currentChapter+1]
      })
      this.storyChapterService.getById(chapterId).subscribe(res => {
        this.chapter = res;
      })
    });
  }

  viewChapter(row: any) {
    console.log(row)
//    this.router.navigateByUrl(`/story/detail/${this.storyId}/chapter/${row.id}`)
  }
}
