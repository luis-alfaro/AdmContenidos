using System.Configuration;
using System.DirectoryServices;

namespace AdministradorContenidos.ActiveDirectory
{
    public class UsuarioAD
    {
        private static readonly UsuarioAD instance = new UsuarioAD();

        public static UsuarioAD Instance { get { return instance; } }

        private UsuarioAD() { }

        public bool LoginBanco(string username, string password)
        {
            string connectionAD = ConfigurationManager.AppSettings["LDAPBancoConnection"].ToString();
            string domainAD = ConfigurationManager.AppSettings["LDAPBancoDomain"].ToString();
            return this.Login(connectionAD, domainAD, username, password);
        }

        public bool LoginTienda(string username, string password)
        {
            string connectionAD = ConfigurationManager.AppSettings["LDAPTiendaConnection"].ToString();
            string domainAD = ConfigurationManager.AppSettings["LDAPTiendaDomain"].ToString();
            return this.Login(connectionAD, domainAD, username, password);
        }

        private bool Login(string connectionAD, string domainAD, string username, string password)
        {
            using (DirectoryEntry entryAD = new DirectoryEntry(connectionAD, domainAD + @"\" + username, password))
            {
                using (DirectorySearcher searchAD = new DirectorySearcher(entryAD))
                {
                    searchAD.Filter = "(SAMAccountName=" + username + ")";
                    SearchResult resultAD = searchAD.FindOne();
                    if (resultAD != null) return true;
                }
            }
            return false;
        }
    }
}
