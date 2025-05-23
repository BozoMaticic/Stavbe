import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { MojElektroMerilnoMesto } from '../_models/MojElektroMerilnoMesto';

@Injectable({
  providedIn: 'root'
})
export class MojElektroService {
  private http = inject(HttpClient);
  baseUrl = environment.apiUrl;


  getMojElektroMerilnaMesta(naziv: string) {
    return this.http.get<MojElektroMerilnoMesto[]>(this.baseUrl + 'mojElektro/moj-elektro-merilna-mesta/' + naziv);
  }
}
