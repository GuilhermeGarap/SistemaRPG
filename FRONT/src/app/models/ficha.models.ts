import { Campanha } from './campanha.models';
import { Usuario } from "./usuario.models";
import { Classe } from "./classe.models";

export interface Ficha {
    fichaId: number;
    nome: string;
    vida?: number | null;
    estamina?: number | null;
    desAparencia: string;
    historia: string;
    vigor: number;
    presenca: number;
    sabedoria: number;
    forca: number;
    agilidade: number;
    classeId: number;
    classe?: Classe;
    usuarioId: number;
    usuario?: Usuario;
    campanhaId: number;
    campanha?: Campanha;
  }