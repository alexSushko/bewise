using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Puma.Net;
using System.Drawing;
using Spire.Doc;
using Spire.Doc.Documents;
using System.IO;
using SovaTranslate_001.Models;
namespace SovaTranslate_001
{
    public static class TextParsing
    {
        private static PumaLanguage SetLanguage(int Language) {
            string s = DataBase.GetLanguageName(Language);
            switch (s.Trim().ToLower()) 
            {
                case "english": return PumaLanguage.English;
                case "russian": return PumaLanguage.Russian;
                case "ukrainiane": return PumaLanguage.Ukrainian;
                default: return PumaLanguage.English;
            }
        }
        public static bool FormatFile(string pathToFile) {
            string s = pathToFile.Split('.')[1];
            switch (s.ToLower()) {
                case "jpg": return true;
                case "jpeg": return true;
                case "png": return true;
                case "pdf": return true;
                default: return false;
            }
        }
        public static string ImgToFile(string pathToFile, int Language)
        {
            if (FormatFile(pathToFile))
            {
                string result = "";
                using (Bitmap load = new Bitmap(pathToFile))
                {


                    using (PumaPage image = new PumaPage(load))
                    {
                        image.FileFormat = PumaFileFormat.TxtAscii ;
                        image.AutoRotateImage = true;
                        image.EnableSpeller = false;
                        image.RecognizeTables = true;
                        image.FontSettings.DetectItalic = true;
                        image.Language = SetLanguage(Language);

                        try
                        {
                            result = image.RecognizeToString();
                        }
                        catch (Exception e)
                        {
                            image.Dispose();
                        }
                    }

                }
              return result;
            }else return null;
        }
        private class specw {
            public int ind;
            public  int pos;
           public  int spec;
            public specw(int p, int s,int i) {
                pos = p;
                spec = s;
                ind = i;
            }
        }
        public static double[,] TextSpecialization(string filename, int LanguageId)
        {
            
            int R = 10;
            Document docum = new Document();
            docum.LoadFromFile(filename, FileFormat.Auto);
            docum.Document.SaveToTxt("C:\\Users\\Олександр\\Documents\\Visual Studio 2012\\Projects\\SovaTranslate_001\\SovaTranslate_001\\Content\\1.txt", System.Text.Encoding.GetEncoding(65001));
           int position=0;
                        sovadb001Entities0 db = new sovadb001Entities0();


                        string[] lines = System.IO.File.ReadAllLines("C:\\Users\\Олександр\\Documents\\Visual Studio 2012\\Projects\\SovaTranslate_001\\SovaTranslate_001\\Content\\1.txt");
                        List<specw> specwords=new List<specw>();
            int w=0;
                        foreach (string line in lines)
                        {
                            string[] words = line.Split(' ');
                            foreach (string word in words)
                            {
                               
                                WordsSpecialization d = db.WordsSpecializations.FirstOrDefault(r =>r.isWordSpecialization==true&&r.languageId==LanguageId&& r.word == word);
                                if (d != null)
                                {
                                    specw s = new specw(position, d.IdSpecialization,w);
                                    w++;
                                    specwords.Add(s);
                                }
                                position++;

                            }
                        }
            //Clasterization
                        List<specw> specwords1 = new List<specw>();
                        specwords1.AddRange(specwords);
                       
                        Random rand = new Random();
                        List<int[]> clasters = new List<int[]>();
                       
                        
                           
                            while (specwords1.Count != 0)
                            {
                                specw wordC = new specw(specwords1[rand.Next(0, specwords1.Count)].pos, specwords1[rand.Next(0, specwords1.Count)].spec, 0);

                                int npos = wordC.pos;
            
                                List<int> claster = new List<int>();
                            do{
                                npos = wordC.pos;
                                claster.Clear();
                                int x=0;
                                foreach (var i in specwords)
                                {
                                    if (specwords1.Contains(i)&& i.spec == wordC.spec&&Math.Abs(wordC.pos - i.pos) < R)
                                    {
                                        claster.Add(x);
                                    }
                                    x++;

                                }
                            
                                    
                                    int sum = 0;
                                    for(int j=0;j<claster.Count;j++){
                                        sum += specwords[claster[j]].pos;
                                    }
                                sum/=claster.Count;
                                wordC.pos = sum;
                                }while (npos != wordC.pos);
                            if (claster != null)
                            {
                                clasters.Add(claster.ToArray());
                                int r = 0;
                                foreach (int i in claster)
                                {
                                    specwords1.Remove(specwords1.First(g => g.ind == i));
                                    r++;
                                }
                            }

                              }
                            //endClast
                           // List<int[]> nclasters = new List<int[]>();
                           // int t = 0;
                           //for(int i =0; i<clasters.Count-t;i++){
                           //    bool flag = false;
                           //for(int j =0; j<clasters.Count-t;j++){
                           //    if (i != j)
                           //    {
                           //        if (specwords[clasters[i][0]].spec == specwords[clasters[j][0]].spec)
                           //        {
                           //            flag = true;
                           //            List<int> nlist = new List<int>();
                           //            nlist.AddRange(clasters[i]);
                           //            nlist.AddRange(clasters[j]);

                           //            nclasters.Add(nlist.ToArray());
                           //        }
                           //    }
                           //}
                           //if (!flag) { nclasters.Add(clasters[i]); }
                           //}

                            double[,] result = new double[clasters.Count, 2];
                            for (int i = 0; i < clasters.Count; i++) {
                                int min = 999999999;

                                int max = 0;
                                foreach (var j in clasters[i])
                                {
                                    if (specwords[j].pos < min)
                                    {
                                        min = specwords[j].pos;
                                    }
                                    if (specwords[j].pos > max)
                                    {
                                        max = specwords[j].pos;
                                    }
                                }
                                result[i, 0] = Math.Abs(max - min);
                                result[i, 1] = specwords[(clasters[i])[0]].spec;
                            }
                            double[,] nresult = new double[result.GetLength(0),2];
                            int t = 0;
                            int f = 0;
                            for (int i = 0; i < result.GetLength(0) - t; i++)
                            {
                                bool flag = false;
                                if(result[i,0]!=0)
                                for (int j = i+1; j < clasters.Count - t; j++)
                                {
                                    if (i != j)
                                    {
                                        if (result[i,1] == result[j,1])
                                        {
                                            flag = true;
                                            nresult[f,0]=result[i,0]+result[j,0];
                                            nresult[f, 1] = result[i, 1];
                                            result[i, 0] += result[j, 0];
                                            result[j, 0] = 0;
                                            f++;
                                        }
                                    }
                                }
                                if (!flag) { nresult[f, 0] = result[i, 0];
                                nresult[f, 1] = result[i, 1];
                                f++;
                                }
                            }
                            for (int o = 0; o < result.GetLength(0); o++)
                            {
                                result[o, 0]=(result[o,0]*100) /position;
                            }


            return result;
            
        }
    }
}