import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { StoryRoutingModule } from './story-routing.module';
import { StoryPage } from './pages/story/story.page';
import { CreateStoryPage } from './pages/create-story/create-story.page';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';


@NgModule({
  declarations: [
    StoryPage,
    CreateStoryPage
  ],
  imports: [
    CommonModule,
    StoryRoutingModule,
    MatCardModule,
    MatInputModule,
    MatIconModule
  ]
})
export class StoryModule { }
