using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace Validate_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int counter = 0;
                string line;
                List<string> v_List = new List<string>();

                string url = @"urls.txt";
                string certos = @"URL_OK.txt";
                string errados = @"URL_Error.txt";

                if (!File.Exists(url))
                {
                    throw new Exception("O arquivo de URLs não foi criado!");
                }

                Console.OutputEncoding = System.Text.Encoding.GetEncoding(1252);

                // Read the file and display it line by line.  
                StreamReader file = new StreamReader(url, System.Text.Encoding.GetEncoding(1252));

                while ((line = file.ReadLine()) != null)
                {
                    System.Console.WriteLine("Reading: " + line);
                    v_List.Add(@line);
                    counter++;
                }

                file.Close();


                if (File.Exists(certos))
                {
                    File.Delete(certos);
                }
                if (File.Exists(errados))
                {
                    File.Delete(errados);
                }

                foreach (var v_url in v_List)
                {
                    //HttpWebResponse response = null;
                    //var request = (HttpWebRequest)WebRequest.Create(v_url);
                    //request.Method = "HEAD";

                    try
                    {
                        //response = (HttpWebResponse)request.GetResponse();

                        if (Directory.Exists(v_url))
                        {
                            using (StreamWriter v_ArquivosCertos = new StreamWriter(certos, true))
                            {
                                v_ArquivosCertos.WriteLine(v_url);
                                Console.WriteLine("OK: " + v_url);
                            }
                        }
                        else
                        {
                            using (StreamWriter v_ArquivosErrados = new StreamWriter(errados, true))
                            {
                                v_ArquivosErrados.WriteLine(v_url);
                                Console.WriteLine("Not found: " + v_url);
                            }
                        }

                        

                    }
                    catch (WebException ex)
                    {
                        /* A WebException will be thrown if the status of the response is not `200 OK` */
                        
                    }
                    finally
                    {
                        /* Close your response. */
                        //if (response != null)
                        //{
                        //    response.Close();
                        //}
                    }
                }



            }
            catch (Exception e)
            {
                Console.WriteLine("Falha ao executar o procedimento: {0}", e.Message);
            }
            finally
            {
                // Suspend the screen.  
                System.Console.ReadLine();
            }
        }
    }
}
