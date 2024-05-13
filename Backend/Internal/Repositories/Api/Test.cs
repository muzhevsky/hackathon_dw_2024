using System.Drawing;
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;

namespace Hackaton_DW_2024.Internal.Repositories.Api

{
    class DocFileRepository {
        public void GenerateDoc(string[] args) {
            var document = new Document();
            document.LoadFromFile("C:\\Users\\Administrator\\Desktop\\Template.docx");

            var replaceDict = new Dictionary<string, string>();

            replaceDict.Add("#name#",  "Kaila Smith");
            replaceDict.Add("#address#", "123 Michigan Street, Bloomfield, MI94141");

            foreach (var kvp in replaceDict)
            {
                document.Replace(kvp.Key, kvp.Value, true, true);
            }
            
            document.SaveToFile("ReplacePlaceholders.docx", FileFormat.Docx);
            document.Close();
        }
    }
}