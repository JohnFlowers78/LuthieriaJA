import { Link } from "react-router-dom";
import "./layout_styles.css";

function Nav() {
  return (
    <nav>
      <ul>
        <li className="dropdown">
          Cliente
          <ul className="dropdown-menu">
            <li>
              <Link to="/pages/cliente/listar">Listar Clientes</Link>
            </li>
            <li>
              <Link to="/pages/cliente/cadastrar/">Cadastrar Cliente</Link>
            </li>
          </ul>
        </li>

        <li className="dropdown">
          Funcionário
          <ul className="dropdown-menu">
            <li>
              <Link to="/pages/funcionario/listar">Listar Funcionários</Link>
            </li>
            <li>
              <Link to="/pages/funcionario/cadastrar/">Cadastrar Funcionário</Link>
            </li>
          </ul>
        </li>

        <li className="dropdown">
          Ordem de Serviço
          <ul className="dropdown-menu">
            <li>
              <Link to="/pages/ordemservico/listar">Listar Ordens de Serviço</Link>
            </li>
            <li>
              <Link to="/pages/ordemservico/cadastrar/">Cadastrar Ordem de Serviço</Link>
            </li>
          </ul>
        </li>

        <li className="dropdown">
          Filtros de Busca
          <ul className="dropdown-menu">
            <li>
              <Link to="/pages/buscar/ordensdeservicos/todas/emAndamento"> Todos Serviços "Em Andamento" </Link>
            </li>
            <li>
              <Link to="/pages/buscar/ordensdeservicos/todas/pendente"> Todos Serviços "Pendentes" </Link>
            </li>
            <li>
              <Link to="/pages/buscar/finalizadas/cliente"> Pedidos Finalizados de um Cliente </Link>
            </li>
            <li>
              <Link to="/pages/buscar/todospedidos/cliente"> Todos os Pedidos de um Cliente </Link>
            </li>
            <li>
              <Link to="/pages/buscar/todosservicos/funcionario"> Todos os Serviços de um Funcionario </Link>
            </li>
          </ul>
        </li>
      </ul>
    </nav>
  );
}

export default Nav;