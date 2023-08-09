import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StoryPage } from './pages/story/story.page';
import { CreateStoryPage } from './pages/create-story/create-story.page';

const routes: Routes = [
  {
    path: "", component: StoryPage
  },
  {
    path: "create", component: CreateStoryPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class StoryRoutingModule { }
