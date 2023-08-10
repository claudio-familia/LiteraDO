import { ExploreComponent } from './pages/explore/explore.component';
import { CardComponent } from '../../core/components/card/card.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ExploreRoutingModule } from './explore-routing.module';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatCardModule } from '@angular/material/card';
import { MatMenuModule } from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { ExploreDetailPage } from './pages/explore-detail/explore-detail.page';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatTableModule } from '@angular/material/table';


@NgModule({
  declarations: [
    ExploreComponent,
    CardComponent,
    ExploreDetailPage
  ],
  imports: [
    CommonModule,
    ExploreRoutingModule,
    MatGridListModule,
    MatCardModule,
    MatMenuModule,
    MatIconModule,
    MatButtonModule,
    MatTableModule, 
    MatPaginatorModule
  ]
})
export class ExploreModule { }
