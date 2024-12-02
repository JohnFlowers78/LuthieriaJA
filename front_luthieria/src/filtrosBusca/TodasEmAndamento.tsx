import { useEffect, useState } from "react";
import { OrdemDeServico } from "../../src/models/OrdemDeServico";
import axios from "axios";
import { Link } from "react-router-dom";
import styles from "./ListarOrdemServico.module.css"

function BuscarTodasEmAndamento() {
  const [ ordensDeServicos, setOrdensDeServicos ] = useState<OrdemDeServico[]>([]);

  useEffect(() => {
    axios
      .get<OrdemDeServico[]>("http://localhost:5028/ordemservico/status/emAndamento")
      .then((resposta) => {
        setOrdensDeServicos(resposta.data);
        console.log("Ordens de Serviços Listadas!", resposta.data);
      })
      .catch((erro) => {
        console.log("Erro Tentando Listar OrdensDeServiços...", erro);
      });
  });

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
    <div id="ordensservicos_em_andamento" className="container">
      <h1>Todas Ordens de Serviço "Em Andamento"</h1>
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
          {ordensDeServicos.map((ordemDeServico) => (
            <tr key={ordemDeServico.ordemDeServicoId}>
              <td>{ordemDeServico.ordemDeServicoId}</td>
              <td>{ordemDeServico.descricaoServico}</td>
              <td>{ordemDeServico.instrumento}</td>
              <td>{ordemDeServico.status}</td>
              <td>R$ {ordemDeServico.valorEstimado}</td>
              <td>{ordemDeServico.cliente?.nome}</td>
              <td>{ordemDeServico.funcionario?.nome}</td>
              <td>{ordemDeServico.criadoEm}</td>
              <td>
                <Link 
                  to={`/pages/ordemservico/alterar/${ordemDeServico.ordemDeServicoId}`}
                > 
                  Alterar
                </Link>
              </td>
              <td>
                <button onClick={() => deletarOrdemSevico(ordemDeServico.ordemDeServicoId!)}> Deletar </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default BuscarTodasEmAndamento;