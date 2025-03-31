import { Component, inject, signal } from '@angular/core';
import { StavbeService } from '../../_services/stavbe.service';
import { ActivatedRoute, RouterLink, RouterLinkActive } from '@angular/router';
import { Stavba } from '../../_models/stavba';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { GalleryModule, GalleryItem, ImageItem } from 'ng-gallery';

@Component({
    selector: 'app-stavba-detail',
    imports: [TabsModule, GalleryModule, RouterLink],
    templateUrl: './stavba-detail.component.html',
    styleUrl: './stavba-detail.component.css'
})
export class StavbaDetailComponent {
    private stavbeService = inject(StavbeService);
    private route = inject(ActivatedRoute);
    stavba?: Stavba;

    images: GalleryItem[] = [];
  
    ngOnInit(): void {
      this.loadStavba();
      if(!this.stavba) return;
      this.stavbeService.stavbaNaziv.set(this.stavba.naziv);
    }
  
    loadStavba() {
      const naziv = this.route.snapshot.paramMap.get('naziv');
      if (!naziv) return;
      console.log("test " + naziv);

      this.stavbeService.getStavbaPoNazivu(naziv).subscribe({
        next: stavba => {
          this.stavba = stavba;
          this.stavbeService.stavbaNaziv.set(stavba.naziv);

          stavba.photosStavbe.map(p => {
            this.images.push(new ImageItem({ src: p.url, thumb: p.url }));
          });

        }
      });
    }
  
}

   //       this.stavba.fotoUrl = 'https://randomuser.me/api/portraits/men/93.jpg';

