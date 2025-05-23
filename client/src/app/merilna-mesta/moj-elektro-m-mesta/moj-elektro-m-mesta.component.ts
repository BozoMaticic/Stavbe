import { Component, inject, OnInit } from '@angular/core';
import { StavbeService } from '../../_services/stavbe.service';
import { MojElektroService } from '../../_services/moj-elektro.service';
import { MojElektroMerilnoMesto } from '../../_models/MojElektroMerilnoMesto';
import { CollapseDirective } from 'ngx-bootstrap/collapse';

@Component({
  selector: 'app-moj-elektro-m-mesta',
  imports: [CollapseDirective],
  templateUrl: './moj-elektro-m-mesta.component.html',
  styleUrl: './moj-elektro-m-mesta.component.css'
})
export class MojElektroMMestaComponent implements OnInit {
  stavbeService = inject(StavbeService);
  mojElektroService = inject(MojElektroService);
  mojElektroMerilnaMesta: MojElektroMerilnoMesto[] = [];
  isCollapsed = false;

  ngOnInit(): void {
    this.loadMojElektroMerilnaMesta();
  }

  loadMojElektroMerilnaMesta() {
    this.mojElektroService.getMojElektroMerilnaMesta(this.stavbeService.stavbaNaziv()).subscribe({
      next: (mojElektroMerilnaMesta) => {
        this.mojElektroMerilnaMesta = mojElektroMerilnaMesta;
      },
      error: (error) => {
        console.log(error);
      }
    });
  }

}
