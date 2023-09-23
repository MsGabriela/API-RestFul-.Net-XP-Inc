using APIIO.Api.ViewModels;
using APIIO.Business.Interfaces.Repositories;
using APIIO.Business.Interfaces.Services;
using APIIO.Business.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIIO.Business.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IMapper _mapper;
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoService(IProdutoRepository produtoRepository,  IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }
        public async Task<ProdutoViewModel> Adicionar(ProdutoViewModel produto)
        {
            
            await _produtoRepository.Adicionar(_mapper.Map<Produto>(produto));
            return produto;
        }

        public async Task<ProdutoViewModel> Atualizar(ProdutoViewModel produto)
        {
            await _produtoRepository.Atualizar(_mapper.Map<Produto>(produto));
            return produto;
        }

        public async Task<ProdutoViewModel> ObterPorId(Guid id)
        {
            return _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterPorId(id));
           
            
        }

        public async Task<ICollection<ProdutoViewModel>> ObterTodos()
        {
            return _mapper.Map<ICollection<ProdutoViewModel>>(await _produtoRepository.ObterTodos());
        }

        public async Task Remover(Guid id)
        {
            await _produtoRepository.Remover(id);
        }
    }
}
