import React from 'react';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Nav from './components/layout/Nav';
import Footer from './components/layout/Footer';
import CadastrarOrdemServico from './components/ordemServico/CadastrarOrdemServico';
import ListarFuncionario from './components/funcionario/ListarFuncionario';
import AlterarFuncionario from './components/funcionario/AlterarFuncionario';
import CadastrarFuncionario from './components/funcionario/CadastrarFuncionario';
import ListarCliente from './components/cliente/ListarCliente';
import CadastrarCliente from './components/cliente/CadastrarCliente';
import AlterarCliente from './components/cliente/AlterarCliente';
import ListarOrdemServico from './components/ordemServico/ListarOrdemServico';
import AlterarOrdemServico from './components/ordemServico/AlterarOrdemServico';
import BuscarTodosServicosCliente from './filtrosBusca/BuscarTodasDoCliente';
import BuscarTodosServicosFuncionario from './filtrosBusca/BuscarTodosDoFuncionario';
import BuscarFinalizadasDoCliente from './filtrosBusca/BuscarFinalizadasDoCliente';
import BuscarTodasEmAndamento from './filtrosBusca/TodasEmAndamento';
import BuscarTodasPendentes from './filtrosBusca/TodasPendentes';

function App() {
  return (
    <div className="App">
      <BrowserRouter>
        <Nav />

        <Routes>

          <Route 
            path="/" 
            element={<ListarOrdemServico />} />
          
          <Route 
            path="/pages/funcionario/" 
            element={<ListarFuncionario />} />
          <Route 
            path="/pages/funcionario/cadastrar" 
            element={<CadastrarFuncionario />} />
          <Route 
            path="/pages/funcionario/listar" 
            element={<ListarFuncionario />} />
          <Route 
            path="/pages/funcionario/alterar/:funcionarioId" 
            element={<AlterarFuncionario />} />

          <Route 
            path="/pages/cliente/" 
            element={<ListarCliente />} />
          <Route 
            path="/pages/cliente/cadastrar" 
            element={<CadastrarCliente />} />
          <Route 
            path="/pages/cliente/listar" 
            element={<ListarCliente />} />
          <Route 
            path="/pages/cliente/alterar/:clienteId" 
            element={<AlterarCliente />} />

          <Route 
            path="/pages/ordemservico/" 
            element={<ListarOrdemServico />} />
          <Route 
            path="/pages/ordemservico/cadastrar" 
            element={<CadastrarOrdemServico />} />
          <Route 
            path="/pages/ordemservico/listar" 
            element={<ListarOrdemServico />} />
          <Route 
            path="/pages/ordemservico/alterar/:ordemDeServicoId" 
            element={<AlterarOrdemServico />} />

                                      {/* FILTROS DE PESQUISAS / BUSCAS */}

          <Route 
            path="/pages/buscar/ordensdeservicos/todas/emAndamento" 
            element={<BuscarTodasEmAndamento />} />
          <Route 
            path="/pages/buscar/ordensdeservicos/todas/pendente" 
            element={<BuscarTodasPendentes />} />
          <Route 
            path="/pages/buscar/finalizadas/cliente" 
            element={<BuscarFinalizadasDoCliente />} />
          <Route 
            path="/pages/buscar/todospedidos/cliente" 
            element={<BuscarTodosServicosCliente />} />
          <Route 
            path="/pages/buscar/todosservicos/funcionario" 
            element={<BuscarTodosServicosFuncionario />} />
          {/* <Route 
            path="/pages/ordemservico/listar" 
            element={<ListarOrdemServico />} /> */}
        </Routes>

        <Footer />
      </BrowserRouter>
    </div>
  );
}

export default App;
