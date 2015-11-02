using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Threading;

namespace Neural_Image_Recontruction
{
    class FileLoader
    {
        //private ManualResetEvent _doneEvent;


        private int i = 0;
        private int j = 0;

        public string _path;
        public string _type;
        public string _noiseType;
        public int _samples;
        public int[][] _imgArr = new int[1][];

        public FileLoader()
        {
            //_doneEvent = doneEvent;
        }

        public void prepareOpen(string path, string type, string noise_type, int samples)
        {
            _path = path;
            _type = type;
            _noiseType = noise_type;
            _samples = samples;
            Array.Resize(ref _imgArr, _samples);
            for(int i=0; i<_samples; i++)
            {
                Array.Resize(ref _imgArr[i], 784);
            }
        } //method prepareOpen

        public void open()
        {

            //System.IO.Stream fs = null;
            System.IO.StreamReader fr = null;
            //int[,] img_line_arr = new int[_samples, 784];
            string file;
            if (_noiseType == "clean")
            {
                file = _path + "\\" + _type + "\\" + "file.my-obj";
            }
            else
            {
                file = _path + "\\" + _type + "\\" + _noiseType + ".my-obj";
            }
            //file = "C:\\Users\\Sebi\\OneDrive\\Dokumente\\Master\\Erasmus\\Vorlesungen\\project\\code\\file.my-obj";

            fr = new System.IO.StreamReader(file);
            string text = fr.ReadToEnd();
            text = text.Replace(" ", string.Empty);

            string word = string.Empty;
            char[] token = new char[1];

            for (int k = 0; k < text.Length; k++)
            {
                text.CopyTo(k, token, 0, 1);

                if (token[0].ToString() == "[")
                {
                    //new image begins
                    j = 0;
                }
                else if (token[0].ToString() == "]")
                {
                    //image ends    
                    _imgArr[i][j] = int.Parse(word);
                    word = string.Empty;
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
                    _imgArr[i][j] = int.Parse(word);
                    word = string.Empty;
                    j++;
                }
                else
                {
                    //pixel data
                    try
                    {
                        word = word + (token[0].ToString());
                    }
                    catch (Exception ex)
                    {
                        continue;
                    } //try
                } //if
            } //for
            //return img_line_arr;
        } //method open
            
        //public void ThreadPoolCallBack(Object threadContext)
        //{
        //    int threadIndex = (int)threadContext;
        //    Console.WriteLine("thread {0} started...", threadIndex);
        //}

            
        

    }

}