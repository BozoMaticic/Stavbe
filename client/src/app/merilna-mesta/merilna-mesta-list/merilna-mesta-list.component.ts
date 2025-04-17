import { Component, inject, OnInit } from '@angular/core';
import { StavbeService } from '../../_services/stavbe.service';
import { MerilnoMesto } from '../../_models/merilno-mesto';
import { ButtonsModule } from 'ngx-bootstrap/buttons';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-merilna-mesta-list',
  imports: [ButtonsModule, FormsModule],
  templateUrl: './merilna-mesta-list.component.html',
  styleUrl: './merilna-mesta-list.component.css'
})
export class MerilnaMestaListComponent implements OnInit {
  stavbeService = inject(StavbeService);
  merilnaMesta: MerilnoMesto[] = [];

  ngOnInit(): void {
    this.loadMerilnaMesta();
    
  }

  loadMerilnaMesta() {
    this.stavbeService.getMerilnaMestaStavbe(this.stavbeService.stavbaNaziv()).subscribe({
      next: (merilnaMesta) => {
        this.merilnaMesta = merilnaMesta;
      },
      error: (error) => {
        console.log(error);
      }
    });
  }

}
