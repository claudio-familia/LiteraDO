import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StoryPage } from './pages/story/story.page';
import { CreateStoryPage } from './pages/create-story/create-story.page';
import { DetailPage } from './pages/detail/detail.page';
import { CreateChapterPage } from './pages/create-chapter/create-chapter.page';
import { ReadingPage } from './pages/reading/reading.page';

const routes: Routes = [
  {
    path: "", component: StoryPage
  },
  {
    path: "create", component: CreateStoryPage
  },
  {
    path: "detail/:id", component: DetailPage
  },
  {
    path: "detail/:id/chapter", component: CreateChapterPage
  },
  {
    path: "detail/:id/chapter/:chapterId", component: CreateChapterPage
  },
  {
    path: "reading/:id/chapter/:chapterId", component: ReadingPage
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class StoryRoutingModule { }
