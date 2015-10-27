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
        public int[][][] images;

        public FileLoader()
        {

        }
        public int[][][] open(string path, string noise_type)
        {

            System.IO.Stream fs = null;
            System.IO.StreamReader fr = null;

            //fr = new System.IO.StreamReader(path+"\\"+noise_type+".my-obj");
            string full_path = path + "\\test\\" + "file.my_obj";
            fr = new System.IO.StreamReader(full_path);
            string file = fr.ReadToEnd();


            return images;
        }
        //string path;
        //System.IO.Stream fs = null;
        //System.IO.StreamReader fr = null;
    }

}