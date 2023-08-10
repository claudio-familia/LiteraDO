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
  orderedChapters: any;
  currentChapter: any;
  selection: string = '';
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
  hasSelection: boolean = false;

  ngOnInit(): void {
    this.activatedRoute.params.subscribe((param: Params) => {
      const id = param['id']
      const chapterId = param['chapterId']
      this.storyId = id
      this.storyService.getById(id).subscribe(res => {
        this.story = res;
        this.countChapters = res.chapters.length
        this.orderedChapters = res.chapters.sort(function(a:any, b:any) { 
          return a.id - b.id  ||  a.name.localeCompare(b.name);
        });
        this.isFirstChapter = this.orderedChapters[0].id == chapterId;
        this.isLastChapter = this.orderedChapters[this.orderedChapters.length - 1].id == chapterId;
        this.currentChapter = this.orderedChapters.findIndex((i: any) => i.id == chapterId);
        this.previousChapter = this.orderedChapters[this.currentChapter-1]
        this.nextChapter = this.orderedChapters[this.currentChapter+1]
      })
      this.storyChapterService.getById(chapterId).subscribe(res => {
        this.chapter = res;
      })
      this.storyService.getReadingInformation(id).subscribe(async (response: any) => {
        let id = response.id;
        if(!response) {
          const response: any = await this.storyService.createReadingInformation(id).toPromise();
          id = response.id;
        } else {
          if(chapterId != response.chapterWhereTheyLeft) {
            this.router.navigateByUrl(`story/reading/${this.storyId}/chapter/${response.chapterWhereTheyLeft}`)
          }
        }
        await this.storyService.saveReadingInformation(id, chapterId).toPromise()
      });
    });
  }

  getSelection(evt: any): void {
    const val: string = this.chapter.description.toString();
    const selection = val.substring(evt.target.selectionStart, evt.target.selectionEnd);
    this.hasSelection = true;
    this.selection = selection;
  }

  saveFavorite(): void {
    this.alertService.ModalNotification("Existo", "Selección guardada como favorita", "success").then(() => {
      this.hasSelection = false;
      this.selection = '';
    });
  }

  viewChapter(row: any) {
    console.log(row)
//    this.router.navigateByUrl(`/story/detail/${this.storyId}/chapter/${row.id}`)
  }
}
