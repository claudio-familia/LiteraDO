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


@NgModule({
  declarations: [
    StoryPage,
    CreateStoryPage,
    GeneralInformationComponent,
    StoryDetailComponent,
    StoryReviewComponent
  ],
  imports: [
    CommonModule,
    StoryRoutingModule,
    ReactiveFormsModule,
    MatCardModule,
    MatInputModule,
    MatIconModule,
    MatButtonModule
  ]
})
export class StoryModule { }
