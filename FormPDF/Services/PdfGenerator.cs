using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using FormPDF.ViewModel;

/*
Esse arquivo tem como objetivo criar o container de PDF do projeto, utilizando os dados capturados do WPF para exibição. 
Todo o molde do PDF será configurado aqui.
*/

namespace FormPDF.Services;

public class PdfGenerator
{
    public void Generate(string filePath, PersonFormViewModel personInfoToPDF)
    {
        Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(2, Unit.Centimetre);
                page.PageColor(Colors.White);

                // título com tamanho 20 e negrito
                page.Header().Text("FORM TO PDF").FontSize(36).SemiBold().FontColor(Colors.Blue.Medium).AlignCenter();

                // conteúdo
                page.Content().PaddingVertical(1, Unit.Centimetre).Column(col =>
                {
                    col.Spacing(20);
                    col.Item().Text($"Name: {personInfoToPDF.FirstName} {personInfoToPDF.LastName}").FontSize(20);
                    col.Item().Text($"Address: {personInfoToPDF.Address}").FontSize(20);
                    col.Item().Text($"Email: {personInfoToPDF.Email}").FontSize(20);
                    col.Item().Text($"Phone: {personInfoToPDF.Phone}").FontSize(20);
                });

                page.Footer().Text($"Page 1").AlignCenter();

            });
        }).GeneratePdf(filePath); // gerando o arquivo

    }
}