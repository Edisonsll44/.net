using Amazon.S3.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Soulsplit.Api.Contratos
{
    public interface IAwsS3Service
    {
        Task<string> CargarArchivo(string imagenBase64, string nombreArchivo, string bucketName);
        Task<GetObjectResponse> ObtenerArchivo(string key, string bucketName);
        Task<DeleteObjectResponse> EliminarArchivo(string key, string bucketName);
    }
}
