using CommonFrameWork;

namespace BLL
{
    public class Prefeitura
    {

        public DAL.DsPrefeitura.PrefeituraDataTable Listar()
        {
            using (var adp = new DAL.DsPrefeituraTableAdapters.PrefeituraTableAdapter())
            {
                return adp.Listar();
            }
        }


        public void Incluir(string NM_PREFEITURA, string NM_PREFEITO, 
            string NM_SEC_TRIBUTACAO, string NM_CONTADOR, string NM_LOGRADOURO, string NU_NUMERO, 
            string TX_COMPLEMENTO, string TX_CONTATO, decimal NU_HABITANTES, decimal QT_EXTENSAO_TERRITORIAL)
        {
            using (var adp = new DAL.DsPrefeituraTableAdapters.PrefeituraTableAdapter())
            {

                Validador.Validar(!string.IsNullOrWhiteSpace(NM_PREFEITURA), "Informe o nome da prefeitura");
                Validador.Validar(!string.IsNullOrWhiteSpace(NM_PREFEITO), "Informe o nome do prefeito.");
                Validador.Validar(!string.IsNullOrWhiteSpace(NM_CONTADOR), "Informe o nome do contador.");
                Validador.Validar(!string.IsNullOrWhiteSpace(NM_LOGRADOURO), "Informe o logradouro.");
                Validador.Validar(!string.IsNullOrWhiteSpace(NU_NUMERO), "Informe o número.");
                Validador.Validar(!string.IsNullOrWhiteSpace(TX_COMPLEMENTO), "Informe o complemento.");
                Validador.Validar(!string.IsNullOrWhiteSpace(TX_CONTATO), "Informe o contato.");

                adp.Incluir(NM_PREFEITURA, NM_PREFEITO, NM_SEC_TRIBUTACAO, NM_CONTADOR, NM_LOGRADOURO, 
                    NU_NUMERO, TX_COMPLEMENTO, TX_CONTATO, NU_HABITANTES, QT_EXTENSAO_TERRITORIAL);
            }
        }
    }
}
