using Bogus;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UsuarioApp.Tests.Helpers;
using UsuariosApp.Application.Models.Requests;
using UsuariosApp.Application.Models.Responses;
using Xunit;

namespace UsuarioApp.Tests
{
    public class UsuariosTest
    {
        [Fact]
        public async Task<CriarContaResponseDTO> Usuarios_Post_CriarConta_Returns_Created()
        {
            var faker = new Faker("pt_BR");
            var request = new CriarContaRequestDTO
            {
                Nome = faker.Person.FullName,
                Email = faker.Internet.Email(),
                Senha = "@Teste123"
            };

            var content = TestHelper.CreateContent(request);
            var result = await TestHelper.CreateClient.PostAsync("/api/usuarios/criar-conta", content);

            result.StatusCode
                .Should()
                .Be(HttpStatusCode.Created);

            var response = TestHelper.ReadResponse<CriarContaResponseDTO>(result);

            response.Id.Should().NotBeEmpty();
            response.Nome.Should().Be(request.Nome);
            response.Email.Should().Be(request.Email);
            response.DataHoraCriacao.Should().NotBeNull();

            return response;
        }

        [Fact]
        public async void Usuarios_Post_CriarConta_Returns_BadRequest()
        {
            var usuario = await Usuarios_Post_CriarConta_Returns_Created();

            var request = new CriarContaRequestDTO
            {
                Nome = usuario.Nome,
                Email = usuario.Email,
                Senha = "@Teste123"
            };

            var content = TestHelper.CreateContent(request);
            var result = await TestHelper.CreateClient.PostAsync("/api/usuarios/criar-conta", content);

            result.StatusCode
                .Should()
                .Be(HttpStatusCode.BadRequest);


        }

        [Fact(Skip = "Não implementado")]
        public void Usuarios_Post_CriarConta_Returns_Ok()
        {
            //TODO
        }

        [Fact(Skip = "Não implementado")]
        public void Usuarios_Post_CriarConta_Returns_Unathorized()
        {
            //TODO
        }
    }
}
