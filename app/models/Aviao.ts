import { CompanhiaAerea } from './CompanhiaAerea';

export class Aviao {
  modelo: string = '';
  companhiaAerea: CompanhiaAerea | undefined;

  constructor(modelo: string, companhiaAerea: CompanhiaAerea) {
    this.modelo = modelo;
    this.companhiaAerea = companhiaAerea;
  }
}
