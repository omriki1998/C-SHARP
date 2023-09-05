namespace Ex04
{
    public class Program
    {
        public static void Main()
        {
            MainMenu menu = new MainMenu("Delegates Main Menu");
            MenuItem dateTimeItem = new ShowDateTime("Show Date/Time");
            Leaf dateLeaf = new ShowDate("Show Date");
            Leaf TimeLeaf = new ShowTime("Show TIme");
            MenuItem versionItem = new ShowVersionCapitals("Versions and Capitals");
            Leaf versionLeaf = new ShowVersion("Show Versions");
            Leaf capitalsLeaf = new CountCapitals("Count Capitals");
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