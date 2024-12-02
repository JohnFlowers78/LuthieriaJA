import { Funcionario } from './Funcionario';
import { Cliente } from "./Cliente";

export interface OrdemDeServico{
  ordemDeServicoId?: number,
  descricaoServico: string,
  instrumento: string,
  status: string,
  statusOptions?: StatusOrdemDeServico,
  valorEstimado: number,
  clienteId: number,
  cliente?: Cliente,
  funcionarioId: number,
  funcionario?: Funcionario,
  criadoEm?: string,
}

export type StatusOrdemDeServico = 'Pendente' | 'Em Andamento' | 'Finalizado';