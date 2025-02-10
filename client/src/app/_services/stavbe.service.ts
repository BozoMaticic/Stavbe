import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Stavba } from '../_models/stavba';

@Injectable({
  providedIn: 'root'
})
export class StavbeService {
  private http = inject(HttpClient);
    baseUrl = environment.apiUrl;
  
  getStavbe() {
    return this.http.get<Stavba[]>(this.baseUrl + 'stavbe');
  }

  getStavba(naziv: string) {
    return this.http.get<Stavba>(this.baseUrl + 'stavbe/' + naziv);
  }

}
