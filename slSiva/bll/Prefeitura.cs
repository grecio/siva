using CommonFrameWork;

namespace bll
{
    public class Prefeitura
    {

        public dal.DsPrefeitura.PrefeituraDataTable Listar()
        {
            using (var adp = new dal.DsPrefeituraTableAdapters.PrefeituraTableAdapter())
            {
                return adp.Listar();
            }
        }


        public void Incluir(string NM_PREFEITURA, string NM_PREFEITO, 
            string NM_SEC_TRIBUTACAO, string NM_CONTADOR, string NM_LOGRADOURO, string NU_NUMERO, 
            string TX_COMPLEMENTO, string TX_CONTATO, decimal NU_HABITANTES, decimal QT_EXTENSAO_TERRITORIAL)
        {
            using (var adp = new dal.DsPrefeituraTableAdapters.PrefeituraTableAdapter())
            {

                Validador.Validar(!string.IsNullOrWhiteSpace(NM_PREFEITURA), "Informe o nome da prefeitura");
                Validador.Validar(!string.IsNullOrWhiteSpace(NM_PREFEITO), "Informe o nome do prefeito.");

                adp.Incluir(NM_PREFEITURA, NM_PREFEITO, NM_SEC_TRIBUTACAO, NM_CONTADOR, NM_LOGRADOURO, 
                    NU_NUMERO, TX_COMPLEMENTO, TX_CONTATO, NU_HABITANTES, QT_EXTENSAO_TERRITORIAL);
            }
        }
    }
}
