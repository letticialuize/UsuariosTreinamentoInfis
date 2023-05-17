using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Application.Helpers;
using UsuariosApp.Application.Interfaces;
using UsuariosApp.Application.Models.Requests;
using UsuariosApp.Application.Models.Responses;
using UsuariosApp.Domain.Interfaces.Services;
using UsuariosApp.Domain.Models;

namespace UsuariosApp.Application.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioDomainService? _usuarioDomainService;
        private readonly IMapper? _mapper;
        public UsuarioAppService(IUsuarioDomainService? usuarioDomainService, IMapper? mapper)
        {
            _usuarioDomainService = usuarioDomainService;
            _mapper = mapper;
        }
        public AutenticarResponseDTO Autenticar(AutenticarRequestDTO dto)
        {
            var usuario = _usuarioDomainService?.Autenticar(dto.Email, Sha1Helper.Encrypt(dto.Senha));
            return _mapper.Map<AutenticarResponseDTO>(usuario);
        }

        public CriarContaResponseDTO CriarConta(CriarContaRequestDTO dto)
        {
            var usuario = _mapper.Map<Usuario>(dto);

            _usuarioDomainService?.CriarConta(usuario);

            return _mapper.Map<CriarContaResponseDTO>(usuario);
        }

        public void Dispose()
        {
            _usuarioDomainService?.Dispose();
        }

        public RecuperarSenhaResponseDTO RecuperarSenha(RecuperarSenhaRequestDTO dto)
        {
            var usuario = _usuarioDomainService.RecuperarSenha(dto.Email);

            return _mapper.Map<RecuperarSenhaResponseDTO>(usuario);
        }
    }
}
