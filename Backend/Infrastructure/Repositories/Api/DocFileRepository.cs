using Hackaton_DW_2024.Data.Config;
using Hackaton_DW_2024.Data.DataSources.Requests;
using Hackaton_DW_2024.Data.Dto.Achievements;
using Hackaton_DW_2024.Internal.Entities;
using Hackaton_DW_2024.Internal.Entities.Users;
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;

namespace Hackaton_DW_2024.Infrastructure.Repositories.Api;

public class DocFileRepository
{
    IRequestDataSource _requestDataSource;
    readonly string _pathString;

    public DocFileRepository(IRequestDataSource requestDataSource, StaticFileConfig fileConfig)
    {
        _requestDataSource = requestDataSource;
        var combined = Path.Combine(fileConfig.StaticPath, "requests");
        Directory.CreateDirectory(combined);
        _pathString = combined+"/";
    }

    public void GenerateDoc(StudentDetails student, GroupDetails group, List<string[]> achievements)
    {
        var document = new Document();
        document.LoadFromFile("./template.docx");

        var replaceDict = new Dictionary<string, string>();

        replaceDict.Add("#name#", $"{student.User.Name}");
        replaceDict.Add("#surname#", $"{student.User.Surname}");
        replaceDict.Add("#patronymic#", $"{student.User.Patronymic}");

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

        Section s = document.AddSection();

        String[] Header =
        {
            "Наименование мероприятия",
            "Дата проведения",
            "Уровень мероприятия",
            "Личное / командное достижение",
            "Статус участия / Результат"
        };


        Table table = s.AddTable(true);
        table.ResetCells(achievements.Count + 1, Header.Length);
        TableRow FRow = table.Rows[0];
        FRow.IsHeader = true;
        FRow.Height = 23;
        for (int i = 0; i < Header.Length; i++)
        {
            Paragraph p = FRow.Cells[i].AddParagraph();
            FRow.Cells[i].CellFormat.VerticalAlignment = VerticalAlignment.Middle;
            p.Format.HorizontalAlignment = HorizontalAlignment.Center;

            TextRange TR = p.AppendText(Header[i]);
            TR.CharacterFormat.FontName = "TimesNewRoman";
            TR.CharacterFormat.FontSize = 12;
            TR.CharacterFormat.Bold = true;
        }

        for (int r = 0; r < achievements.Count; r++)
        {
            TableRow DataRow = table.Rows[r + 1];
            DataRow.Height = 20;
            for (int c = 0; c < achievements[r].Length; c++)
            {
                DataRow.Cells[c].CellFormat.VerticalAlignment = VerticalAlignment.Middle;
                Paragraph p2 = DataRow.Cells[c].AddParagraph();
                TextRange TR2 = p2.AppendText(achievements[r][c]);
                p2.Format.HorizontalAlignment = HorizontalAlignment.Center;
                TR2.CharacterFormat.FontName = "TimesNewRoman";
                TR2.CharacterFormat.FontSize = 11;
            }
        }

        document.PrivateFontList.Add(new PrivateFontPath("TimesNewRoman", "/usr/share/fonts/times.ttf"));
        var dto = new RequestDto
        {
            Confirmed = false,
            UserId = student.User.Id
        };
        _requestDataSource.Insert(dto);
        var fileName = dto.Id + ".docx";
        _requestDataSource.UpdateById(dto.Id, requestDto => requestDto.FilePath = fileName);

        document.SaveToFile(Path.Combine(_pathString, fileName), FileFormat.Docx);
        document.Close();
    }
}