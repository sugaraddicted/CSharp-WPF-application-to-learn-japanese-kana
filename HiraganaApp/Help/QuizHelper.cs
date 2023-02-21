using HiraganaApp.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Formats.Asn1.AsnWriter;

namespace HiraganaApp.Help
{
    public class QuizHelper
    {

        public static Letter GetRandomLetter(List<Letter> letters)
        {
            Random rnd = new Random();
            int id = rnd.Next(0, letters.Count());
            return letters[id];
        }

        public static List<Letter> GetVariantsList(Letter letter, List<Letter> letters)
        {
            List<Letter> variants = new List<Letter>();
            const int amoutnOfVariants = 3;

            int j = 0;
            variants.Add(letter);
            while (j < amoutnOfVariants)
            {
                var variant = GetRandomLetter(letters);
                if (!variants.Contains(variant))
                {
                    variants.Add(variant);
                    j++;
                }
            }

            var mixedVariants = MixLetters(variants);

            return mixedVariants;
        }


        public static List<Letter> MixLetters(List<Letter> letters)
        {
            var result = letters.OrderBy(a => Guid.NewGuid()).ToList();
            return result;
        }
    }
}
