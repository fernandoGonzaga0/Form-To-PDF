using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Essa classe representa a configuração de Model na estrutura MVVM. Ela estabelece os dados reais que serão manipulados/exportados. 

Quando obtermos os dados pelo ViewModel, faremos uma instanciação da classe recebendo os dados e alocando como objeto de PersonInfo (linha 105 em PersonFormViewModel.cs).

Criei 5 componentes e 1 construtor para facilitar a instanciação da classe.
*/

namespace FormPDF.Model
{
    public class PersonInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public PersonInfo(string firstName, string lastName, string address, string email, string phone)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Email = email;
            Phone = phone;
        }
    }
}