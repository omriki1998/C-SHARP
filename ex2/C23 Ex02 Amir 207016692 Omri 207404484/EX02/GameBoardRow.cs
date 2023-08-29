using System.Text;

namespace Ex02
{
    public class GameBoardRow
    {
        private Guess m_Guess;
        private StringBuilder m_RowStr;

        public GameBoardRow()
        {
            m_RowStr = new StringBuilder(rowStrInit(), 40);
        }

        public string RowStr
        {
            get { return m_RowStr.ToString(); }
        }

        public Guess Guess
        {
            set
            {
                m_Guess = value;
                setRowStr();
            }
        }

        private void setRowStr()
        {
            for (int k = 0; k < 4; k++)
            {
                m_RowStr[2 * (k + 1)] = m_Guess.UserGuess[k];
            }

            char charToAdd = 'V';
            for (int i = 0; i < m_Guess.NumOfBullsEye + m_Guess.NumOfHits; i++)
            {
                if (i == m_Guess.NumOfBullsEye)
                {
                    charToAdd = 'X';
                }

                m_RowStr[11 + (2 * i)] = charToAdd;
            }
        }

        private string rowStrInit()
        {
            string rowStr = @"|         |       |
|=========|=======|";
            return rowStr;
        }
    }
}
