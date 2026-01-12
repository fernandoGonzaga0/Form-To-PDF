using System;
using System.ComponentModel; // interface que permite notificar a view quando algo muda no WPF
using System.Runtime.CompilerServices; // permite usar o atributo CallerMemberName
using System.Windows;
using System.Windows.Input;
using FormPDF.Model;

/*

Reforçando: o ViewModel não reconhece TextBox, Button ou XML, ele apenas recebe os dados, mantém o estado da tela e cria instância de Model.

Por esse arquivo, vincularemos os dados recebidos em um novo objeto de PersonInfo, setado em Model. Basicamente, pegamos o modelo (Model) 
 
*/

namespace FormPDF.ViewModel
{
    public class PersonFormViewModel : INotifyPropertyChanged
    {
        // campos privados que realmente armazenam o valor digitado (diferente do campo base, setado em Model). Ele não é acessado diretamente pela View.
        private string _firstName = string.Empty;
        private string _lastName = string.Empty;
        private string _address = string.Empty;
        private string _email = string.Empty;
        private string _phone = string.Empty;

        // propriedade pública usada pelo Binding no XAML, o TextBox se conecta aqui
        public string FirstName
        {
            // retorna o valor atual armazenado no campo privado
            get => _firstName;

            // esse set é chamado automaticamente pelo WPF sempre que o usuário digita algo no TextBox
            set
            {
                // evita disparar notificações desnecessárias, só atualiza se o valor realmente mudou
                if (_firstName != value)
                {
                    // atualiza o valor interno
                    _firstName = value;

                    // notifica o WPF que a propriedade mudou, mantendo a View sincronizada com o ViewModel
                    OnPropertyChanged();
                }
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Address
        {
            get => _address;
            set
            {
                if (_address != value)
                {
                    _address = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Phone
        {
            get => _phone; 
            set
            {
                if (_phone != value)
                {
                    _phone = value;
                    OnPropertyChanged();
                }
            }
        }

        // evento exigido pela interface INotifyPropertyChanged, a View 'escuta' esse evento para saber quando atualizar
        public event PropertyChangedEventHandler? PropertyChanged;

        // método auxiliar que dispara o evento PropertyChanged, o atributo CallMemberName envia automaticamente o nome da propriedade que chamou este método
        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            // dispara o evento informando qual propriedade mudou
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // aqui estou criando um método ToPersonInfo para retornar sempre os dados atualizados partindo da inserção pelo usuário
        public PersonInfo ToPersonInfo()
        {
            return new PersonInfo(FirstName, LastName, Address, Email, Phone);
        }

        public RelayCommand ExportCommand { get; }

        public PersonFormViewModel()
        {
            ExportCommand = new RelayCommand(() =>
            {
                // mostrando os dados em um MessageBox
                string message = $"Confirm the fields before export:\n\n" +
                                 $"Name: {FirstName}\n" +
                                 $"Last Name: {LastName}\n" +
                                 $"Address: {Address}\n" +
                                 $"Email: {Email}\n" +
                                 $"Phone: {Phone}";

                MessageBox.Show(message, "Confirm?");
            });
        }
    }
}