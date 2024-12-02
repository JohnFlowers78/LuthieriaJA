import { useEffect, useState } from "react";
import { Funcionario } from "../../models/Funcionario";
import axios from "axios";
import { Link } from "react-router-dom";
import styles from "./ListarFuncionario.module.css"

function ListarFuncionario() {

  const [ funcionarios, setFuncionarios ] = useState<Funcionario[]>([]);

  useEffect(() => {
    axios
      .get<Funcionario[]>("http://localhost:5028/api/funcionario/listar")
      .then((resposta) => {
        setFuncionarios(resposta.data);
        console.log("Funcionarios Listados!", resposta.data);
      })
      .catch((erro) => {
        console.log("Erro Tentando Listar Funcionarios...", erro);
      });
  });

  function deletarFuncionario(idFuncionario: number) {
    if (idFuncionario) {
      axios
        .delete(`http://localhost:5028/api/funcionario/deletar/${idFuncionario}`)
        .then((resposta) => {
          console.log(resposta);
        })
        .catch((erro) => {
          console.log("Erro Tentando Deletar Funcionário...", erro);
        });
    }
  }

  return (
    <div id="listar_funcionario" className="container">
      <h1>Lista de Funcionários</h1>
      <table className={styles.table}>
        <thead>
          <tr>
            <th>#</th>
            <th>Nome</th>
            <th>Cargo</th>
            <th>Nº de Registro</th>
            <th>Criado Em</th>
            <th>Alterar</th>
            <th>Deletar</th>
          </tr>
        </thead>
        <tbody>
          {funcionarios.map((funcionario) => (
            <tr key={funcionario.funcionarioId}>
              <td>{funcionario.funcionarioId}</td>
              <td>{funcionario.nome}</td>
              <td>{funcionario.cargo}</td>
              <td>{funcionario.nRegistro}</td>
              <td>{funcionario.criadoEm}</td>
              <td>
                <Link to={`/pages/funcionario/alterar/${funcionario.funcionarioId}`}
                >
                  Alterar 
                </Link>
              </td>
              <td>
                <button onClick={() => deletarFuncionario(funcionario.funcionarioId!)}
                > 
                  Deletar 
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default ListarFuncionario;