using Amazon.S3.Model;
using System.Threading.Tasks;

namespace Soulsplit.Api.Contratos
{
    public interface IAwsS3Helper
    {
        Task<string> CargarArchivo(string base64String, string fileName, string bucketName);
        Task<GetObjectResponse> ObtenerArchivo(string key, string bucketName);
        Task<DeleteObjectResponse> EliminarArchivo(string key, string bucketName);
    }
}
