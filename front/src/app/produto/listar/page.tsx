"use client";
import api from "@/app/services/api";
import Produto from "@/app/types/produto";
import axios from "axios";
import { useEffect, useState } from "react";

function ProdutoListar(){
  const [produtos, setProdutos] = useState<Produto[]>([]);

  useEffect(() => {
    api.get<Produto[]>("/produto/listar")
    .then((resposta) => {
      setProdutos(resposta.data);
      console.table(resposta.data)
    })
    .catch((erro) => {
      console.log(erro);
    });
  },[]);
  return(
    <div>
      <h1>Listar Produtos</h1>
      <table>
        <thead>
          <tr>
            <td>#</td>
            <td>Nome</td>
            <td>Criado Em</td>
          </tr>
        </thead>
        <tbody>
          {produtos.map((produto) => (
            <tr key={produto.id}>
              <td>{produto.id}</td>
              <td>{produto.nome}</td>
              <td>{produto.criadoEm}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default ProdutoListar;