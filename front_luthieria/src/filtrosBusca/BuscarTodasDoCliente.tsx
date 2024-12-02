import { useEffect, useState } from "react";
import axios from "axios";
import { OrdemDeServico } from "../models/OrdemDeServico";
import { Cliente } from "../models/Cliente";
import styles from "./ListarOrdemServico.module.css"
import { Link } from "react-router-dom";

function BuscarTodosServicosCliente() {
  const [ clientes, setClientes ] = useState<Cliente[]>([]);
  const [ servicosCliente, setServicosCliente ] = useState<OrdemDeServico[]>([]); 
  
  const [ clienteNome, setClienteNome ] = useState("");
  const [ clienteId, setClienteId ] = useState("");

  useEffect(() => {
    axios
    .get<Cliente[]>("http://localhost:5028/api/cliente/listar")
    .then((resposta) => {
      setClientes(resposta.data);
      console.log("Clientes Listados!", resposta.data);
    })
    .catch((erro) => {
      console.log("Erro Tentando Listar Clientes...", erro);
    });
  })

  function realizarBusca(e: any) {
    e.preventDefault();
    
    axios
      .get<OrdemDeServico[]>(`http://localhost:5028/ordemservico/todas/cliente/${clienteId}`)
      .then((resposta) => {
        setServicosCliente(resposta.data);
        console.log("Resultados encontrados:", resposta.data);
      })
      .catch((erro) => {
        console.error("Erro ao realizar a busca:", erro);
      });
    
    axios
      .get<Cliente>(`http://localhost:5028/api/cliente/buscar/${clienteId}`)
      .then((resposta) => {
        setClienteNome(resposta.data.nome);
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
        <h1>Buscar Todos os Pedidos de um Cliente:</h1>
        <form onSubmit={realizarBusca}>
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
          <button type="submit">Buscar</button>
        </form>

        <br></br>

        <h1>Todos os Pedidos do Cliente: {clienteNome}</h1>
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
          {servicosCliente.map((servicoCliente) => (
            <tr key={servicoCliente.ordemDeServicoId}>
              <td>{servicoCliente.ordemDeServicoId}</td>
              <td>{servicoCliente.descricaoServico}</td>
              <td>{servicoCliente.instrumento}</td>
              <td>{servicoCliente.status}</td>
              <td>R$ {servicoCliente.valorEstimado}</td>
              <td>{servicoCliente.cliente?.nome}</td>
              <td>{servicoCliente.funcionario?.nome}</td>
              <td>{servicoCliente.criadoEm}</td>
              <td>
                <Link 
                  to={`/pages/ordemservico/alterar/${servicoCliente.ordemDeServicoId}`}
                > 
                  Alterar
                </Link>
              </td>
              <td>
                <button onClick={() => deletarOrdemSevico(servicoCliente.ordemDeServicoId!)}> Deletar </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
      </div>
    );
  }

export default BuscarTodosServicosCliente;
