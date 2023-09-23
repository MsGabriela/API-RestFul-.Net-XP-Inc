using APIIO.Api.ViewModels;
using APIIO.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIIO.Business.Interfaces.Services
{
    public interface IProdutoService
    {

        Task<ProdutoViewModel> Adicionar(ProdutoViewModel produto);
        Task<ProdutoViewModel> Atualizar(ProdutoViewModel produto);
        Task Remover(Guid id);

        Task<ProdutoViewModel> ObterPorId(Guid id);
        Task<ICollection<ProdutoViewModel>> ObterTodos();
    }
}
