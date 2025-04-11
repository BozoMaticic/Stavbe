import { Component, inject, input, OnInit } from '@angular/core';
import { Stavba } from '../../_models/stavba';
import { RouterLink } from '@angular/router';
import { StavbeService } from '../../_services/stavbe.service';

@Component({
    selector: 'app-stavba-card',
    imports: [RouterLink],
    templateUrl: './stavba-card.component.html',
    styleUrl: './stavba-card.component.css'
})
export class StavbaCardComponent {
  stavba = input.required<Stavba>();
  stavbeService = inject(StavbeService);


  onCardClick() {
    console.log('Card clicked!');
    this.stavbeService.stavbaIdSignal.set(this.stavba().id);
    this.stavbeService.stavbaSignal.set(this.stavba());
  }



}
