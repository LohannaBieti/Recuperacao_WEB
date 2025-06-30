using System;
using API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data;

public interface ICategoriaRepository
{
     void Cadastrar(Categoria categeoria);
    Categoria BuscarCategoriaPorId(int id);
    List<Categoria> Listar();
}
