using MongoDB.Driver;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime;
using System;

namespace PoleChudesGame.Classes
{
    public static class QuestionService
    {
        public static void LoadQuestion(Question question)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("PoleChudesGame");
            var collection = database.GetCollection<Question>("Questions");
            var q = collection.Find(x => x.QuestionText != null).Sort("{NumberOfDocument: -1}").FirstOrDefault<Question>();

            if (q != null)
            {
                question.SetNumber(q.NumberQuestion + 1);
            }
            else
            {
                question.SetNumber(1);
            }

            collection.InsertOne(question);
        }

        public static Question UpLoadRandomQuestion()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("PoleChudesGame");
            var collection = database.GetCollection<Question>("Questions");
            var q = collection.Find(x => x.QuestionText != null).Sort("{NumberOfDocument: -1}").FirstOrDefault<Question>();
            var rnd = new Random();

            if(q != null)
            {
                var number = rnd.Next(1, q.NumberQuestion + 1);

                return collection.Find(x => x.NumberQuestion == number).FirstOrDefault();
            }

            return null;
        }


    }
}
