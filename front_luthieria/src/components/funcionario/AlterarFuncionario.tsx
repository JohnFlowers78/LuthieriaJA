import axios from "axios";
import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { Funcionario } from "../../models/Funcionario";
import styles from "./AlterarFuncionario.module.css"

function AlterarFuncionario() {
  const navigate = useNavigate();
  const { funcionarioId } = useParams();

  const [ nome, setNome ] = useState("");
  const [ cargo, setCargo ] = useState("");
  const [ nRegistro, setNRegistro ] = useState("");

  useEffect(() => {
    if (funcionarioId) {
      axios
        .get<Funcionario>(`http://localhost:5028/api/funcionario/buscar/${funcionarioId}`)
        .then((resposta) => {
          setNome(resposta.data.nome);
          setCargo(resposta.data.cargo);
          setNRegistro(resposta.data.nRegistro);
          console.log("Funcionário Encontrado!", resposta.data);
        })
        .catch((erro) => {
          console.log("Erro ao Buscar Funcionário...", erro);
        });
    }
  }, []);

  function enviarFuncionario(e: any) {
    e.preventDefault();

    const funcionarioAlterado: Funcionario = {
      nome: nome,
      cargo: cargo,
      nRegistro: nRegistro,
    }

    axios
      .put(`http://localhost:5028/api/funcionario/alterar/${funcionarioId}`, funcionarioAlterado)
      .then((resposta) => {
        console.log("Funcionário Alterado!", resposta.data);
        navigate("/pages/funcionario/listar");
      })
      .catch((erro) => {
        console.log("Erro Tentando Alterar Funcionário...", erro);
      });
  }

  return ( 
    <div id="alterar_funcionario" className="container">
      <h1>Alterando o Funcionario: {nome}</h1>
      <form onSubmit={enviarFuncionario} className={styles.form}>
        <div>
          <label htmlFor="nome">Nome Completo</label>
          <input 
            id="nome" 
            type="text" 
            name="nome" 
            value={nome} 
            onChange={(e: any) => setNome(e.target.value)} />
        </div>
        <div>
          <label htmlFor="cargo">Cargo</label>
          <input 
            id="cargo" 
            type="text" 
            name="cargo" 
            value={cargo} 
            onChange={(e: any) => setCargo(e.target.value)} />
        </div>
        <div>
          <label htmlFor="nregistro">Nº de Registro</label>
          <input 
            id="nregistro" 
            type="text" 
            name="nregistro" 
            value={nRegistro} 
            onChange={(e: any) => setNRegistro(e.target.value)} />
        </div>
        <button type="submit"> Alterar Funcionário </button>
      </form>
    </div>
  );
}

export default AlterarFuncionario;