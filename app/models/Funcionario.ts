import { Aeroporto } from './Aeroporto';

export class Funcionario {
  id: number;
  nome: string = '';
  cargo: string = '';
  aeroporto: Aeroporto | undefined;

  constructor(id: number, nome: string, cargo: string, aeroporto: Aeroporto) {
    this.id = id;
    this.nome = nome;
    this.cargo = cargo;
    this.aeroporto = aeroporto;
  }
}
