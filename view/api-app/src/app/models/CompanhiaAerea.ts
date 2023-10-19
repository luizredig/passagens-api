export class CompanhiaAerea {
  id: number;
  nome: string = '';
  pais: string = '';

  constructor(id: number, nome: string, pais: string) {
    this.id = id;
    this.nome = nome;
    this.pais = pais;
  }
}
