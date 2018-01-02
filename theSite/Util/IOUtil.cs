using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace theSite.Util
{
    internal class IOUtil
    {
        internal static IList<string> GetImagesToShowOnHome(string obsolutePath)
        {
            IList < string > imgNameList = new List<string>();

            foreach (var file in Directory.GetFiles(obsolutePath))
            {
                imgNameList.Add(string.Format(System.Globalization.CultureInfo.CurrentCulture, @"{0}\{1}", Constants.imgPath, Path.GetFileName(file)));
            }

            return imgNameList;
        }
    }
}