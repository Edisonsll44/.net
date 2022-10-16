using Amazon.S3;
using Amazon.S3.Model;
using Soulsplit.Api.Contratos;
using System;
using System.IO;
using System.Threading.Tasks;
using Amazon.Runtime;
using Amazon.S3.Transfer;

namespace Soulsplit.Api.Aplicaciones.Servicios
{
    public class AwsS3Helper : IAwsS3Helper
    {
        private readonly IAppConfig _appConfig;
        private readonly IAmazonS3 _amazonS3;

        public AwsS3Helper(IAppConfig appConfig
            , IAmazonS3 amazonS3
            )
        {
            _appConfig = appConfig;
            _amazonS3 = amazonS3;
        }
      
        public async Task<string> CargarArchivo(string base64String, string nombreArchivo, string bucketName)
        {
            var credentials = new BasicAWSCredentials(_appConfig.AccessKeyAWS, _appConfig.SecretKeyAWS);
            var config = new AmazonS3Config
            {
                RegionEndpoint = Amazon.RegionEndpoint.USWest1
            };
            try
            {
                byte[] bytes = Convert.FromBase64String(base64String);
                using var client = new AmazonS3Client(credentials, config);
                var uploadRequest = new TransferUtilityUploadRequest
                {
                    InputStream = new MemoryStream(bytes),
                    Key = nombreArchivo,
                    BucketName = bucketName,
                    CannedACL = S3CannedACL.PublicRead,
                };
                var fileTransferUtility = new TransferUtility(client);
                await fileTransferUtility.UploadAsync(uploadRequest);
                return GenerateUrlAws(bucketName, nombreArchivo, _appConfig.RegionAWSS3);
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                if (amazonS3Exception.ErrorCode != null
                    && (amazonS3Exception.ErrorCode.Equals("InvalidAccessKeyId") ||
                        amazonS3Exception.ErrorCode.Equals("InvalidSecurity")))
                {
                    throw new Exception("Check the provided AWS Credentials.");
                }
                else
                {
                    throw new Exception("Error occurred: " + amazonS3Exception.Message);
                }
            }
        }

        public async Task<GetObjectResponse> ObtenerArchivo(string nombreArchivo, string bucketName)
        {
            var credentials = new BasicAWSCredentials(_appConfig.AccessKeyAWS, _appConfig.SecretKeyAWS);
            var config = new AmazonS3Config
            {
                RegionEndpoint = Amazon.RegionEndpoint.USWest1
            };
            try
            {
                using var client = new AmazonS3Client(credentials, config);
                var fileTransferUtility = new TransferUtility(client);
                return await fileTransferUtility.S3Client.GetObjectAsync(new GetObjectRequest()
                {
                    BucketName = bucketName,
                    Key = nombreArchivo
                });
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                if (amazonS3Exception.ErrorCode != null
                    && (amazonS3Exception.ErrorCode.Equals("InvalidAccessKeyId") || amazonS3Exception.ErrorCode.Equals("InvalidSecurity")))
                {
                    throw new Exception("Check the provided AWS Credentials.");
                }
                else
                {
                    throw new Exception("Error occurred: " + amazonS3Exception.Message);
                }
            }
        }
        public async Task<DeleteObjectResponse> EliminarArchivo(string key, string bucketName)
        {
            var credentials = new BasicAWSCredentials(_appConfig.AccessKeyAWS, _appConfig.SecretKeyAWS);
            var config = new AmazonS3Config
            {
                RegionEndpoint = Amazon.RegionEndpoint.USWest1
            };
            try
            {

                using var client = new AmazonS3Client(credentials, config);
                var fileTransferUtility = new TransferUtility(client);
                return await fileTransferUtility.S3Client.DeleteObjectAsync(new DeleteObjectRequest()
                {
                    BucketName = bucketName,
                    Key = key
                });

            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                if (amazonS3Exception.ErrorCode != null
                    && (amazonS3Exception.ErrorCode.Equals("InvalidAccessKeyId") || amazonS3Exception.ErrorCode.Equals("InvalidSecurity")))
                {
                    throw new Exception("Check the provided AWS Credentials.");
                }
                else
                {
                    throw new Exception("Error occurred: " + amazonS3Exception.Message);
                }
            }
        }


        string GenerateUrlAws(string bucketName, string key, string region)
        {
            return $"https://{bucketName}.s3-{region}.{_appConfig.AwsBaseUrl}/{key}";
        }
    }
}