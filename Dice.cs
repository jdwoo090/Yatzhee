using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YetAnotherDice
{
    class Dice
    {
        int m_value;
        Random random = new Random();

        public Dice()
        {
            System.Threading.Thread.Sleep(10);
            roll();
        }

        public void roll()
        {
            m_value = random.Next(1, 7);
        }

        public int getValue()
        {
            return m_value;
        }
    }
}
