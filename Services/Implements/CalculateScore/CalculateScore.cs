using System;
using System.Collections.Generic;

namespace Services.Implements.CalculateScore
{
    public class CalculateScore
    {
        // 🔹 เมธอดหลัก เริ่มต้นโปรแกรม
        //public static void Main()
        //{
        //    string word = "Education"; // คุณสามารถเปลี่ยนคำได้ตรงนี้
        //    int score = WordCalculate(word);

        //    string formatted = FormatWord(word);

        //    Console.WriteLine($"Input Word: {word}");
        //    Console.WriteLine($"Formatted Word: {formatted}");
        //    Console.WriteLine($"Total Score: {score}");
        //}

        // 🔹 เมธอดคำนวณคะแนน
        public async Task<int> WordCalculate(string word)
        {
            int total = 0;
            int scoreVowelGroup = 0;
            bool isInVowelGroupState = false;
            int vowelGroupCount = 0;

            Dictionary<char, int> vowel = new Dictionary<char, int>()
            {
                { 'A', 2 },
                { 'E', 3 },
                { 'I', 4 },
                { 'O', 5 },
                { 'U', 6 }
            };

            string upperWord = word.ToUpper();

            Random random = new Random();

            for (int index = 0; index < upperWord.Length; index++)
            {
                char ch = upperWord[index];
                bool isVowel = vowel.ContainsKey(ch);

                if (isVowel)
                {
                    scoreVowelGroup += vowel[ch];
                    vowelGroupCount++;
                    isInVowelGroupState = true;
                }
                else
                {
                    if (isInVowelGroupState)
                    {
                        if (vowelGroupCount > 1)
                        {
                            if (random.NextDouble() < 0.1)
                            {
                                Console.WriteLine("(VIP) Lucky! Bonus x2 applied 🎉");
                                total += scoreVowelGroup * 2;
                            }
                            else
                            {
                                total += scoreVowelGroup;
                            }
                        }
                        else
                        {
                            total += scoreVowelGroup;
                        }

                        scoreVowelGroup = 0;
                        vowelGroupCount = 0;
                        isInVowelGroupState = false;
                    }

                    total += 1;
                }
            }

            if (isInVowelGroupState)
            {
                if (vowelGroupCount > 1)
                {
                    if (random.NextDouble() < 0.1)
                    {
                        Console.WriteLine("(VIP) Lucky! Bonus x2 applied at end 🎉");
                        total += scoreVowelGroup * 2;
                    }
                    else
                    {
                        total += scoreVowelGroup;
                    }
                }
                else
                {
                    total += scoreVowelGroup;
                }
            }

            return total;
        }

        // 🔹 เมธอดแปลงตัวอักษร (สระ = พิมพ์ใหญ่, พยัญชนะ = พิมพ์เล็ก)
        public async Task<string> FormatWord(string word)
        {
            Dictionary<char, int> vowel = new Dictionary<char, int>()
            {
                { 'A', 2 },
                { 'E', 3 },
                { 'I', 4 },
                { 'O', 5 },
                { 'U', 6 }
            };

            string newStr = "";

            foreach (char chr in word)
            {
                if (vowel.ContainsKey(char.ToUpper(chr)))
                {
                    newStr += char.ToUpper(chr);
                }
                else
                {
                    newStr += char.ToLower(chr);
                }
            }

            return newStr;
        }
    }
}
