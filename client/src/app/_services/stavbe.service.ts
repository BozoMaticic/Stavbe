import { HttpClient, HttpParams } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { environment } from '../../environments/environment';
import { Stavba } from '../_models/stavba';
import { of, tap } from 'rxjs';
import { Photo } from '../_models/photo';

@Injectable({
  providedIn: 'root'
})
export class StavbeService {
  private http = inject(HttpClient);
  baseUrl = environment.apiUrl;
  stavbe = signal<Stavba[]>([]);
  stavbaNaziv = signal<string>("");
  stavbaIdSignal = signal<number>(0);


  getStavbe() {
    return this.http.get<Stavba[]>(this.baseUrl + 'stavbe')
      .subscribe({
        next: (stavbe) => {
          this.stavbe.set(stavbe);
        }
      })
  }

  getStavbaPoNazivu(naziv: string) {
    const stavba = this.stavbe().find(x => x.naziv === naziv);
    if (stavba !== undefined) return of(stavba);
    return this.http.get<Stavba>(this.baseUrl + 'stavbe/' + naziv);
  }

  getStavba(id: number) {
    const stavba = this.stavbe().find(x => x.id === id);
    if (stavba !== undefined) return of(stavba);
    return this.http.get<Stavba>(this.baseUrl + 'stavbe/' + id);
  }

  updateStavba(stavba: Stavba) {
    return this.http.put(this.baseUrl + 'stavbe', stavba).pipe(
      tap(() => {
        this.stavbe.update(stavbe => stavbe.map(s => s.naziv === stavba.naziv
          ? stavba : s))
      })
    )
  }


  setMainPhoto(photo: Photo) {
    // const parametri = new HttpParams()
    // .set('stavbaNaziv', `${this.stavbaNaziv()}`)
   // .set('PhotoId', `${photo.id}`)

   const idStavbeInIdPhoto = this.stavbaIdSignal().toString() + " " + photo.id.toString()

    return this.http.put(this.baseUrl + 'stavbe/set-main-photo/'+ idStavbeInIdPhoto, {}).pipe(
      tap(() => {
        this.stavbe.update(stavbe => stavbe.map(m => {
          if (m.photosStavbe.includes(photo)) {
            m.photoUrl = photo.url
          }
          return m;
        }))
      })
    )
  }

  // deletePhoto(photo: Photo) {
  //   return this.http.delete(this.baseUrl + 'stavbe/delete-photo/' + photo.id).pipe(
  //     tap(() => {
  //       this.stavbe.update(stavbe => stavbe.map(m => {
  //         if (m.photosStavbe.includes(photo)) {
  //           m.photosStavbe = m.photosStavbe.filter(x => x.id !== photo.id)
  //         }
  //         return m
  //       }))
  //     })
  //   )
  // }

}
