//using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseManagement.Shared.ValueObjects;

namespace ExpenseManagement.Shared.Interfaces.Services
{
    /// <summary>
    /// Serviço responsável por fazer a manipulação de arquivos. IMPORTANTE: Utilize o método "SetUploadFolder" antes de qualquer ação
    /// </summary>
    public interface IUploadFileService
    {
        /// <summary>
        /// Configura a pasta de upload onde será manipulado o arquivo
        /// </summary>
        /// <param name="path">caminho da pasta</param>
        //public void SetUploadFolder(string path = null);
        //public BusinessResult<FileResult> Add(IFormFile file);
        //public BusinessResult<List<FileResult>> Add(IEnumerable<IFormFile> files);
        //public BusinessResult<List<FileResult>> GetFiles(string pathCustom = null);
        //public BusinessResult<bool> Remove(string fileName);
        //public BusinessResult<bool> Remove(IEnumerable<string> fileNames);
    }
}
