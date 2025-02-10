import { Component, inject, OnInit } from '@angular/core';
import { StavbeService } from '../../_services/stavbe.service';
import { Stavba } from '../../_models/stavba';
import { StavbaCardComponent } from '../stavba-card/stavba-card.component';

@Component({
  selector: 'app-stavbe-list',
  standalone: true,
  imports: [StavbaCardComponent],
  templateUrl: './stavbe-list.component.html',
  styleUrl: './stavbe-list.component.css'
})
export class StavbeListComponent implements OnInit {
  private stavbeService = inject(StavbeService);
  stavbe: Stavba[] = [];

  ngOnInit(): void {
    this.loadStavbe();
  }

  loadStavbe() {
    this.stavbeService.getStavbe().subscribe({
      next: stavbe => this.stavbe = stavbe
    })
  }


}
