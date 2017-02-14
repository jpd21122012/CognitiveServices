using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CognitiveServicesMicrosoft
{
    class Program
    {
        static void Main(string[] args)
        {
            ComputerVisionDescription vision = new ComputerVisionDescription();
            //vision.ImageDescription();
            vision.TextRecognition();
            //vision.FaceDetection();
        }
    }
}
