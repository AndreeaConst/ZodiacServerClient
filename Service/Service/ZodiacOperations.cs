using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ZodiacServer;

namespace Server.DataAccess
{
    public class ZodiacOperations
    {
        private readonly string filePath = "./Resources/ZodiacDates.txt";

        public string CalculateZodiac(ClientZodiac zodiac)
        {
            //Console.WriteLine(zodiac.ZodiacDate.ToDateTime().Day);
            string line;
            try
            {
                StreamReader sr = new StreamReader(filePath);
                line = sr.ReadLine();
                while (line != null)
                {
                    string[] broken_line = line.Split(' ');

                    string zodiacName = broken_line[0];

                    string zodiacStartMonth = broken_line[1];
                    string zodiacStartDay = broken_line[2];

                    string zodiacEndMonth = broken_line[3];
                    string zodiacEndDay = broken_line[4];

                    if (zodiac.ZodiacDate.ToDateTime().Month == Convert.ToInt32(zodiacStartMonth) || zodiac.ZodiacDate.ToDateTime().Month == Convert.ToInt32(zodiacEndMonth))
                        if (zodiac.ZodiacDate.ToDateTime().Day+1 >= Convert.ToInt32(zodiacStartDay) || zodiac.ZodiacDate.ToDateTime().Day+1 <= Convert.ToInt32(zodiacEndDay))
                            return zodiacName;

                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }

            return "No zodiac name found for the introduced date";
        }

    }
}
