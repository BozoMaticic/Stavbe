import { Component, input } from '@angular/core';
import { Stavba } from '../../_models/stavba';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-stavba-card',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './stavba-card.component.html',
  styleUrl: './stavba-card.component.css'
})
export class StavbaCardComponent {
  stavba = input.required<Stavba>();

}
