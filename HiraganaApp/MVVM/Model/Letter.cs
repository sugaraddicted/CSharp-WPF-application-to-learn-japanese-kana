using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiraganaApp.MVVM.Model
{
    public class Letter
    {

        public int Id { get; set; }
        public string Symbol { get; set; }
        public string Transcription { get; set; }

        public Letter()
        {

        }

        public Letter(int id, string symbol, string transcription)
        {
            Id = id;
            Symbol = symbol;
            Transcription = transcription;
        }

        public Letter GetRandomLetter(List<Letter> letters)
        {
            Random rnd = new Random();
            int id = rnd.Next(0, letters.Count());
            return letters[id];
        }
    }
}
