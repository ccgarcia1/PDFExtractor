using Newtonsoft.Json;
    
namespace PDFExtractor
{
    public class CategoriaDocumentoResponse
    {
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        
        [JsonProperty("manager_id")]
        public string ManagerId { get; set; }
       
        [JsonProperty("salary")]
        public string Salary { get; set; }
    }
}
