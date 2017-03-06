using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLMunicipio
    {
        public IEnumerable<Municipio> RetornaMunicipio()
        {
            using (var dao = new DAL.DbMunicipio())
            {
                return dao.RetornaMunicipio();
            }
        }

        public IEnumerable<Municipio> RetornaMunicipio(Usuario usuario)
        {
            using (var dao = new DAL.DbMunicipio())
            {
                return dao.RetornaMunicipio(usuario);
            }
        }
    }
}
