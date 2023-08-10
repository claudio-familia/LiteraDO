import { Component } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { AlertService } from 'src/app/core/services/alert.service';
import { StoryService } from 'src/app/features/story/services/story.service';

@Component({
  selector: 'literado-explore-detail',
  templateUrl: './explore-detail.page.html',
  styleUrls: ['./explore-detail.page.scss']
})
export class ExploreDetailPage {
  countChapters: any;
  firstChapter: any;
  constructor(
    private storyService: StoryService, 
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private alertService: AlertService,
  ) {}

  chapterDisplayedColumns: string[] = ['name', 'lines'];
  chapterDataSource = new MatTableDataSource<any>([]);
  cover: any;
  storyId: any;
  story: any;
  reads: number = 0;
  reviews: number = 0;
  state: string = 'Borrador';
  publishedDate: string = 'Jueves 10, Agosto 2023';

  ngOnInit(): void {
    this.activatedRoute.params.subscribe((param: Params) => {
      const id = param['id']
      this.storyId = id
      this.storyService.getById(id).subscribe(res => {
        this.story = res;
        this.cover = res.cover;
        this.state = res.state;
        this.reads = res.reads;
        this.reviews = res.rating;
        this.chapterDataSource.data = res.chapters;
        this.countChapters = res.chapters.length
        const orderedChapters = res.chapters.sort(function(a:any, b:any) { 
          return a.id - b.id  ||  a.name.localeCompare(b.name);
        });
        this.firstChapter = orderedChapters[0]
      })
    });
  }

  viewChapter(row: any) {
    console.log(row)
//    this.router.navigateByUrl(`/story/detail/${this.storyId}/chapter/${row.id}`)
  }
}
