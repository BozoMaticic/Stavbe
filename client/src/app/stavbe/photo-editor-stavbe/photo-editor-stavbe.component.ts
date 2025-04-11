import { Component, inject, input, OnInit, output } from '@angular/core';
import { Stavba } from '../../_models/stavba';
import { DecimalPipe, NgClass, NgFor, NgIf, NgStyle } from '@angular/common';
import { FileUploader, FileUploadModule } from "ng2-file-upload";
import { StavbeService } from '../../_services/stavbe.service';
import { environment } from '../../../environments/environment';
import { Photo } from '../../_models/photo';
import { AccountService } from '../../_services/account.service';

@Component({
  selector: 'app-photo-editor-stavbe',
  standalone: true,
  imports: [NgIf, NgFor, NgStyle, NgClass, FileUploadModule, DecimalPipe],
  templateUrl: './photo-editor-stavbe.component.html',
  styleUrl: './photo-editor-stavbe.component.css'
})
export class PhotoEditorStavbeComponent implements OnInit {
  private accountService = inject(AccountService);
  private stavbeService = inject(StavbeService);
  stavba = input.required<Stavba>();
  uploader?: FileUploader;
  hasBaseDropZoneOver = false;
  baseurl = environment.apiUrl;
  stavbaChange = output<Stavba>();

  ngOnInit(): void {
    this.initializeUploader();
    this.stavbeService.stavbaIdSignal.set(this.stavba().id);
    this.stavbeService.stavbaSignal.set(this.stavba());
  }

  fileOverBase(e: any) {
    this.hasBaseDropZoneOver = e;
  }

  deletePhoto(photo: Photo){
    this.stavbeService.deletePhoto(photo).subscribe({
      next: _ => {
        const updatedStavba = {...this.stavba()};
        updatedStavba.photosStavbe = updatedStavba.photosStavbe
          .filter(x => x.id !== photo.id);
        this.stavbaChange.emit(updatedStavba);
      }
    })
  }

  setMainPhoto(photo: Photo) {
    this.stavbeService.stavbaNaziv.set(this.stavba().naziv);
    this.stavbeService.setMainPhoto(photo).subscribe({
      next: _ => {
        this.stavba().photoUrl = photo.url;
        const updatedStavba = {...this.stavba()}
        updatedStavba.photoUrl = photo.url;
        updatedStavba.photosStavbe.forEach(p => {
          if (p.isMain) p.isMain = false;
          if (p.id === photo.id) p.isMain = true;
        });
        this.stavbaChange.emit(updatedStavba);
      }
    })
  }

  initializeUploader() {
    this.uploader = new FileUploader({
      url: this.baseurl + 'stavbe/add-photo/' + this.stavbeService.stavbaNaziv(),
      authToken: 'Bearer ' + this.accountService.currentUser()?.token,
      isHTML5: true,
      allowedFileType: ['image'],
      removeAfterUpload: true,
      autoUpload: false,
      maxFileSize: 10 * 1024 * 1024,
    });

    this.uploader.onAfterAddingFile = (file) => {
      file.withCredentials = false
    }
    console.log("uploader token", this.accountService.currentUser()?.token)
  }




}
