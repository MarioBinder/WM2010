using System.Linq;
using System.IO;
using WM2010Management;
using System.Collections.Generic;

namespace WM2010.Common
{
    /// <summary>
    /// HelperKlasse fuer gemeinsam verwendbare Methoden
    /// </summary>
    public class Helper
    {

        /// <summary>
        /// prueft einen string auf alphanumerik
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNumeric(string str)
        {
            var pattern = new System.Text.RegularExpressions.Regex(@"^[0-9]+$");
            return pattern.IsMatch(str.Trim());
        }

        /// <summary>
        /// Gibt den Stream in einem byte[] eines Bildes zurueck
        /// TODO den relativen Speicherort inkl. Extension als Parameter erwarten
        /// </summary>
        /// <param name="picname"></param>
        /// <returns></returns>
        public byte[] GetPicture(string picname)
        {
            var pic = picname + ".jpg";
            byte[] picData = null;
            FileInfo fileInfo = new FileInfo(pic);
            long length = fileInfo.Length;
            var fileStream = new FileStream(pic, FileMode.Open, FileAccess.Read);
            var br = new BinaryReader(fileStream);
            picData = br.ReadBytes((int)length);
            return picData;
        }

        /// <summary>
        /// Schreibt das BIld aus der DB als Tempfile und gibt die URL zurueck
        /// </summary>
        /// <param name="imageData"></param>
        /// <returns></returns>
        public static string GetImagePath(byte[] imageData)
        {
            string path = Path.GetTempFileName() + ".jpg";
            File.WriteAllBytes(path, imageData);
            return path;
        }
    }
}
