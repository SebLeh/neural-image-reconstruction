using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace Neural_Image_Recontruction
{
    class DataConverter
    {
        public string dataPath = "C:\\Users\\Sebi\\OneDrive\\Dokumente\\Master\\Erasmus\\Vorlesungen\\project\\code\\data\\noisy";
        public string labelPath = "C:\\Users\\Sebi\\OneDrive\\Dokumente\\Master\\Erasmus\\Vorlesungen\\project\\code\\data\\clean";

        public DataConverter()
        {
            doIt();
        }

        public void doIt()
        {
            //StreamReader fr = null;

            for (int ii = 0; ii < 60; ii++)
            {
                string path = labelPath + "\\train\\file-" + ii.ToString() + ".my-obj";
                //string newPath = labelPath + "\\train\\file";
                //fr = new StreamReader(path);
                //string text = fr.ReadToEnd();
                string text = File.ReadAllText(path);
                char[] token = new char[1];
                //fr = null;



                text = text.Replace(" ", string.Empty);
                File.WriteAllText(path, text);

                //text = text.Replace("\n", string.Empty);
                //text = text.Replace("\r", string.Empty);
                //text = Regex.Replace(text, @"\[\s+", "[");
                //text = Regex.Replace(text, @"\s+", ",");

                //int j = 1;
                //int k = 0;
                //int oldI = 0;
                //int max = 1000;
                //string file = string.Empty;

                //for (int i = 0; i < text.Length; i++)
                //{
                //    text.CopyTo(i, token, 0, 1);
                //    if (token[0].ToString() == "]")
                //    {
                //        j++;
                //        if (j == max)
                //        {
                //            file = text.Substring(oldI, i - oldI);
                //            string fullPath = newPath + "-" + k.ToString() + ".my-obj";
                //            File.WriteAllText(fullPath, file);
                //            j = 0;
                //            k++;
                //            oldI = i;
                //        }
                //    }
                //}
            }
        }
    }
}
