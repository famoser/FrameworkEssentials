using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Famoser.FrameworkEssentials.Models;
using Famoser.FrameworkEssentials.Models.RestService;

namespace Famoser.FrameworkEssentials.Services.Interfaces
{
    /// <summary>
    /// use this class to talk to a rest service
    /// </summary>
    public interface IRestService
    {
        /// <summary>
        /// Get the specified resource
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        Task<HttpResponseModel> GetAsync(Uri uri);
        /// <summary>
        /// execute a put request to the specified uri with any postContent and files
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="postContent"></param>
        /// <param name="files"></param>
        /// <returns></returns>
        Task<HttpResponseModel> PutAsync(Uri uri, IEnumerable<KeyValuePair<string, string>> postContent, IEnumerable<RestFile> files = null);
        /// <summary>
        /// put the json to the server. 
        /// if using php the content is available server side in the //input stream
        /// if you send files too, be aware that the json content is now send with the "json" key. In php, you may use $_POST["json"] to access your json
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="json"></param>
        /// <param name="files"></param>
        /// <returns></returns>
        Task<HttpResponseModel> PutJsonAsync(Uri uri, string json, IEnumerable<RestFile> files = null);
        /// <summary>
        /// execute a post request to the specified uri with any postContent and files
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="postContent"></param>
        /// <param name="files"></param>
        /// <returns></returns>
        Task<HttpResponseModel> PostAsync(Uri uri, IEnumerable<KeyValuePair<string, string>> postContent, IEnumerable<RestFile> files = null);
        /// <summary>
        /// post the json to the server. if using php the content is available server side in the //input stream
        /// if you send files too, be aware that the json content is now send with the "json" key. In php, you may use $_POST["json"] to access your json
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="json"></param>
        /// <param name="files"></param>
        /// <returns></returns>
        Task<HttpResponseModel> PostJsonAsync(Uri uri, string json, IEnumerable<RestFile> files = null);
        /// <summary>
        /// execute a delete request to the specified uri
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        Task<HttpResponseModel> DeleteAsync(Uri uri);
    }
}
