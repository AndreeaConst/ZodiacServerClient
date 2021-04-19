using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using System;
using System.Threading.Tasks;
using ZodiacClient;

namespace Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Zodiac.ZodiacClient(channel);

            bool enterAnotherDate = true;

            char[] wrongDelimiters = {' ', '.', '-' };

            do
            {
                string responseToEnterAnotherDate;

                Console.Write("Type in your birthdate in the format: MM/DD/YYYY\n");
                string dateString = Console.ReadLine();
                if (dateString.IndexOfAny(wrongDelimiters) == -1)
                {
                    DateTime date;

                    if (DateTime.TryParse(dateString, out date))
                    {

                        var zodiacToBeFound = new ClientZodiac()
                        {
                            ZodiacDate = Timestamp.FromDateTimeOffset(date)
                        };
                        var response = await client.FindZodiacAsync(new ZodiacRequest { Zodiac = zodiacToBeFound });
                        Console.WriteLine("Your zodiac is: " + response.ZodiacName);

                        enterAnotherDate = false;
                    }
                    else
                    {
                        Console.WriteLine("You have entered an incorrect date. Would you like to try again? Yes or No");
                        responseToEnterAnotherDate = Console.ReadLine();

                        if (responseToEnterAnotherDate != "Yes")
                            enterAnotherDate = false;
                    }
                }
                else
                {
                    Console.WriteLine("You used some other delimiters besides '/'. Would you like to try again? Yes or No");
                    responseToEnterAnotherDate = Console.ReadLine();

                    if (responseToEnterAnotherDate != "Yes")
                        enterAnotherDate = false;
                }
            } while (enterAnotherDate);


        }
    }
}
