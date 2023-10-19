import { Pagamento } from './Pagamento';
import { Passageiro } from './Passageiro';
import { Portao } from './Portao';
import { Voo } from './Voo';

export class Passagem {
  id: number;
  classe: string;
  pagamento: Pagamento;
  portao: Portao;
  voo: Voo;
  passageiro: Passageiro;

  constructor(
    id: number,
    classe: string,
    pagamento: Pagamento,
    portao: Portao,
    voo: Voo,
    passageiro: Passageiro
  ) {
    this.id = id;
    this.classe = classe;
    this.pagamento = pagamento;
    this.portao = portao;
    this.voo = voo;
    this.passageiro = passageiro;
  }
}
