import { Ficha } from "./ficha.models";

export interface Campanha {
    campanhaId: number;
    nome: string;
    sinopse: string;
    fichas?: Ficha[];
  }