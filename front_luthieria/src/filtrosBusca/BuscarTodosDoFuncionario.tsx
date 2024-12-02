import { useEffect, useState } from "react";
import axios from "axios";
import { OrdemDeServico } from "../models/OrdemDeServico";
import { Funcionario } from "../models/Funcionario";
import styles from "./ListarOrdemServico.module.css"
import { Link } from "react-router-dom";

function BuscarTodosServicosFuncionario() {
  const [ funcionarios, setfuncionarios ] = useState<Funcionario[]>([]);
  const [ servicosFuncionario, setServicosFuncionario ] = useState<OrdemDeServico[]>([]); 
  
  const [ funcionarioNome, setFuncionarioNome ] = useState("");
  const [ funcionarioId, setFuncionarioId ] = useState("");

  useEffect(() => {
    axios
    .get<Funcionario[]>("http://localhost:5028/api/funcionario/listar")
    .then((resposta) => {
      setfuncionarios(resposta.data);
      console.log("Funcionarios Listados!", resposta.data);
    })
    .catch((erro) => {
      console.log("Erro Tentando Listar Funcionarios...", erro);
    });
  })

  function realizarBusca(e: any) {
    e.preventDefault();
    
    axios
      .get<OrdemDeServico[]>(`http://localhost:5028/ordemservico/funcionario/${funcionarioId}`)
      .then((resposta) => {
        setServicosFuncionario(resposta.data);
        console.log("Resultados encontrados:", resposta.data);
      })
      .catch((erro) => {
        console.error("Erro ao realizar a busca:", erro);
      });
    
    axios
      .get<Funcionario>(`http://localhost:5028/api/funcionario/buscar/${funcionarioId}`)
      .then((resposta) => {
        setFuncionarioNome(resposta.data.nome);
        console.log("Cliente Encontrado!", resposta.data);
      })
      .catch((erro) => {
        console.error("Erro ao realizar a busca...", erro);
      });
  }

  function deletarOrdemSevico(ordemDeServicoId: number) {
    axios
      .delete(`http://localhost:5028/api/ordemservico/deletar/${ordemDeServicoId}`)
      .then((resposta) => {
        console.log("Ordem De Serviço Deletada!", resposta.data);
      })
      .catch((erro) => {
        console.log("Erro Tentando Deletar Ordem De Serviço...", erro);
      });
  }

    return (
      <div className="container">
        <h1>Buscar Todos os Serviços de um Funcionário:</h1>
        <form onSubmit={realizarBusca}>
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
          <button type="submit">Buscar</button>
        </form>

        <br></br>

        <h1>Todos os Serviços do Funcionário: {funcionarioNome}</h1>
        <table className={styles.table}>
        <thead>
          <tr>
            <th>#</th>
            <th>Descrição do Serviço</th>
            <th>Instrumento</th>
            <th>Status</th>
            <th>Valor Estimado</th>
            <th>Cliente</th>
            <th>Funcionario</th>
            <th>Criado Em</th>
            <th>Alterar</th>
            <th>Deletar</th>
          </tr>
        </thead>
        <tbody>
          {servicosFuncionario.map((servicoFuncionario) => (
            <tr key={servicoFuncionario.ordemDeServicoId}>
              <td>{servicoFuncionario.ordemDeServicoId}</td>
              <td>{servicoFuncionario.descricaoServico}</td>
              <td>{servicoFuncionario.instrumento}</td>
              <td>{servicoFuncionario.status}</td>
              <td>R$ {servicoFuncionario.valorEstimado}</td>
              <td>{servicoFuncionario.cliente?.nome}</td>
              <td>{servicoFuncionario.funcionario?.nome}</td>
              <td>{servicoFuncionario.criadoEm}</td>
              <td>
                <Link 
                  to={`/pages/ordemservico/alterar/${servicoFuncionario.ordemDeServicoId}`}
                > 
                  Alterar
                </Link>
              </td>
              <td>
                <button onClick={() => deletarOrdemSevico(servicoFuncionario.ordemDeServicoId!)}> Deletar </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
      </div>
    );
  }

export default BuscarTodosServicosFuncionario;
