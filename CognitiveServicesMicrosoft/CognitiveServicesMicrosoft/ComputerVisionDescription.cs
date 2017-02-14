using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Web;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;

namespace CognitiveServicesMicrosoft
{
    class ComputerVisionDescription
    {
        public void ImageDescription() {
            var client = new RestClient("https://api.projectoxford.ai/vision/v1.0/analyze?visualFeatures=Categories,Faces,Color,Tags,Adult,Description,ImageType");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("ocp-apim-subscription-key", "5479a6d843bb488bb5a3e0b3b7642d04");
            request.AddParameter("application/json", "{\"url\":\"http://culturacolectiva.com/wp-content/uploads/2014/12/Los-10-habitos-matutinos-de-las-personas-mas-exitosas-.jpg\"}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }
        public void TextRecognition()
        {
            var client = new RestClient("https://api.projectoxford.ai/vision/v1.0/ocr?language=es");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("ocp-apim-subscription-key", "5479a6d843bb488bb5a3e0b3b7642d04");
            request.AddParameter("application/json", "{\"url\":\"http://fraseparawhatsapp.com/wp-content/uploads/2016/06/im%C3%A1genes-con-frases-divertidas-de-amor.jpg\"}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }
        public void FaceDetection() {
            var client = new RestClient("https://api.projectoxford.ai/face/v1.0/detect?returnFaceId=true&returnFaceLandmarks=true&returnFaceAttributes");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("ocp-apim-subscription-key", "5fc4f455ea874e91ab731db2b97120e1");
            request.AddParameter("application/json", "{\"url\":\"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR6UMZdJTtbTBOd9L_PaUE-x3eLmlW6uLcBYwUa4CFyZ4ZEu6_4pA\"}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }

        public static byte[] Convertir_Imagen_Bytes(Image img)
        {
            string sTemp = Path.GetTempFileName();
            FileStream fs = new FileStream(sTemp, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            img.Save(fs,ImageFormat.Png);
            fs.Position = 0;
            int imgLength = Convert.ToInt32(fs.Length);
            byte[] bytes = new byte[imgLength];
            fs.Read(bytes, 0, imgLength);
            fs.Close();
            return bytes;
        }
    }
}
