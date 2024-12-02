import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { Cliente } from "../../models/Cliente";
import { Funcionario } from "../../models/Funcionario";
import { OrdemDeServico, StatusOrdemDeServico } from "../../models/OrdemDeServico";
import axios from "axios";
import styles from "./AlterarOrdemServico.module.css"

function AlterarOrdemServico() {
  const navigate = useNavigate();
  const statusOptions: StatusOrdemDeServico[] = ['Pendente', 'Em Andamento', 'Finalizado'];

  
  const { ordemDeServicoId } = useParams();
  const [ funcionarios, setFuncionarios ] = useState<Funcionario[]>([]);
  const [ clientes, setClientes ] = useState<Cliente[]>([]);
  const [ descricaoServico, setDescricaoServico ] = useState("");
  const [ instrumento, setInstrumento ] = useState("");
  const [ status, setStatus ] = useState("");
  const [ valorEstimado, setValorEstimado ] = useState(0);
  const [ funcionarioId, setFuncionarioId ] = useState(0);
  const [ clienteId, setClienteId ] = useState(0);

  useEffect(() => {
    if (ordemDeServicoId) {
      axios
        .get<OrdemDeServico>(`http://localhost:5028/api/ordemservico/buscar/${ordemDeServicoId}`)
        .then((resposta) => {
          setDescricaoServico(resposta.data.descricaoServico);
          setInstrumento(resposta.data.instrumento);
          setStatus(resposta.data.status);
          setValorEstimado(resposta.data.valorEstimado);
          setFuncionarioId(resposta.data.funcionarioId);
          setClienteId(resposta.data.clienteId);
          pesquisarFuncionarios();
          pesquisarClientes();
          console.log("Ordem de Serviço Encontrada!", resposta.data);
        })
        .catch((erro) => {
          console.log("Erro Tentando Buscar Ordem de Serviço...", erro);
        });
    }
  }, []);

  function pesquisarFuncionarios() {
    axios
    .get<Funcionario[]>("http://localhost:5028/api/funcionario/listar")
    .then((resposta) => {
      setFuncionarios(resposta.data);
      console.log("Funcionários Listados!", resposta.data);
    })
    .catch((erro) => {
      console.log("Erro Tentando Listar Funcionarios...", erro);
    });
  }

  function pesquisarClientes() {
    axios
    .get<Cliente[]>("http://localhost:5028/api/cliente/listar")
    .then((resposta) => {
      setClientes(resposta.data);
      console.log("Clientes Listados!", resposta.data);
    })
    .catch((erro) => {
      console.log("Erro Tentando Listar Clientes...", erro);
    });
  }

  function enviarOrdemServico(e: any) {
    e.preventDefault();

    const ordemServicoAlterada: OrdemDeServico = {
      descricaoServico: descricaoServico,
      instrumento: instrumento,
      status: status,
      valorEstimado: Number(valorEstimado),
      funcionarioId: funcionarioId,
      clienteId: clienteId,
    }

    axios
      .put(`http://localhost:5028/api/ordemservico/alterar/${ordemDeServicoId}`, ordemServicoAlterada)
      .then((resposta) => {
        console.log("Ordem de Serviço Alterada!", resposta.data);
        navigate("/pages/ordemservico/listar");
      })
      .catch((erro) => {
        console.log("Erro Tentando Alterar Ordem de Serviço...", erro);
      });
  }

  return (
    <div id="alterar_ordemservico" className="container">
      <h1>Alterando Ordem de Serviço do Instrumento: {instrumento}</h1>
      <form onSubmit={enviarOrdemServico} className={styles.form}>
        <div>
          <label htmlFor="descricao"> Descricao do Serviço </label>
          <input 
            id="descricao" 
            type="text" 
            name="descricao" 
            required
            value={descricaoServico}
            onChange={(e: any) => setDescricaoServico(e.target.value)} />
        </div>
        <div>
          <label htmlFor="instrumento"> Instrumento </label>
          <input 
            id="instrumento" 
            type="text" 
            name="instrumento" 
            required
            value={instrumento}
            onChange={(e: any) => setInstrumento(e.target.value)} />
        </div>
        <div>
          <label htmlFor="status"> Status </label>
          <select
            id="status" 
            name="status" 
            required 
            value={status}
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
            required 
            value={valorEstimado}
            name="valor" 
            onChange={(e: any) => setValorEstimado(e.target.value)} />
        </div>
        <div>
          <label htmlFor="funcionarios">Selecione um Funcionário:</label>
          <select 
            id="funcionarios" 
            required 
            value={funcionarioId}
            name="funcionarios" 
            onChange={(e: any) => setFuncionarioId(e.target.value)}
          >
            {funcionarios.map((funcionario) => (
              <option 
                key={funcionario.funcionarioId} 
                value={funcionario.funcionarioId}
              >
                {funcionario.nome}
                <br></br>
                {funcionario.nRegistro}
              </option>
            ))}
          </select>
        </div>
        <div>
          <label htmlFor="clientes">Selecione um Cliente:</label>
          <select 
            id="clientes" 
            required 
            value={funcionarioId}
            name="clientes" 
            onChange={(e: any) => setClienteId(e.target.value)}
          >
            {clientes.map((cliente) => (
              <option 
                key={cliente.clienteId} 
                value={cliente.clienteId}
              >
                {cliente.nome}
                <br></br>
                {cliente.cpf}
              </option>
            ))}
          </select>
        </div>
        <button type="submit"> Alterar Ordem de Serviço </button>
      </form>
    </div>
  );

}

export default AlterarOrdemServico;