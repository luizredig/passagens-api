export class Aeroporto {
  id: number;
  nome: string = '';
  cidade: string = '';

  constructor(id: number, nome: string, cidade: string) {
    this.id = id;
    this.nome = nome;
    this.cidade = cidade;
  }
}
