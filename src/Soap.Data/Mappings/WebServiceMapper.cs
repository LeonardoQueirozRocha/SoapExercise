using SoapServiceReference;
using Soap.Business.Models;

namespace Soap.Data.Mappings
{
    public static class WebServiceMapper
    {
        public static Pessoa PessoaMap(Person person)
        {
            var personMap = new Pessoa();
            personMap.Nome = person.Name;
            personMap.Ssn = person.SSN;
            personMap.DataNascimento = Convert.ToDateTime(person.DOB);
            personMap.Idade = Convert.ToInt32(person.Age);
            personMap.Casa = CidadeMap(person.Home);
            personMap.Escritorio = CidadeMap(person.Office);
            personMap.CoresFavoritas = person.FavoriteColors.ToList();

            return personMap;
        }

        public static Cidade CidadeMap(Address address)
        {
            var city = new Cidade();
            city.Nome = address.City;
            city.Estado = address.State;
            city.Zip = Convert.ToInt32(address.Zip);

            return city;
        }
    }
}
