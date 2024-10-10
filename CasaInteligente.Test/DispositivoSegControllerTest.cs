using AutoMapper;
using CasaInteligente.Controllers;
using CasaInteligente.Models;
using CasaInteligente.Services;
using CasaInteligente.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using System.Collections.Generic;

namespace CasaInteligente.Test;

public class DispositivoSegControllerTests
{
    private readonly DispositivoSegController _controller;
    private readonly Mock<IDispositivoSegService> _mockDispositivoService;
    private readonly Mock<IMapper> _mockMapper;

    public DispositivoSegControllerTests()
    {
        _mockDispositivoService = new Mock<IDispositivoSegService>();
        _mockMapper = new Mock<IMapper>();  // Inicializando o Mock<IMapper> aqui

        // Configuração adicional pode ser necessária para o mock do IMapper se houver mapeamento sendo feito no controller
        _mockMapper.Setup(m => m.Map<IEnumerable<DispositivoSegViewModel>>(It.IsAny<IEnumerable<DispositivoSegModel>>()))
            .Returns(new List<DispositivoSegViewModel>()); // Substitua isso com a lógica de mapeamento adequada

        _controller = new DispositivoSegController(_mockDispositivoService.Object, _mockMapper.Object);
    }

    [Fact]
    public void GetAllDispositivos_ReturnsStatusCode200()
    {
        // Arrange
        var fakeDispositivos = new List<DispositivoSegModel>() { new DispositivoSegModel() { DispositivoId = 4, LocalInstalacao = "Sensor de Porta" } };
        _mockDispositivoService.Setup(service => service.ListarDispositivos()).Returns(fakeDispositivos);

        // Act
        var result = _controller.Get();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.Equal(200, okResult.StatusCode);
    }
}