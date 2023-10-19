import { CompanhiaAerea } from './CompanhiaAerea';

export class Aviao {
  modelo: string = '';
  companhiaAerea: CompanhiaAerea;

  constructor(modelo: string, companhiaAerea: CompanhiaAerea) {
    this.modelo = modelo;
    this.companhiaAerea = companhiaAerea;
  }
}
