using AutoMapper;
using CasaInteligente.Controllers;
using CasaInteligente.Models;
using CasaInteligente.Services;
using CasaInteligente.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CasaInteligente.Test;

public class UsuarioControllerTests
{
    private readonly UsuarioController _controller;
    private readonly Mock<IUsuarioService> _mockUsuarioService;
    private readonly Mock<ICasaService> _mockCasaService;
    private readonly Mock<IMapper> _mockMapper;

    public UsuarioControllerTests()
    {
        _mockUsuarioService = new Mock<IUsuarioService>();
        _mockCasaService = new Mock<ICasaService>();
        _mockMapper = new Mock<IMapper>();
        _controller = new UsuarioController(_mockUsuarioService.Object, _mockCasaService.Object, _mockMapper.Object);
    }

    [Fact]
    public void Get_ReturnsStatusCode200()
    {
        // Arrange
        var fakeUsuarios = new List<UsuarioModel>() { new UsuarioModel() { UsuarioId = 1, Nome = "Teste" } };
        var fakeViewModels = new List<UsuarioViewModel>() { new UsuarioViewModel() { UsuarioId = 1, Nome = "Teste" } };

        _mockUsuarioService.Setup(service => service.ListarUsuarios()).Returns(fakeUsuarios);
        _mockMapper.Setup(mapper => mapper.Map<IEnumerable<UsuarioViewModel>>(It.IsAny<IEnumerable<UsuarioModel>>())).Returns(fakeViewModels);

        // Act
        var result = _controller.Get();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.Equal(200, okResult.StatusCode);
        Assert.IsAssignableFrom<IEnumerable<UsuarioViewModel>>(okResult.Value);
    }
}