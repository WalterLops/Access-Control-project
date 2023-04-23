using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosAPI.Data.Dtos;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
    public class CadastroService
    {
        IMapper _mapper;
        private UserManager<IdentityUser<int>> _userManager;

        public CadastroService(IMapper mapper, UserManager<IdentityUser<int>> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public Result CadastraUsuario(CreateUsuarioDto creatUsuarioDto)
        {
            Usuario usuario = _mapper.Map<Usuario>(creatUsuarioDto);
            IdentityUser<int> usuarioIdentity = _mapper.Map<IdentityUser<int>>(creatUsuarioDto);
            var resultadoIdentity = _userManager.CreateAsync(usuarioIdentity, creatUsuarioDto.Password);
            if (resultadoIdentity.Result.Succeeded)
            {
                var code =  _userManager.GenerateEmailConfirmationTokenAsync(usuarioIdentity);
                return Result.Ok().WithSuccess(code.Result);
            }
            return Result.Fail("Erro ao cadastrar usuário");
        }
    }
}