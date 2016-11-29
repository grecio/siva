using CommonFrameWork;
using Dominio;
using System.Collections.Generic;

namespace BLL
{
    public class BLLPrefeitura
    {

        public IEnumerable<Prefeitura> Listar()
        {
            using (var dao = new DAL.DbPrefeitura())
            {
                return dao.Listar();
            }
        }

        public Prefeitura Selecionar(decimal sqPrefeitura)
        {
            using (var dao = new DAL.DbPrefeitura())
            {
                return dao.Selecionar(sqPrefeitura);
            }
        }

        public void Incluir(Prefeitura prefeitura)
        {
            using (var dao = new DAL.DbPrefeitura())
            {

                Validador.Validar(!string.IsNullOrWhiteSpace(prefeitura.NM_PREFEITURA), "Informe o nome da prefeitura");
                Validador.Validar(!string.IsNullOrWhiteSpace(prefeitura.NM_PREFEITO), "Informe o nome do prefeito.");
                Validador.Validar(!string.IsNullOrWhiteSpace(prefeitura.NM_CONTADOR), "Informe o nome do contador.");
                Validador.Validar(!string.IsNullOrWhiteSpace(prefeitura.NM_LOGRADOURO), "Informe o logradouro.");
                Validador.Validar(!string.IsNullOrWhiteSpace(prefeitura.NU_NUMERO), "Informe o número.");
                Validador.Validar(!string.IsNullOrWhiteSpace(prefeitura.TX_COMPLEMENTO), "Informe o complemento.");
                Validador.Validar(!string.IsNullOrWhiteSpace(prefeitura.TX_CONTATO), "Informe o contato.");

                dao.Incluir(prefeitura);
            }
        }

        public void Atualizar(Prefeitura prefeitura)
        {
            using (var dao = new DAL.DbPrefeitura())
            {

                Validador.Validar(prefeitura.SQ_PREFEITURA > 0, "Selecione a prefeitura");
                Validador.Validar(!string.IsNullOrWhiteSpace(prefeitura.NM_PREFEITURA), "Informe o nome da prefeitura");
                Validador.Validar(!string.IsNullOrWhiteSpace(prefeitura.NM_PREFEITO), "Informe o nome do prefeito.");
                Validador.Validar(!string.IsNullOrWhiteSpace(prefeitura.NM_CONTADOR), "Informe o nome do contador.");
                Validador.Validar(!string.IsNullOrWhiteSpace(prefeitura.NM_LOGRADOURO), "Informe o logradouro.");
                Validador.Validar(!string.IsNullOrWhiteSpace(prefeitura.NU_NUMERO), "Informe o número.");
                Validador.Validar(!string.IsNullOrWhiteSpace(prefeitura.TX_COMPLEMENTO), "Informe o complemento.");
                Validador.Validar(!string.IsNullOrWhiteSpace(prefeitura.TX_CONTATO), "Informe o contato.");

                dao.Atualizar(prefeitura);
            }
        }

        public void Excluir(decimal SQ_PREFEITURA)
        {
            using (var dao = new DAL.DbPrefeitura())
            {

                Validador.Validar(SQ_PREFEITURA > 0, "Informe a prefeitura.");

                dao.Excluir(SQ_PREFEITURA);
            }
        }
    }
}
