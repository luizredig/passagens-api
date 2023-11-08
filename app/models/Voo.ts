import { Aeroporto } from './Aeroporto';
import { Aviao } from './Aviao';

export class Voo {
  id: number;
  numero: string;
  aviao: Aviao | undefined;
  aeroportoOrigem: Aeroporto | undefined;
  aeroportoDestino: Aeroporto | undefined;

  constructor(
    id: number,
    numero: string,
    aviao: Aviao,
    aeroportoOrigem: Aeroporto,
    aeroportoDestino: Aeroporto
  ) {
    this.id = id;
    this.numero = numero;
    this.aviao = aviao;
    this.aeroportoOrigem = aeroportoOrigem;
    this.aeroportoDestino = aeroportoDestino;
  }
}
