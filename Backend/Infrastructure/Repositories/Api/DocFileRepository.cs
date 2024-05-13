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
            
        document.SaveToFile("./Requests/ReplacePlaceholders.docx", FileFormat.Docx);
        document.Close();
    }
}