using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PoleChudesGame.Classes
{
    public class Question
    {
        [BsonIgnoreIfDefault]
        public ObjectId Id { get; set; }
        public int NumberQuestion { get; private set; }
        public string QuestionText { get; private set; }    
        public string AnswerText { get; private set; }

        public Question(string questionText, string answerText)
        {
            QuestionText = questionText;
            AnswerText = answerText;
        }

        public void SetNumber(int number)
        {
            NumberQuestion = number;
        }
    }
}
