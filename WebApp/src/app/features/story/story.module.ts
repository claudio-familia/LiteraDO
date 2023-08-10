import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { StoryRoutingModule } from './story-routing.module';
import { StoryPage } from './pages/story/story.page';
import { CreateStoryPage } from './pages/create-story/create-story.page';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { ReactiveFormsModule } from '@angular/forms';
import { GeneralInformationComponent } from './components/general-information/general-information.component';
import { StoryDetailComponent } from './components/story-detail/story-detail.component';
import { StoryReviewComponent } from './components/story-review/story-review.component';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatTableModule} from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatTabsModule } from '@angular/material/tabs';
import { DetailPage } from './pages/detail/detail.page';
import { ReadingPage } from './pages/reading/reading.page';
import { CreateChapterPage } from './pages/create-chapter/create-chapter.page';
import { StoryReadPagePage } from './pages/story-read-page/story-read-page.page';
import { StoryQuotePagePage } from './pages/story-quote-page/story-quote-page.page';


@NgModule({
  declarations: [
    StoryPage,
    CreateStoryPage,
    GeneralInformationComponent,
    StoryDetailComponent,
    StoryReviewComponent,
    DetailPage,
    ReadingPage,
    CreateChapterPage,
    StoryReadPagePage,
    StoryQuotePagePage
  ],
  imports: [
    CommonModule,
    StoryRoutingModule,
    ReactiveFormsModule,
    MatCardModule,
    MatInputModule,
    MatIconModule,
    MatButtonModule,
    MatSelectModule,
    MatSlideToggleModule,
    MatTableModule, 
    MatPaginatorModule,
    MatTabsModule
  ]
})
export class StoryModule { }
