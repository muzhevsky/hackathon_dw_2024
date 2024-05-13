using Newtonsoft.Json;

namespace Hackaton_DW_2024.Internal.Repositories.Api;

public class RecognizeTextApiRepository
{
    HttpClient _httpClient;

    public RecognizeTextApiRepository()
    {
        _httpClient = new HttpClient();
        _httpClient.Timeout = new TimeSpan(0, 1, 0);
    }

    public async Task<string> Test(string imagePath)
    {
        string result = "";
        try
        {
            var form = new MultipartFormDataContent();
            form.Add(new StringContent("helloworld"), "apikey"); //Added api key in form data
            form.Add(new StringContent("eng"), "language");

            form.Add(new StringContent("2"), "ocrengine");
            form.Add(new StringContent("true"), "scale");
            form.Add(new StringContent("true"), "istable");

            if (string.IsNullOrEmpty(imagePath) == false)
            {
                var imageData = File.ReadAllBytes(imagePath);
                form.Add(new ByteArrayContent(imageData, 0, imageData.Length), "image", "image.jpg");
            }
            // else if (string.IsNullOrEmpty(PdfPath) == false)
            // {
            //     byte[] imageData = File.ReadAllBytes(PdfPath);
            //     form.Add(new ByteArrayContent(imageData, 0, imageData.Length), "PDF", "pdf.pdf");
            // }

            var response = await _httpClient.PostAsync("https://api.ocr.space/Parse/Image", form);

            var strContent = await response.Content.ReadAsStringAsync();

            var ocrResult = JsonConvert.DeserializeObject<Rootobject>(strContent);


            if (ocrResult.OcrExitCode == 1)
            {
                for (int i = 0; i < ocrResult.ParsedResults.Count(); i++)
                {
                    result += ocrResult.ParsedResults[i].ParsedText;
                }
            }
            else
            {
                Console.WriteLine("ERROR: " + strContent);
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
        }

        return result;
    }

    public class Rootobject
    {
        public Parsedresult[] ParsedResults { get; set; }
        public int OcrExitCode { get; set; }
        public bool IsErroredOnProcessing { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorDetails { get; set; }
    }

    public class Parsedresult
    {
        public object FileParseExitCode { get; set; }
        public string ParsedText { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorDetails { get; set; }
    }
}