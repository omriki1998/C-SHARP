using System;

namespace Ex04
{
    internal class BuildMenu
    {
        internal static void RunMenu()
        {
            MainMenu menu = new MainMenu("Delegates Main Menu");
            MenuItem dateTimeItem = new ShowDateTime("Show Date/Time");
            ILeaf dateLeaf = new ShowDate("Show Date");
            ILeaf TimeLeaf = new ShowTime("Show TIme");
            MenuItem versionItem = new ShowVersionCapitals("Versions and Capitals");
            ILeaf versionLeaf = new ShowVersion("Show Version");
            ILeaf capitalsLeaf = new CountCapitals("Count Capitals");

            menu.Add(dateTimeItem);
            menu.Add(versionItem);
            dateTimeItem.Add(dateLeaf);
            dateTimeItem.Add(TimeLeaf);
            versionItem.Add(capitalsLeaf);
            versionItem.Add(versionLeaf);
            menu.Show();
        }
    }
}
