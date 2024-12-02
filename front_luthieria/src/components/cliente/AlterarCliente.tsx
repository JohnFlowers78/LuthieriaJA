import axios from "axios";
import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { Cliente } from "../../models/Cliente";
import styles from "./AlterarCliente.module.css"

function AlterarCliente() {
  const navigate = useNavigate();

  const { clienteId } = useParams();
  const [ nome, setNome ] = useState("");
  const [ telefone, setTelefone ] = useState("");
  const [ cpf, setCpf ] = useState("");

  useEffect(() => {
    if (clienteId) {
      axios
        .get<Cliente>(`http://localhost:5028/api/cliente/buscar/${clienteId}`)
        .then((resposta) => {
          setNome(resposta.data.nome);
          setTelefone(resposta.data.telefone);
          setCpf(resposta.data.cpf);
        })
        .catch((erro) => {
          console.log("Erro Tentando Buscar Cliente...", erro);
        });
    }
  }, []);

  function enviarCliente(e: any) {
    e.preventDefault();

    const clienteAlterado: Cliente = {
      nome: nome,
      telefone: telefone,
      cpf: cpf,
    }

    axios
      .put(`http://localhost:5028/api/cliente/alterar/${clienteId}`, clienteAlterado)
      .then((resposta) => {
        console.log("Cliente Alterado!", resposta.data);
        navigate("/pages/cliente/listar");
      })
      .catch((erro) => {
        console.log("Erro Tentando Alterar Cliente...", erro);
      });
  }

  return (
    <div id="alterar_cliente" className="container">
      <h1>Alterando o Cliente: {nome}</h1>
      <form onSubmit={enviarCliente} className={styles.form}>
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
          <label htmlFor="telefone">Nº de Celular</label>
          <input 
            id="telefone" 
            type="text" 
            name="telefone" 
            value={telefone} 
            onChange={(e: any) => setTelefone(e.target.value)} />
        </div>
        <div>
          <label htmlFor="cpf">CPF</label>
          <input 
            id="cpf" 
            type="text" 
            name="cpf" 
            value={cpf} 
            onChange={(e: any) => setCpf(e.target.value)} />
        </div>
        <button type="submit">Alterar Cliente</button>
      </form>
    </div>
  );
}

export default AlterarCliente;