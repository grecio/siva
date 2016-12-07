using CommonFrameWork;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLContador
    {
        public IEnumerable<Contador> Listar()
        {
            using (var dao = new DAL.DbContador())
            {
                return dao.Listar();
            }
        }

        public Contador Selecionar(decimal SQ_CONTADOR)
        {
            Validador.Validar(SQ_CONTADOR > 0, "Informe o contador.");

            using (var dao = new DAL.DbContador())
            {
                return dao.Selecionar(SQ_CONTADOR);
            }
        }


        public void Excluir(decimal SQ_CONTADOR)
        {
            Validador.Validar(SQ_CONTADOR > 0, "Informe o contador.");            

            using (var dao = new DAL.DbContador())
            {
                dao.Excluir(SQ_CONTADOR);
            }
        }

        public void Incluir(Contador contador)
        {
            Validador.Validar(contador.NU_CRC > 0, "Informe o CRC.");
            Validador.Validar(!string.IsNullOrWhiteSpace(contador.NM_CONTADOR), "Informe o nome do contador.");
            Validador.Validar(!string.IsNullOrWhiteSpace(contador.NM_LOGRADOURO), "Informe o logradouro.");
            Validador.Validar(!string.IsNullOrWhiteSpace(contador.NU_LOGRADOURO), "Informe o número.");
            Validador.Validar(!string.IsNullOrWhiteSpace(contador.NU_TELEFONE), "Informe um telefone para contato.");

            using (var dao = new DAL.DbContador())
            {
                dao.Incluir(contador);
            }
        }

        public void Atualizar(Contador contador)
        {

            Validador.Validar(contador.SQ_CONTADOR > 0, "Informe um contador.");
            Validador.Validar(contador.NU_CRC > 0, "Informe o CRC.");
            Validador.Validar(!string.IsNullOrWhiteSpace(contador.NM_CONTADOR), "Informe o nome do contador.");
            Validador.Validar(!string.IsNullOrWhiteSpace(contador.NM_LOGRADOURO), "Informe o logradouro.");
            Validador.Validar(!string.IsNullOrWhiteSpace(contador.NU_LOGRADOURO), "Informe o número.");
            Validador.Validar(!string.IsNullOrWhiteSpace(contador.NU_TELEFONE), "Informe um telefone para contato.");

            using (var dao = new DAL.DbContador())
            {
                dao.Atualizar(contador);
            }
        }
    }
}
