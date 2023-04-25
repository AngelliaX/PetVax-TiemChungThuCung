using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataAccessLayer
{
    public static class CommonUseDAO
    {

        //Bắt buộc chuỗi pet_id phải theo cú pháp "AB" với A là string, B là số
        public static string getTextPart(string input)
        {
            bool foundNumber = false;
            string textPart = "";
            foreach (char c in input)
            {
                if (Char.IsDigit(c))
                {
                    foundNumber = true;
                }
                else
                {
                    if (foundNumber)
                    {
                        break;
                    }
                    textPart += c;
                }
            }
            return textPart;
        }

        public static int getNumberPart(string input)
        {
            int numberPart = 0;

            bool foundNumber = false;
            foreach (char c in input)
            {
                if (Char.IsDigit(c))
                {
                    numberPart = numberPart * 10 + (c - '0');
                    foundNumber = true;
                }
                else
                {
                    if (foundNumber)
                    {
                        break;
                    }
                }
            }
            return numberPart;
        }

    }
}
