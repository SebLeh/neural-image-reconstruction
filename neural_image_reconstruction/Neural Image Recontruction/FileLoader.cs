using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Neural_Image_Recontruction
{
    class FileLoader
    {
        public string path;
        //public int[][][] images;

        public FileLoader()
        {

        }
        public int[,] open(string path, string type, string noise_type, int samples)
        {

            //System.IO.Stream fs = null;
            System.IO.StreamReader fr = null;
            int[,] img_line_arr = new int[samples, 784];
            string file;
            if (noise_type == "clean")
            {
                file = path + "\\" + type + "\\" + "file.my-obj";
            }
            else
            {
                file = path + "\\" + type + "\\" + noise_type + ".my-obj";
            }
            fr = new System.IO.StreamReader(file);
            string text = fr.ReadToEnd();
            

            for (int k = 0; k<text.Length; k++)
            {
                int i = 0;
                int j = 0;
                char[] token = new char[1];
                text.CopyTo(k, token, 0, 1);
                //text.Remove(0, 1);

                if (token[0].ToString() == "[")
                {
                    //new image begins
                    j = 0;
                }
                else if (token[0].ToString() == "]")
                {
                    //image ends                    
                    i++;
                }
                else if (token[0].ToString() == "_")
                {
                    //file ends
                    break;
                }
                else if (token[0].ToString() == ",")
                {
                    //separator between pixel values
                }
                else if (token[0].ToString() == "")
                {
                    //sadly file has whitespace
                    continue;
                }
                else
                {
                    //image data
                    try
                    {
                        img_line_arr[i, j] = int.Parse(token[0].ToString());
                        j++;
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                    
                }

            }         
            

            return img_line_arr;
        }
        //string path;
        //System.IO.Stream fs = null;
        //System.IO.StreamReader fr = null;
    }

}