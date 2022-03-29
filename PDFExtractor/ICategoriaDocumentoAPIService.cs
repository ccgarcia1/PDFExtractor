using Refit;    
using System.Threading.Tasks;

namespace PDFExtractor
{
    public interface ICategoriaDocumentoAPIService
    { 
        [Get("/employees")]
        Task<CategoriaDocumentoResponse> GetCategoriaDocumentoAsync();
    }
}
