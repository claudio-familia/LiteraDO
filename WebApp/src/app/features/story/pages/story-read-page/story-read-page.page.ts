import { Component, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { StoryService } from '../../services/story.service';
import { Router } from '@angular/router';
import { MatPaginator } from '@angular/material/paginator';
@Component({
  selector: 'literado-story-read-page',
  templateUrl: './story-read-page.page.html',
  styleUrls: ['./story-read-page.page.scss']
})
export class StoryReadPagePage {
  @ViewChild(MatPaginator) paginator: any;
  displayedColumns: string[] = ['cover', 'title', 'literaryGenre', 'language', 'isPublish', 'rating'];
  dataSource = new MatTableDataSource<any>([]);

  constructor(private storyService: StoryService, private router: Router) {}

  ngOnInit(): void {
    this.storyService.getReadingBooks().subscribe(data => {
      this.dataSource.data = data.stories;
    })
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  getLang(language: 'spanish' | 'english' | 'french') {
    const LANG = {
      spanish: 'Español',
      english: 'Ingles',
      french: 'Frances'
    }
    return LANG[language]
  }

  viewStory(row: any) {
    this.router.navigateByUrl("/explore/"+row.id)
  }
}
