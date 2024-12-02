import { useEffect, useState } from "react";
import { Cliente } from "../../models/Cliente";
import axios from "axios";
import { Link } from "react-router-dom";
import styles from "./ListaCliente.module.css"

function ListarCliente() {
  const [ clientes, setClientes ] = useState<Cliente[]>([]);

  useEffect(() => {
    axios
      .get<Cliente[]>("http://localhost:5028/api/cliente/listar")
      .then((resposta) => {
        setClientes(resposta.data);
        console.log("Clientes Listados!", resposta.data);
      })
      .catch((erro) => {
        console.log("Erro Tentando Listar Clientes!", erro);
      });
  })

  function deletarCliente(clienteId: number | string) {
    axios
      .delete(`http://localhost:5028/api/cliente/deletar/${clienteId}`)
      .then((resposta) => {
        console.log("Cliente Deletado!", resposta.data);
      })
      .catch((erro) => {
        console.log("Erro Tentando Deletar Cliente!", erro);
      });
  }

  return (
    <div id="listar_cliente" className="container">
      <h1>Lista de Clientes</h1>
      <table className={styles.table}>
        <thead>
          <tr>
            <th>#</th>
            <th>Nome</th>
            <th>Telefone</th>
            <th>CPF</th>
            <th>Criado Em</th>
            <th>Alterar</th>
            <th>Deletar</th>
          </tr>
        </thead>
        <tbody>
          {clientes.map((cliente) => (
            <tr key={cliente.clienteId}>
              <td>{cliente.clienteId}</td>
              <td>{cliente.nome}</td>
              <td>{cliente.telefone}</td>
              <td>{cliente.cpf}</td>
              <td>{cliente.criadoEm}</td>
              <td>
                <Link to={`/pages/cliente/alterar/${cliente.clienteId}`}> Alterar </Link>
              </td>
              <td>
                <button onClick={() => deletarCliente(cliente.clienteId!)}
                >
                  Deletar
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  )
}

export default ListarCliente;