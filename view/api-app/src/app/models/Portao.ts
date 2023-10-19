import { Aeroporto } from './Aeroporto';

export class Portao {
  id: number;
  codigo: string;
  aeroporto: Aeroporto;

  constructor(id: number, codigo: string, aeroporto: Aeroporto) {
    this.id = id;
    this.codigo = codigo;
    this.aeroporto = aeroporto;
  }
}
