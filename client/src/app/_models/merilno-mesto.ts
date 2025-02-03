import { Stavba } from "./stavba"

  export interface MerilnoMesto {
    id: number
    stMerilnegaMesta: string
    energent: number
    energentTip: string
    type: any
    ogrevanje?: string
    ogrevanjeId: number
    ogrevanjeOznaka?: string
    idJavnegaZavoda: number
    sifraJavnegaObjekta: string
    nazivJavnegaObjekta: string
    nickName: string
    dobavitelj: string
    dobaviteljNaziv: any
    obracunskaMoc: number
    
    stavba: Stavba
    idStavbe: number
    odcitki: any[]
  }
