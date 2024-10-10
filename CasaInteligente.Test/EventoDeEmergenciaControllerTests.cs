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

public class EventoDeEmergenciaControllerTests
{
    private readonly EventoDeEmergenciaController _controller;
    private readonly Mock<IEventoDeEmergenciaService> _mockEventoDeEmergenciaService;
    private readonly Mock<IMapper> _mockMapper;

    public EventoDeEmergenciaControllerTests()
    {
        _mockEventoDeEmergenciaService = new Mock<IEventoDeEmergenciaService>();
        _mockMapper = new Mock<IMapper>();

        // Configure o IMapper se necessário, dependendo do que o controller faz
        _mockMapper.Setup(m => m.Map<IEnumerable<EventoDeEmergenciaViewModel>>(It.IsAny<IEnumerable<EventoDeEmergenciaModel>>()))
            .Returns(new List<EventoDeEmergenciaViewModel>());

        _controller = new EventoDeEmergenciaController( _mockMapper.Object, _mockEventoDeEmergenciaService.Object);
    }

    [Fact]
    public void GetAllEventosDeEmergencia_ReturnsStatusCode200()
    {
        // Arrange
        var fakeEventos = new List<EventoDeEmergenciaModel>() { new EventoDeEmergenciaModel() { EventoId = 1, Tipo = "Incêndio" } };
        _mockEventoDeEmergenciaService.Setup(service => service.ListarEventos()).Returns(fakeEventos);

        // Act
        var result = _controller.Get();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.Equal(200, okResult.StatusCode);
    }
}