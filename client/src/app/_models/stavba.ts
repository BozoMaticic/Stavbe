import { Photo } from "./photo"
import { MerilnoMesto } from "./merilno-mesto"

export interface Stavba {
    id: number
    sifraJavnegaObjekta: string
    naziv: string
    nazivEnote: string
    naslov: string
    ulicaHs: string
    photoUrl: string
    
    katastrskaObcinaSifra: string
    katastrskaObcinaIme: string
    sT_OBJ_Gurs: string
    ntP_NetoTloris: number
    uporabnaPovrsina: number
    vrstaObjekta: string
    vrstaObjektaId: number
    ogrevanje: string
    ogrevanjeId: any
    ogrevanjeOznaka: string
    parcelePovrsina: number
    stavbaDaNe: boolean
    stavbaStevilka: any
    stavbaDel: any
    klasifikacijaCcSi: any
    klasifikacijaNaziv: any
    povrsinaAplikacija: number
    opomba: string
    merilnaMesta: MerilnoMesto[]
    photosStavbe: Photo[]
  }
  
