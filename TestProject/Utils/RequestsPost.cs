using Nancy.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestProject.Constants;
using TestProject.Entities;

namespace TestProject.Utils
{
     public class RequestsPost
    {
        public static HttpWebResponse GetPost()
        {
            string url = PostEndPoints.URL_BASE + PostEndPoints.GET_POSTS;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "GET";
            return (HttpWebResponse)httpWebRequest.GetResponse();
        }

        public static HttpWebResponse GetPostId(string id)
        {
            string url = PostEndPoints.URL_BASE + PostEndPoints.GET_POST + id;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "GET";
            return (HttpWebResponse)httpWebRequest.GetResponse();
        }

        public static HttpWebResponse PutPost(ResponsePost post)
        {
            string url = PostEndPoints.URL_BASE + PostEndPoints.PUT_POST + post.id.ToString();
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Accept = "application/json";
            httpWebRequest.Method = "PUT";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = new JavaScriptSerializer().Serialize(post);
                streamWriter.Write(json);
            }

            return (HttpWebResponse)httpWebRequest.GetResponse();
        }
        public static HttpWebResponse PostPost(ResponsePost post)
        {
            string url = PostEndPoints.URL_BASE + PostEndPoints.POST_POSTS;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Accept = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = new JavaScriptSerializer().Serialize(post);
                streamWriter.Write(json);
            }

            return (HttpWebResponse)httpWebRequest.GetResponse();
        }

        public static HttpWebResponse DeletePost(string id)
        {
            string url = PostEndPoints.URL_BASE + PostEndPoints.DELETE_POST + id;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "DELETE";
            return (HttpWebResponse)httpWebRequest.GetResponse();
        }
    }
}
