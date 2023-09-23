using APIIO.Api.ViewModels;
using APIIO.Business.Interfaces.Repositories;
using APIIO.Business.Interfaces.Services;
using APIIO.Business.Models;
using APIIO.Business.Services;
using AutoFixture;
using AutoMapper;
using Moq;

namespace APIIO.Tests
{
    public class ProdutosUnitsTests
    {
        [Fact]
        public async void InsereProdutoSucesso()
        {
            // Arrange
            var addProdutoInputModel = new Fixture().Create<ProdutoViewModel>();
            addProdutoInputModel.Nome = "Teste";
            addProdutoInputModel.Descricao = "Testando o teste";
            addProdutoInputModel.Valor = 100;
        

            var produtosRepositoryMock = new Mock<IProdutoRepository>();

            var mapperMock = new Mock<IMapper>();

            var produtoService = new ProdutoService(produtosRepositoryMock.Object, mapperMock.Object);

            // Act
            var result = await produtoService.Adicionar(addProdutoInputModel);
            

            // Assert
            Assert.Equal(addProdutoInputModel.Nome, result.Nome);
            Assert.Equal(addProdutoInputModel.Descricao, result.Descricao);
            Assert.Equal(addProdutoInputModel.Valor, result.Valor);

            produtosRepositoryMock.Verify(er => er.Adicionar(It.IsAny<Produto>()), Times.Once);
        }

        [Fact]
        public async void InsereProdutoSemSucesso()
        {
            // Arrange
            var addProdutoInputModel = new Fixture().Create<ProdutoViewModel>();
            addProdutoInputModel.Nome = "";
            addProdutoInputModel.Descricao = "";
            addProdutoInputModel.Valor = 100;

            var produtoServiceMock = new Mock<IProdutoService>();

            produtoServiceMock.Verify(er => er.Adicionar(It.IsAny<ProdutoViewModel>()), Times.Never);
        }
    }
}