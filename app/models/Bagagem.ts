import { Passageiro } from './Passageiro';

export class Bagagem {
  id: number;
  peso: number = 0;
  passageiro: Passageiro | undefined;

  constructor(id: number, peso: number, passageiro: Passageiro) {
    this.id = id;
    this.peso = peso;
    this.passageiro = passageiro;
  }
}
