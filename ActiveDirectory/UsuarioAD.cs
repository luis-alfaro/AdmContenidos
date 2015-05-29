using System.Configuration;
using System.DirectoryServices;

namespace AdministradorContenidos.ActiveDirectory
{
    public class UsuarioAD
    {
        private static readonly UsuarioAD instance = new UsuarioAD();

        public static UsuarioAD Instance { get { return instance; } }

        private UsuarioAD() { }

        public bool Login(string username, string password)
        {
            string connectionAD = ConfigurationManager.AppSettings["ActiveDirectoryConnection"].ToString();
            string domainAD = ConfigurationManager.AppSettings["ActiveDirectoryDomain"].ToString();

            DirectoryEntry entryAD = new DirectoryEntry(connectionAD, domainAD + @"\" + username, password);
            DirectorySearcher searchAD = new DirectorySearcher(entryAD);
            searchAD.Filter = "(SAMAccountName=" + username + ")";

            SearchResult resultAD = searchAD.FindOne();
            if (resultAD != null) return true;
            return false;
        }
    }
}
