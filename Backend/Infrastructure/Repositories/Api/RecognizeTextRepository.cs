using Newtonsoft.Json;

namespace Hackaton_DW_2024.Infrastructure.Repositories.Api;

public class RecognizeTextApiRepository
{
    HttpClient _httpClient;
    OcrConfiguration _config;
    public RecognizeTextApiRepository(OcrConfiguration config)
    {
        _config = config;
        _httpClient = new HttpClient();
        _httpClient.Timeout = new TimeSpan(0, 0, 60);
    }

    public async Task<string> Recognize(string imagePath)
    {
        string result = "";
        try
        {
            var form = new MultipartFormDataContent();
            form.Add(new StringContent("eng"), "language");
            form.Add(new StringContent(_config.ApiKey), "apikey");
            form.Add(new StringContent(_config.Engine.ToString()), "ocrengine");
            form.Add(new StringContent(_config.Scale.ToString()), "scale");

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

            var response = await _httpClient.PostAsync(_config.Url, form);

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