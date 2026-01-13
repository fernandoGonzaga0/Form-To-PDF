# FormToPDF - Projeto WPF para exportação em PDF

[![.NET](https://img.shields.io/badge/.NET-9.0-512BD4?style=flat&logo=dotnet)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-12.0-239120?style=flat&logo=csharp)](https://learn.microsoft.com/dotnet/csharp/)
[![WPF](https://img.shields.io/badge/WPF-Windows_Desktop-0078D4?style=flat&logo=windows)](https://learn.microsoft.com/dotnet/desktop/wpf/)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)

#### Aplicação WPF usando C# que recebe dados inseridos pelo usuário no formulário e exporta para PDF, com uso da biblioteca QuestPDF.

<img src="FormPDF/Resources/Print_App.PNG" width="500"/>

## Objetivo do projeto

<p>Obter dados do usuário para exportação direta em PDF utilizando a biblioteca QuestPDF. O programa possui também um botão Preview, permitindo a visualização clara de que os dados estão atualizados para exportação.</p>

## Tecnologias utilizadas

  - Visual Studio
  - .NET 9.0
  - C# 12.0
  - WPF
  - MVVM (padrão de projeto)
  - QuestPDF (biblioteca de criação de PDFs)
  - INotifyPropertyChanged (tecnologia utilizada que permite a comunicação síncrona entre View e ViewModel, onde o que é inserido no TextBox na aplicação sempre é atrelhado ao valor em si reservado para o dado)
  - ICommand (ICommand permite a associação de ação ao botão para exibir os dados atualizados no Preview)

## Principais funcionalidades

### Botão de Preview

<p>Após inserir os dados, o usuário pode clicar no botão para visualizar os dados que serão utilizados na exportação e criação do PDF. Serve como um 'ponteiro' de que tudo que é inserido no momento é levado de fato ao documento.</p>

<img src="FormPDF/Resources/Print_Preview.PNG" width="500">

### Botão Convert to PDF

<p>Clicando no botão Convert to PDF, a aplicação realiza uma chamada do método Generate, localizado em Services/PdfGenerator.cs. Essa chamada inicializa o modelo de PDF criado com a importação da biblioteca QuestPDF, configurado para receber os dados inseridos pelo usuário e captado pelo INotifyPropertyChanged. A aplicação está configurada para habilitar uma alocação personalizada do arquivo onde o usuário melhor entender:</p>

<img src="FormPDF/Resources/Print_FilePath.PNG" width="500">

<p>Após a inserção do local, a aplicação retorna com uma mensagem de confirmação de exportação dos dados e abre o PDF automaticamente:</p>

<img src="FormPDF/Resources/Print_PDFExportSuccessfully.PNG" width="500">

<p>PDF aberto no Google Chrome:</p>

<img src="FormPDF/Resources/Print_PDF.jpg" width="500">

## Licença

<p>Distribuído sob licença MIT.</p>   

## Autor

<p>Desenvolvido por Fernando Gonzaga:</p>

  - Linkedln: https://www.linkedin.com/in/fernando-gonzaga21/
  - GitHub: https://github.com/fernandoGonzaga0
