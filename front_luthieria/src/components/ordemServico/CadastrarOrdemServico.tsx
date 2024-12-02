import { useNavigate } from "react-router-dom";
import { useEffect, useState } from "react";
import { Cliente } from "../../models/Cliente";
import { Funcionario } from "../../models/Funcionario";
import { OrdemDeServico, StatusOrdemDeServico } from "../../models/OrdemDeServico";
import axios from "axios";
import styles from "./CadastrarOrdemServico.module.css"

function CadastrarOrdemServico() {
  const navigate = useNavigate();
  const statusOptions: StatusOrdemDeServico[] = ['Pendente', 'Em Andamento', 'Finalizado'];
  
  const [ funcionarios, setFuncionarios ] = useState<Funcionario[]>([]);
  const [ clientes, setClientes ] = useState<Cliente[]>([]);
  const [ descricaoServico, setDescricaoServico ] = useState("");
  const [ instrumento, setInstrumento ] = useState("");
  const [ status, setStatus ] = useState("");
  const [ valorEstimado, setValorEstimado ] = useState(0);
  const [ funcionarioId, setFuncionarioId ] = useState(0);
  const [ clienteId, setClienteId ] = useState(0);

  useEffect(() => {
    axios
      .get<Funcionario[]>("http://localhost:5028/api/funcionario/listar")
      .then((resposta) => {
        setFuncionarios(resposta.data);
        console.log("Funcionarios Listados!", resposta.data);
      })
      .catch((erro) => {
        console.log("Erro Listando Funcionarios...", erro);
      });
    
    axios
      .get<Cliente[]>("http://localhost:5028/api/cliente/listar")
      .then((resposta) => {
        setClientes(resposta.data);
        console.log("Clientes Listados!", resposta.data);
      })
      .catch((erro) => {
        console.log("Erro Tentando Listar Clientes...", erro);
      });
  });

  function enviarOrdemDeServico(e: any) {
    e.preventDefault();

    const ordemDeServico: OrdemDeServico = {
      descricaoServico: descricaoServico,
      instrumento: instrumento,
      status: status,
      valorEstimado: Number(valorEstimado),
      funcionarioId: funcionarioId,
      clienteId: clienteId,
    }

    axios
      .post("http://localhost:5028/api/ordemservico/cadastrar/", ordemDeServico)
      .then((resposta) => {
        console.log("OrdemDeSevico Criada!", resposta.data);
        navigate("/pages/ordemservico/listar");
      })
      .catch((erro) => {
        console.log("Erro Tentando Cadastrar Ordem de Serviço", erro);
      });
  }

  return ( 
    <div id="cadastar_ordemservico" className="container">
      <h1>Cadastrar Nova "Ordem de Serviço"</h1>
      <form onSubmit={enviarOrdemDeServico} className={styles.form}>
        <div>
          <label htmlFor="descricao"> Descricao do Serviço </label>
          <input 
            id="descricao" 
            type="text" 
            name="descricao" 
            required 
            onChange={(e: any) => setDescricaoServico(e.target.value)} />
        </div>
        <div>
          <label htmlFor="instrumento"> Instrumento </label>
          <input 
            id="instrumento" 
            type="text" 
            name="instrumento" 
            required
            onChange={(e: any) => setInstrumento(e.target.value)} />
        </div>
        <div>
          <label htmlFor="status"> Status </label>
          <select
            id="status" 
            name="status" 
            required 
            onChange={(e) => setStatus(e.target.value as StatusOrdemDeServico)}>
              <option value="" disabled> Selecione o Status </option>
                {statusOptions.map((statusOption) => (
                  <option key={statusOption} value={statusOption}>
                    {statusOption}
                  </option>
                ))}
          </select>
        </div>
        <div>
          <label htmlFor="valor">Valor Estimado</label>
          <input 
            id="valor" 
            type="text" 
            name="valor" 
            required 
            onChange={(e: any) => setValorEstimado(e.target.value)} />
        </div>
        <div>
          <label htmlFor="funcionarios">Selecione um Funcionário:</label>
          <select 
            id="funcionarios" 
            name="funcionarios" 
            required 
            onChange={(e: any) => setFuncionarioId(e.target.value)}
          >
            {funcionarios.map((funcionario) => (
              <option 
                key={funcionario.funcionarioId} 
                value={funcionario.funcionarioId}
              >
                {`${funcionario.nome} - Registro: ${funcionario.nRegistro}`}
              </option>
            ))}
          </select>
        </div>
        <div>
          <label htmlFor="clientes">Selecione um Cliente:</label>
          <select 
            id="clientes" 
            name="clientes" 
            required 
            onChange={(e: any) => setClienteId(e.target.value)}
          >
            {clientes.map((cliente) => (
              <option 
                key={cliente.clienteId} 
                value={cliente.clienteId}
              >
                {`${cliente.nome} - CPF: ${cliente.cpf}`}
              </option>
            ))}
          </select>
        </div>
        <button type="submit" className="cadastro"> Criar Ordem de Serviço </button>
      </form>
    </div>
  );
}

export default CadastrarOrdemServico;