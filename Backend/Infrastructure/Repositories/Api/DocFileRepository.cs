using Hackaton_DW_2024.Internal.Entities;
using Hackaton_DW_2024.Internal.Entities.Users;
using Spire.Doc;

namespace Hackaton_DW_2024.Infrastructure.Repositories.Api;

public class DocFileRepository {
    public void GenerateDoc(StudentDetails student, GroupDetails group) {
        var document = new Document();
        document.LoadFromFile("./template.docx");

        var replaceDict = new Dictionary<string, string>();

        replaceDict.Add("#name#",  $"{student.User.Name}");
        replaceDict.Add("#surname#",  $"{student.User.Surname}");
        replaceDict.Add("#patronymic#",  $"{student.User.Patronymic}");
        
        replaceDict.Add("#speciality_full#", $"{group.Speciality.FullTitle}");
        replaceDict.Add("#speciality#", $"{group.Speciality.Title}");
        replaceDict.Add("#institute#", $"{group.Institute.Title}");
        replaceDict.Add("#course#", $"{group.Course}");
        replaceDict.Add("#group#", $"{group.Group.Title}");
        
        replaceDict.Add("#phone_number#", $"{student.Student.PhoneNumber}");

        foreach (var kvp in replaceDict)
        {
            document.Replace(kvp.Key, kvp.Value, true, true);
        }
        
        // var s = document.AddSection();
        // var Header = new[]{"Date", "Description", "Country", "On Hands", "On Order"};
        //
        //
        // var table = s.AddTable(true);
        // // table.ResetCells(data.Length + 1, Header.Length);
        // var FRow = table.Rows[0];
        // FRow.IsHeader = true;
        // FRow.Height = 23;
        // FRow.RowFormat.BackColor = Color.LightSeaGreen;
        // for (int i = 0; i < Header.Length; i++)
        // {
        //     var p = FRow.Cells[i].AddParagraph();
        //     FRow.Cells[i].CellFormat.VerticalAlignment = VerticalAlignment.Middle;
        //     p.Format.HorizontalAlignment = HorizontalAlignment.Center;
        //     var TR = p.AppendText(Header[i]);
        //     TR.CharacterFormat.FontName = "Calibri";
        //     TR.CharacterFormat.FontSize = 12;
        //     TR.CharacterFormat.Bold = true;
        // }
        // for (int r = 0; r < data.Length; r++)
        // {
        //     var DataRow = table.Rows[r + 1];
        //     DataRow.Height = 20;
        //     for (int c = 0; c < data[r].Length; c++)
        //     {
        //         DataRow.Cells[c].CellFormat.VerticalAlignment = VerticalAlignment.Middle;
        //         var p2 = DataRow.Cells[c].AddParagraph();
        //         var TR2 = p2.AppendText(data[r][c]);
        //         p2.Format.HorizontalAlignment = HorizontalAlignment.Center;
        //         TR2.CharacterFormat.FontName = "Calibri";
        //         TR2.CharacterFormat.FontSize = 11;
        //     }
        // }

        
        document.SaveToFile("./Requests/ReplacePlaceholders.docx", FileFormat.Docx);
        document.Close();
    }
}