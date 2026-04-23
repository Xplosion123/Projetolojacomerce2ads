using LojaEcomerce.Models;

namespace LojaEcomerce.Interfaces
{
    public interface Iusuariorepositorio
    {
        //a interface não contem código apenas a promessa do que deve
        //ser feito
        LoginViewModel Validar(string Email, string Senha);

    }
}
