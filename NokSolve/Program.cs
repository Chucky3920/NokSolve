using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using NokSolve.Utils;

namespace NokSolve;

public class Program
{
    private static async Task Main(string[] args)
    {
        var authToken = Environment.GetEnvironmentVariable("AUTH_TOKEN");
        var courseId = Environment.GetEnvironmentVariable("COURSE_ID");
        
        
        if (string.IsNullOrWhiteSpace(authToken))
        {
            Logger.Error("No AUTH_TOKEN environment variable");
            return;
        }

        if (string.IsNullOrWhiteSpace(courseId))
        {
            Logger.Error("No COURSE_ID environment variable");
            return;
        }
        
        using var client = new HttpClient();
        
        var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.matematik.nokportalen.se/api/v2/content/{courseId}?courseId={courseId}");
        request.Headers.Add("Authorization", $"Bearer {authToken}");
        
        var exercisesResponseMessage = await client.SendAsync(request);

        var exercises = await exercisesResponseMessage.Content.ReadFromJsonAsync<Root>();
        
        foreach (var chapter in exercises.Content.Chapters)
        {
            //Loops through every assignment using unreadable LINQ
            foreach (Part part in chapter.Parts)
            foreach (SubPart subPart in part.SubParts)
            foreach (Section section in subPart.Sections)
            foreach (SectionAssignmentRelation assignment in section.SectionAssignmentRelations)
            {
                request = new HttpRequestMessage(HttpMethod.Get, $"https://api.matematik.nokportalen.se/api/v2/user/solution/upload-form?assignmentId={assignment.AssignmentId}&courseId={courseId}");
                request.Headers.Add("Authorization", $"Bearer {authToken}");
                var responseMessage = await client.SendAsync(request);

                var awsResponse = await responseMessage.Content.ReadFromJsonAsync<AwsUploadRequest>();

                request = new HttpRequestMessage(HttpMethod.Get, awsResponse.Attributes.Action);
                request.Method = HttpMethod.Post;

                var formData = new MultipartFormDataContent("----WebKitFormBoundaryUmBDrcABwpQXIG7P");

                foreach (var param in awsResponse.Inputs)
                {
                    formData.Add(new StringContent(param.Value), param.Key);
                }

                var dummyFilePath = Path.Combine(Path.GetTempPath(), "dummyfile.txt");
                await File.WriteAllTextAsync(dummyFilePath, "Ge Mig Mina Poäng!");

                var dummyFileBytes = await File.ReadAllBytesAsync(dummyFilePath);
                var dummyFileContent = new ByteArrayContent(dummyFileBytes);
                dummyFileContent.Headers.ContentType = new MediaTypeHeaderValue("text/plain"); // Assuming it’s a text file
                formData.Add(dummyFileContent, "file", "dummyfile.txt");

                request.Content = formData;

                responseMessage = await client.SendAsync(request);


                if (responseMessage.Headers.TryGetValues("Location", out var location))
                {
                    request = new HttpRequestMessage(HttpMethod.Post, $"https://api.matematik.nokportalen.se/api/v2/user/solution?courseId={courseId}");
                    request.Headers.Add("Authorization", $"Bearer {authToken}");
                    var loc = location.First();
                    var index = loc.IndexOf("user-solutions", StringComparison.Ordinal);
                    var body = new
                    {
                        assignmentId = assignment.AssignmentId,
                        type = "text",
                        sectionId = section.Id,
                        filePath = loc.Substring(index)
                    };

                    request.Content = JsonContent.Create(body);

                    responseMessage = await client.SendAsync(request);

                    Logger.Info($"{responseMessage.StatusCode} - {await responseMessage.Content.ReadAsStringAsync()}");
                    var response = await responseMessage.Content.ReadFromJsonAsync<SendSolution>();
                    Logger.Info($"Points Given: {response.PointsGiven}");
                }
            }
        }
    }

    public class AwsUploadRequest
    {
        public Attributes Attributes { get; set; }
        public Dictionary<string, string> Inputs { get; set; }
    }

    public class Attributes
    {
        public string Action { get; set; }
        public string Method { get; set; }
        public string Enctype { get; set; }
    }

    public class SendSolution
    {
        [JsonPropertyName("success")]
        public string Success { get; set; }

        [JsonPropertyName("pointsGiven")]
        public int PointsGiven { get; set; }
    }
}