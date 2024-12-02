import { useState } from "react";
import { Funcionario } from "../../models/Funcionario";
import { useNavigate } from "react-router-dom";
import axios from "axios";
import styles from "./CadastrarFuncionario.module.css"

function CadastrarFuncionario() {
  const navigate = useNavigate();    //          navigate("/pages/produto/listar");   -->   Exemplo de uso

  const [ nome, setNome ] = useState("");
  const [ cargo, setCargo ] = useState("");
  const [ nRegistro, setNRegistro ] = useState("");

  function enviarFuncionario(e: any) {
    e.preventDefault();

    const funcionario: Funcionario = {
      nome: nome,
      cargo: cargo,
      nRegistro: nRegistro,
    }

    axios
    .post("http://localhost:5028/api/funcionario/cadastrar", funcionario)
    .then((resposta) => {
      console.log("O Produto Foi Cadastrado!", resposta.data);
      navigate("/pages/funcionario/listar");
    })
    .catch((erro) => {
      console.log("Erro na tentativa de Cadastrar o Funcionário!", erro);
    });
  }

  return(
    <div id="cadastrar_funcionario" className="container">
      <h1>Cadastrar Novo Funcionário</h1>
      <form onSubmit={enviarFuncionario} className={styles.form}>
        <div>
          <label htmlFor="nome">Nome Completo</label>
          <input 
            id="nome" 
            type="text" 
            name="nome" 
            required 
            onChange={(e: any) => setNome(e.target.value)} />
        </div>
        <div>
          <label htmlFor="cargo">Cargo</label>
          <input 
            id="cargo" 
            type="text" 
            name="cargo"
            required 
            onChange={(e: any) => setCargo(e.target.value)} />
        </div>
        <div>
          <label htmlFor="nregistro">Número de Registro</label>
          <input 
            id="nregistro" 
            type="text" 
            name="nregistro" 
            required 
            onChange={(e: any) => setNRegistro(e.target.value)} />
        </div>

        <button type="submit">Cadastrar Funcionário</button>
      </form>
    </div>
  )
}

export default CadastrarFuncionario;