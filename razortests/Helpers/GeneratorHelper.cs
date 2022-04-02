
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace razortests.Pages.Accounts.Helpers
{
    public class GeneratorHelper
    {

        public string GeneratePassword(int maxLen, bool Caps, bool Symb, bool numbs)
        {

            string selectCharacters = "abcdefghijklmnopqrstuvwxyz";
            string symbs = "!@#$%&*)(!@#$%&*)(";
            string numbers = "12345678901234567890";


            string selectChoice = "";


            Random rand = new Random();

            string output = "";
            if (Caps == true)
            {
                selectCharacters += selectCharacters.ToUpper();

            }

            if (Symb == false)
            {
                symbs = "";

            }

            if (numbs == false)
            {
                numbers = "";
            }
            selectChoice = selectCharacters + symbs + numbers;

            for (int i = 0; i < maxLen; i++)
            {

                int num = rand.Next(selectChoice.Length);

                output += selectChoice[num];

            }
            return output;
        }

     
    }
}
