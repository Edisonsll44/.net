using Amazon.S3.Model;
using Soulsplit.Api.Contratos;
using Soulsplit.Api.Utilitarios.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Soulsplit.Api.Aplicaciones.Servicios
{
    public class AwsS3Service : IAwsS3Service
    {
        private readonly IAwsS3Helper _awsS3Helper;

        public AwsS3Service(IAwsS3Helper awsS3Helper)
        {
            _awsS3Helper = awsS3Helper;
        }

        public async Task<string> CargarArchivo(string imagenBase64, string nombreArchivo, string bucketName)
        {
            try
            {
                return await _awsS3Helper.CargarArchivo(imagenBase64, nombreArchivo, bucketName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GetObjectResponse> ObtenerArchivo(string key, string bucketName)
        {
            try
            {
                GetObjectResponse fileStream = await _awsS3Helper.ObtenerArchivo(key, bucketName);
                if (fileStream == null)
                {
                    Exception ex = new Exception("File Not Found");
                    throw ex;
                }
                else
                {
                    return fileStream;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DeleteObjectResponse> EliminarArchivo(string key, string bucketName)
        {
            try
            {
                return await _awsS3Helper.EliminarArchivo(key, bucketName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}