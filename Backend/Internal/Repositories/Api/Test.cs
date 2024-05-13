// using Spire.Doc;
// using Spire.Doc.Documents;
// using Spire.Doc.Fields;
// using System;
// using System.Collections.Generic;
// using System.Drawing;
//
// namespace ReplacePlaceholdersInWord
//
// {
//     class Test
//
//     {
//         static void Main(string[] args)
//
//         {
// // Создание объекта Document
//
//             Document document = new Document();
//
// // Загрузка шаблона
//
//             document.LoadFromFile("C:\\Users\\Administrator\\Desktop\\Template.docx");
//
// // Сохранение старых строк — «заполнителей» и новых строк в словаре
//
//             Dictionary replaceDict = new Dictionary();
//
//             replaceDict.Add("#name#", «Kaila Smith»);
//
//             replaceDict.Add("#address#«, «123 Michigan Street, Bloomfield, MI94141»);
//
//             replaceDict.Add("#telephone#«, «537286»);
//
//             replaceDict.Add("#mail#«, «kaila@hotmail.com»);
//
//             replaceDict.Add("#nationality#«, «United States»);
//
//             replaceDict.Add("#birth#«, «July 12th, 1992»);
//
//             replaceDict.Add("#gender#«, «Female»);
//
// //Замена строк новыми строками
//
//             foreach (KeyValuePair kvp in replaceDict)
//
//             {
//                 document.Replace(kvp.Key, kvp.Value, true, true);
//             }
//
// //Получение пути к изображению
//
//             String imagePath = «C:\\Users\\Administrator\\Desktop\\photo.jpg»;
//
// // Замена строки в шаблоне на изображение
//
//             ReplaceTextWithImage(document,  «#photograph#», imagePath);
//
// // Сохранение файла документа
//
//             document.SaveToFile("ReplacePlaceholders.docx", FileFormat.Docx);
//
//             document.Close();
//         }
//
// // Замена строки в документе Word на изображение
//
//         static void ReplaceTextWithImage(Document document, String stringToReplace, String imagePath)
//
//         {
//             TextSelection[] selections = document.FindAllString(stringToReplace, false, true);
//
//             Image image = Image.FromFile(imagePath);
//
//             int index = 0;
//
//             TextRange range = null;
//
//             foreach (TextSelection selection in selections)
//
//             {
//                 DocPicture pic = new DocPicture(document);
//
//                 pic.LoadImage(image);
//
//                 range = selection.GetAsOneRange();
//
//                 index = range.OwnerParagraph.ChildObjects.IndexOf(range);
//
//                 range.OwnerParagraph.ChildObjects.Insert(index, pic);
//
//                 range.OwnerParagraph.ChildObjects.Remove(range);
//             }
//         }
//     }
// }