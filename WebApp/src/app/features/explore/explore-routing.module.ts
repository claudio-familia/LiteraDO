import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ExploreComponent} from './pages/explore/explore.component'
import { ExploreDetailPage } from './pages/explore-detail/explore-detail.page';

const routes: Routes = [
  {
    path: '',
    component: ExploreComponent
  },
  {
    path: ':id',
    component: ExploreDetailPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ExploreRoutingModule { }
