using Dominio;

namespace siva.api.Models
{
    public class ContadorViewModel
    {
        public Contador Contador { get; set; }
        public bool EnderecoDesnormalizado
        {
            get
            {
                return                     
                    (string.IsNullOrWhiteSpace(Contador.NU_LOGRADOURO) &&
                    string.IsNullOrWhiteSpace(Contador.NM_COMPLEMENTO) &&
                    string.IsNullOrWhiteSpace(Contador.NU_CEP) &&
                    string.IsNullOrWhiteSpace(Contador.NM_BAIRRO) &&
                    string.IsNullOrWhiteSpace(Contador.NU_TELEFONE) &&
                    string.IsNullOrWhiteSpace(Contador.NM_EMAIL_COMERCIAL));                
            }
        }
    }
}