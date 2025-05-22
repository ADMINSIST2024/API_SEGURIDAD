using Microsoft.AspNetCore.Mvc;
using API_Seguridad.Models;
using Dto.DtosInputs.DtosUsuarioInputs;
using Dto.DtosOuputs.DtoUsuarioOutputs;
using Services.Repository.Interface;
using System.IdentityModel.Tokens.Jwt;
using Services.Repository;
using Models;
using Services.Repository.Implementacion;


namespace API_Seguridad.Controllers
{
    [ApiController]
    [Route("usuario")]
    public class UsuarioController : ControllerBase
    {
        public IConfiguration _configuration;
        public readonly IUsuarioRepository<Usuario> _UsuarioRepository;

        public readonly IJwtRepository<Jwt> _JwtRepository;

        public UsuarioController(IUsuarioRepository<Usuario> UsuarioRepository, IConfiguration configuration, IJwtRepository<Jwt> JwtRepository)
        {
            _UsuarioRepository = UsuarioRepository;
            _configuration = configuration;
            _JwtRepository = JwtRepository;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> IniciarSesion(LoginDtoInputs user)
        {
            object response;
            Usuario obj_usuario = new Usuario();
            obj_usuario.NOMUSU = user.NOMUSU;
            obj_usuario.PAWUSU = user.PAWUSU;

            Jwt obj_jwt = new Jwt();
            try
            {
                obj_usuario = await _UsuarioRepository.IniciarSesion(obj_usuario);

                if (obj_usuario == null)
                {
                    return new JsonResult(new
                    {
                        success = false,
                        message = "Credenciales incorrectas",
                        result = ""
                    });
                }

                LoginDtoOutputs Obj_LoginDtoOutputs = new LoginDtoOutputs();
                Obj_LoginDtoOutputs.CODPER = obj_usuario.CODPER;
                Obj_LoginDtoOutputs.NOMUSU = obj_usuario.NOMUSU;
                obj_jwt.CodigoUsuario = obj_usuario.CODPER;
                obj_jwt.NombreUsuario = obj_usuario.NOMUSU;

                //  token = _JwtRepository.GenerarToken(obj_jwt);

                response = new
                {
                    success = true,
                    message = "Login validado Correctamente",
                    result = new
                    {
                        //token = token,
                        datos = Obj_LoginDtoOutputs
                    }
                };
            }

            catch (Exception ex)
            {
                return new JsonResult(new { success = false, message = "Error Catch: " + ex.Message, StackTrace = ex.StackTrace, result = "" });
            }

            return new JsonResult(response);
        }

    }
}
