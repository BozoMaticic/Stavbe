import { Stavba } from "./stavba";

export class StavbaParams {
    vrstaObjekta: string;
    ogrevanjeOznaka: string;
    pageNumber = 1;
    pageSize = 5;
    orderBy = 'sifraJavnegaObjekta';
    constructor(stavba: Stavba | null) {
        this.ogrevanjeOznaka = stavba?.ogrevanjeOznaka || 'vsi'
        this.vrstaObjekta = stavba?.vrstaObjekta || 'vsi'
    }
}