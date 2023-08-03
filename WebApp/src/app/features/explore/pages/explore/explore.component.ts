import { Component, inject } from '@angular/core';
import { Breakpoints, BreakpointObserver } from '@angular/cdk/layout';
import { map } from 'rxjs/operators';

@Component({
  selector: 'literado-explore',
  templateUrl: './explore.component.html',
  styleUrls: ['./explore.component.scss']
})
export class ExploreComponent {
  private breakpointObserver = inject(BreakpointObserver);

  /** Based on the screen size, switch from standard to one column per row */
  books = this.breakpointObserver.observe(Breakpoints.Handset).pipe(
    map(({ matches }) => {
      if (matches) {
        return [
          { 
            url: 'https://picsum.photos/id/599/800/530', 
            alt: "mosaic collection image", 
            loadingType: "Lazy",
            mosaicType: "image_container image-wide image-tall"
          },
        ];
      }

      return [
        {
          url: "https://picsum.photos/id/599/800/530",
          alt: "mosaic collection image",
          loadingType: "Lazy",
          mosaicType: "image_container image-wide image-tall"
        },
        {
          url: "https://picsum.photos/200/300?random=1",
          alt: "mosaic collection image",
          loadingType: "Lazy",
          mosaicType: "image_container"
        },{
          url: "https://picsum.photos/200/300?random=2",
          alt: "mosaic collection image",
          loadingType: "Lazy",
          mosaicType: "image_container"
        },{
          url: "https://picsum.photos/200/300?random=3",
          alt: "mosaic collection image",
          loadingType: "Lazy",
          mosaicType: "image_container"
        },{
          url: "https://picsum.photos/200/300?random=4",
          alt: "mosaic collection image",
          loadingType: "Lazy",
          mosaicType: "image_container"
        },{
          url: "https://picsum.photos/200/300?random=5",
          alt: "mosaic collection image",
          loadingType: "Lazy",
          mosaicType: "image_container"
        },{
          url: "https://picsum.photos/200/300?random=6",
          alt: "mosaic collection image",
          loadingType: "Lazy",
          mosaicType: "image_container"
        },
      ];
    })
  );
}
