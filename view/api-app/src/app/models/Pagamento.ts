export class Pagamento {
  id: number;
  tipo: string = '';
  constructor(id: number, tipo: string) {
    this.id = id;
    this.tipo = tipo;
  }
}
