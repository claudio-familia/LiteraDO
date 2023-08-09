import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { StoryService } from '../../services/story.service';

@Component({
  selector: 'literado-story',
  templateUrl: './story.page.html',
  styleUrls: ['./story.page.scss']
})
export class StoryPage implements OnInit, AfterViewInit {

  @ViewChild(MatPaginator) paginator: any;
  displayedColumns: string[] = ['cover', 'title', 'literaryGenre', 'language', 'isPublish', 'rating'];
  dataSource = new MatTableDataSource<any>([]);

  constructor(private storyService: StoryService) {}

  ngOnInit(): void {
    this.storyService.get().subscribe(data => {
      this.dataSource.data = data;
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
    console.log(row)
  }
}
