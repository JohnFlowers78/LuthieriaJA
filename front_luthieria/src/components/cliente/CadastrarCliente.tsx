import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { Cliente } from "../../models/Cliente";
import axios from "axios";
import styles from "./CadastrarCliente.module.css"

function CadastrarCliente() {
  const navigate = useNavigate();

  const [ nome, setNome ] = useState("");
  const [ telefone, setTelefone ] = useState("");
  const [ cpf, setCpf ] = useState("");

  function enviarCliente(e: any) {
    e.preventDefault();

    const cliente: Cliente = {
      nome: nome,
      telefone: telefone,
      cpf: cpf,
    }

    axios
      .post("http://localhost:5028/api/cliente/cadastrar", cliente)
      .then((resposta) => {
        console.log("O Cliente Foi Cadastrado!", resposta.data);
        navigate("/pages/cliente/listar")
      })
      .catch((erro) => {
        console.log("Erro ao tentar Cadastrar o Cliente...", erro);
      });
  }

  return(
    <div id="cadastrar_cliente" className="container">
      <h1>Cadastrar Novo Cliente</h1>
      <form onSubmit={enviarCliente} className={styles.form}>
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
          <label htmlFor="telefone">Nº de Celular</label>
          <input 
            id="telefone" 
            type="text" 
            name="telefone" 
            required 
            onChange={(e: any) => setTelefone(e.target.value)} />
        </div>
        <div>
          <label htmlFor="cpf">CPF</label>
          <input 
            id="cpf" 
            type="text" 
            name="cpf" 
            required 
            onChange={(e: any) => setCpf(e.target.value)} />
        </div>
        <button type="submit">Cadastrar Cliente</button>
      </form>
    </div>
  )
}

export default CadastrarCliente;