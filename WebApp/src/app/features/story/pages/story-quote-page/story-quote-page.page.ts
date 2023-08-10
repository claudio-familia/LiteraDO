import { Component, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { StoryService } from '../../services/story.service';
import { Router } from '@angular/router';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'literado-story-quote-page',
  templateUrl: './story-quote-page.page.html',
  styleUrls: ['./story-quote-page.page.scss']
})
export class StoryQuotePagePage {
  @ViewChild(MatPaginator) paginator: any;
  displayedColumns: string[] = ['cover', 'quote', 'book', 'literaryGenre'];
  dataSource = new MatTableDataSource<any>([]);

  constructor(private storyService: StoryService, private router: Router) {}

  ngOnInit(): void {
    this.storyService.get().subscribe(data => {
      this.dataSource.data = data;
    })
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }
}
