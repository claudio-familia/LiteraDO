import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StoryPage } from './pages/story/story.page';
import { CreateStoryPage } from './pages/create-story/create-story.page';
import { DetailPage } from './pages/detail/detail.page';
import { CreateChapterPage } from './pages/create-chapter/create-chapter.page';
import { ReadingPage } from './pages/reading/reading.page';
import { StoryReadPagePage } from './pages/story-read-page/story-read-page.page';
import { StoryQuotePagePage } from './pages/story-quote-page/story-quote-page.page';

const routes: Routes = [
  {
    path: "", component: StoryPage
  },
  {
    path: "my-story", component: StoryReadPagePage
  },
  {
    path: "my-quotes", component: StoryQuotePagePage
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
