using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOnline.Core.ExtenstionMethods
{
    public static class PathTools
    {
        public static string PathImageAdmin = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImgUser/");
        public static string PathImageClient = "/ImgUser/";

        public static string PathImagePrAdmin = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImgPortfolio/");
        public static string PathImagePrClient = "/ImgPortfolio/";
    }
}
