using AutoMapper;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Sow.Automation.Dashboard.Interfaces;
using Sow.Automation.Dashboard.ViewModels;
using Sow.Automation.Data.Entidades.UsuarioAplicacaoContexto;
using Sow.Automation.Data.Entidades.UsuarioAplicacaoContexto.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace Sow.Automation.Dashboard.Services
{
    public class UserAppServices : IUserAppServices
    {
 
        private readonly IUserRepository _usuarioRepository;
        private readonly IMapper _mapper;
        public UserAppServices(IUserRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;

        }
        public void AdicionarUsuario(UserLoginViewModel user)
        {
            
        }

        public void AtualizaDadosSessao(UserLoginViewModel dados, ISession sessao)
        {
            sessao.SetString(ChaveSessao(), JsonConvert.SerializeObject(dados));
        }

        public bool Autenticar(UserLoginViewModel user)
        {
            user.SenhaUsuario = CalculateMD5Hash(user.SenhaUsuario);
            return _mapper.Map<UserLoginViewModel>(_usuarioRepository.ObterUsuario(_mapper.Map<UsuarioAplicacao>(user))) != null;
        }

        public UserLoginViewModel ObtemDadosSessao(ISession sessao)
        {
            var valor = sessao.GetString(ChaveSessao());

            return valor == null ? default(UserLoginViewModel) : JsonConvert.DeserializeObject<UserLoginViewModel>(valor);
        }

        public bool ValidaSessaoUsuario(ISession sessao)
        {
            var dados = ObtemDadosSessao(sessao);

            if (dados != null && dados.SenhaUsuario != null)
            {
                return true;
            }

            return false;
        }

        public UserLoginViewModel ObterDadosUsuario(long id)
        {
            return _mapper.Map<UserLoginViewModel>(_usuarioRepository.ObterUsuarioPorId(id));
        }

        public string ChaveSessao()
        {
            return "DashBoard";
        }

        private  string CalculateMD5Hash(string input)
        {
            // Calcular o Hash
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // Converter byte array para string hexadecimal
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
