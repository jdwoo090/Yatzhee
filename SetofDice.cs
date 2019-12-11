using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YetAnotherDice
{
    class SetofDice
    {
        Dice[] m_dice = new Dice[5];
        bool[] m_keep = new bool[5];
        int m_numRolls = 0;
        int m_score = 0;
        public Boolean max = false;
        public SetofDice()
        {
            for (int i = 0; i < m_dice.Length; i++)
            {
                m_dice[i] = new Dice();
            }
        }

        public void roll()
        {
            if (m_numRolls == 3)
            {
                max = true;
                return;
            }

            m_numRolls++;

            foreach (Dice d in m_dice)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (!m_keep[i])
                        m_dice[i].roll();
                }
            }
        }

        public void reset()
        {
            m_numRolls = 0;
            max = false;
            m_score = 0;

            for (int i = 0; i < m_keep.Length; i++)
            {
                m_keep[i] = false;
            }
        }

        public void keep(int n)
        {
            m_keep[n] = true;
        }

        public bool getKeep(int n)
        {
            return m_keep[n];
        }

        public Boolean ThreeofaKind()
        {
            int[] val = new int[5];

            for (int i = 0; i < val.Length; i++)
            {
                val[i] = getValue(i);
            }

            Array.Sort(val);

            for (int i = 0; i < 3; i++)
            {
                if (val[i] == val[i + 1] &&
                    val[i + 1] == val[i + 2])
                {
                    m_score += i;
                    return true;
                }
            }

            return false;
        }

        public Boolean SmallStraight()
        {
            int[] val = new int[5];

            for (int i = 0; i < val.Length; i++)
            {
                val[i] = getValue(i);
            }

            Array.Sort(val);

            for (int i = 0; i < 2; i++)
            {
                if (val[i] == (val[i + 1] - 1) &&
                    val[i + 1] == (val[i + 2] - 1) &&
                    val[i + 2] == (val[i + 3] - 1))
                {
                    m_score += 30;
                    return true;
                }
            }

            return false;
        }

        public Boolean LargeStraight()
        {
            int[] val = new int[5];

            for (int i = 0; i < val.Length; i++)
            {
                val[i] = getValue(i);
            }

            Array.Sort(val);

            for (int i = 0; i < 2; i++)
            {
                if (val[i] == (val[i + 1] - 1) &&
                    val[i + 1] == (val[i + 2] - 1) &&
                    val[i + 2] == (val[i + 3] - 1) &&
                    val[i + 3] == (val[i + 4] - 1))
                {
                    m_score += 40;
                    return true;
                }
            }

            return false;
        }

        public Boolean FourofaKind()
        {
            int[] val = new int[5];

            for (int i = 0; i < val.Length; i++)
            {
                val[i] = getValue(i);
            }

            Array.Sort(val);

            for (int i = 0; i < 2; i++)
            {
                if (val[i] == val[i + 1] &&
                    val[i + 1] == val[i + 2] && 
                    val[i + 2] == val[i + 3])
                {
                    m_score += i;
                    return true;
                }
            }

            return false;
        }

        public Boolean Yahtzee()
        {
            int[] val = new int[5];

            for (int i = 0; i < val.Length; i++)
            {
                val[i] = getValue(i);
            }

            Array.Sort(val);

            for (int i = 0; i < 1; i++)
            {
                if (val[i] == val[i + 1] &&
                    val[i + 1] == val[i + 2] &&
                    val[i + 2] == val[i + 3] &&
                    val[i + 3] == val[i + 4])
                {
                    m_score += 50;
                    return true;
                }
            }

            return false;
        }

        public Boolean FullHouse()
        {
            int[] val = new int[5];

            for (int i = 0; i < val.Length; i++)
            {
                val[i] = getValue(i);
            }

            Array.Sort(val);

            for (int i = 0; i < 1; i++)
            {
                if (val[i] == val[i + 1] &&
                    val[i + 1] == val[i + 2] &&
                    val[i + 2] != val[i + 3] &&
                    val[i + 3] == val[i + 4] ||
                    val[i] == val[i + 1] &&
                    val[i + 1] == val[i + 2] &&
                    val[i + 2] == val[i + 3] &&
                    val[i + 3] != val[i + 4])

                {
                    m_score += 25;
                    return true;
                }
            }

            return false;
        }

        public int getValue(int n)
        {
            /*switch (n)
            {
                case 0:
                case 1:
                case 2:
                    return 1;
                case 3:
                case 4:
                    return 2;
            }*/
            return m_dice[n].getValue();
        }

        public override string ToString()
        {
            string retVal = "";

            for (int i = 0; i < m_dice.Length; i++)
            {
                retVal += getValue(i) + ", ";
            }

            return retVal;


        }
        public int score()
        {
            return m_score;
        }
    }
}
