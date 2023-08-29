using System.Collections.Generic;
using System.Text;

namespace Ex02
{
    public class GameBoard
    {
        private List<GameBoardRow> m_ListOfRows = new List<GameBoardRow>();
        private byte m_NumOfRows = 10;
        private StringBuilder m_GameBoardStr;

        public GameBoard(byte i_NumOfRows)
        {
            m_NumOfRows = i_NumOfRows;
            m_GameBoardStr = new StringBuilder(boardStrInit());
            
            for (int i = 0; i < m_NumOfRows; i++)
            {
                m_ListOfRows.Add(new GameBoardRow());
                m_GameBoardStr.Append("\n");
                m_GameBoardStr.Append(m_ListOfRows[i].RowStr);
            }
        }

        public void RefreshGameBoardStr(int i_RowNum)
        {
            m_GameBoardStr = new StringBuilder(boardStrInit());
            for (int i = 0; i < m_NumOfRows; i++)
            {
                m_GameBoardStr.Append("\n");
                m_GameBoardStr.Append(m_ListOfRows[i].RowStr);
            }
        }

        public List<GameBoardRow> ListOfRows
        {
            get { return m_ListOfRows; }
        }

        public StringBuilder GameBoardStr
        {
            get { return m_GameBoardStr; }
        }

        private string boardStrInit()
        {
            string rowStr = @"|Pins:    |Result:|
|=========|=======|
| # # # # |       |
|=========|=======|";
            return rowStr;
        }
    }
}
