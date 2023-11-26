import { Ficha } from "./ficha.models";

export interface Usuario {
    usuarioId: number;
    nome: string;
    fichas?: Ficha[];
  }