export interface Itocka {
    lat: number;
    lng: number;
  }
  
  export interface ItockaOboda {
    zaporedje: number;
    tocka: Itocka;
  }
  
  export interface ItockaMerilnegaMesta {
    tocka: Itocka;
    vrednost: number;
    polmer: number;
    energentTip: string;
    stMerilnegaMesta: string;
    nickName: string;
  }

  // export interface IobjektObodInInfo {
  //   noviObodiObjekta: Itocka[][];
  //   idJavnegaObjekta: number;
  //   sifraJavnegaObjekta: string;
  //   naziv: string;
  //   center: google.maps.LatLng;
  // }

  

  
  export interface Ipoligon {
      idJavnegaObjekta: number;
      sifraJavnegaObjekta: string;
      naziv: string;
      center: google.maps.LatLng
  
    noviObodiObjekta: Itocka[][];
    noviObodiLatLng: google.maps.LatLngLiteral[][];
  }


