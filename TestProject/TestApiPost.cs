using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestProject.Constants;
using TestProject.Entities;
using TestProject.Utils;

namespace TestProject
{
    [TestClass]
    public class TestApiPost
    {
        [TestMethod]
        public void GetMethod()
        {
            string html;
            HttpWebResponse response = RequestsPost.GetPost();

            Stream stream = response.GetResponseStream();

            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
                var apiResponse = JsonConvert.DeserializeObject<List<ResponsePost>>(html);

                Assert.AreEqual("OK", response.StatusCode.ToString());
                Assert.AreNotEqual(0, apiResponse.Count());
            }
        }

        [TestMethod]
        public void GetIdMethod()
        {
            string html;
            HttpWebResponse response = RequestsPost.GetPostId("1");
            Stream stream = response.GetResponseStream();

            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
                var apiResponse = JsonConvert.DeserializeObject<ResponsePost>(html);
                
                Assert.AreEqual("OK", response.StatusCode.ToString());
                Assert.IsNotNull(apiResponse);
                Assert.AreEqual(1, apiResponse.id);
                Assert.AreEqual(1, apiResponse.userId);
                Assert.AreEqual("sunt aut facere repellat provident occaecati excepturi optio reprehenderit", apiResponse.title);
                Assert.AreEqual("quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto", apiResponse.body);
            }
        }

        [TestMethod]
        public void PutMethod()
        {
            ResponsePost post = new ResponsePost()
            {
                title = "Youtuber",
                body = "Muestra el codigo del youtuber",
                id = 1,
                userId = 20
            };
            string html;
            HttpWebResponse response = RequestsPost.PutPost(post);
            Stream stream = response.GetResponseStream();

            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
                var apiResponse = JsonConvert.DeserializeObject<ResponsePost>(html);

                Assert.AreEqual("OK", response.StatusCode.ToString());
                Assert.AreEqual(1, apiResponse.id);
                Assert.AreEqual(20, apiResponse.userId);
                Assert.AreEqual("Youtuber", apiResponse.title);
                Assert.AreEqual("Muestra el codigo del youtuber", apiResponse.body);
            }
        }

        [TestMethod]
        public void PostMethod()
        {
            ResponsePost post = new ResponsePost()
            {
                userId = 10,
                title = "Guido Buena Vista",
                body = "First Friend"
            };
            string html;
            HttpWebResponse response = RequestsPost.PostPost(post);
            Stream stream = response.GetResponseStream();

            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
                var apiResponse = JsonConvert.DeserializeObject<ResponsePost>(html);

                Assert.AreEqual("Created", response.StatusCode.ToString());
                Assert.AreNotEqual(0, apiResponse.id);
                Assert.AreEqual(10, apiResponse.userId);
                Assert.AreEqual("Guido Buena Vista", apiResponse.title);
                Assert.AreEqual("First Friend", apiResponse.body);

            }
        }

        [TestMethod]
        public void DeleteMethod()
        {
            string html;
            HttpWebResponse response = RequestsPost.DeletePost("200");
            Stream stream = response.GetResponseStream();

            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();

                Assert.AreEqual("OK", response.StatusCode.ToString());
            }
        }
    }
}
