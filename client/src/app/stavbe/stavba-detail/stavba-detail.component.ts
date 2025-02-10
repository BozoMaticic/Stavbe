import { Component, inject } from '@angular/core';
import { StavbeService } from '../../_services/stavbe.service';
import { ActivatedRoute } from '@angular/router';
import { Stavba } from '../../_models/stavba';
import { TabsModule } from 'ngx-bootstrap/tabs';

@Component({
  selector: 'app-stavba-detail',
  standalone: true,
  imports: [TabsModule],
  templateUrl: './stavba-detail.component.html',
  styleUrl: './stavba-detail.component.css'
})
export class StavbaDetailComponent {
    private stavbeService = inject(StavbeService);
    private route = inject(ActivatedRoute);
    stavba?: Stavba;
  
    ngOnInit(): void {
      this.loadStavba();
    }
  
    loadStavba() {
      const naziv = this.route.snapshot.paramMap.get('naziv');
      if (!naziv) return;
      this.stavbeService.getStavba(naziv).subscribe({
        next: stavba => {
          this.stavba = stavba;
          this.stavba.fotoUrl = 'https://randomuser.me/api/portraits/men/93.jpg'
        }
      });
    }
  
  

}
