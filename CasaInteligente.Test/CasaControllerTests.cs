using AutoMapper;
using CasaInteligente.Controllers;
using CasaInteligente.Models;
using CasaInteligente.Services;
using CasaInteligente.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CasaInteligente.Test;

public class CasaControllerTests
{
    private readonly CasaController _controller;
    private readonly Mock<ICasaService> _mockCasaService;
    private readonly Mock<IMapper> _mockMapper;
    private IUsuarioService _mockUsuarioService;

    public CasaControllerTests()
    {
        _mockCasaService = new Mock<ICasaService>();
        _mockMapper = new Mock<IMapper>();
        _controller = new CasaController( _mockUsuarioService,_mockCasaService.Object, _mockMapper.Object);
    }

    [Fact]
    public void GetAllCasas_ReturnsStatusCode200()
    {
        // Arrange
        var fakeCasas = new List<CasaModel>() { new CasaModel() { CasaId = 1, Endereco = "Minha Casa" } };
        var fakeViewModels = new List<CasaViewModel>() { new CasaViewModel() { CasaId = 1, Endereco = "Minha Casa" } };

        _mockCasaService.Setup(service => service.ListarCasas()).Returns(fakeCasas);
        _mockMapper.Setup(mapper => mapper.Map<IEnumerable<CasaViewModel>>(It.IsAny<IEnumerable<CasaModel>>())).Returns(fakeViewModels);

        // Act
        var result = _controller.Get();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.Equal(200, okResult.StatusCode);
    }
}