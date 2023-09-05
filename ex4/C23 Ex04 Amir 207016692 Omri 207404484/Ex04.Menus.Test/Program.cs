namespace Ex04
{
    public class Program
    {
        public static void Main()
        {
            MainMenu menu = new MainMenu("Delegates Main Menu");
            MenuItem menuItem = new MenuItem("Show Date/Time");
            Leaf dateLeaf = new ShowDate("Show Date");
            Leaf TimeLeaf = new ShowTime("Show TIme");
            MenuItem versionItem = new MenuItem("Versions and Capitals");
            Leaf versionLeaf = new ShowVersion("Show Versions");
            Leaf capitalsLeaf = new CountCapitals("Count Capitals");
            menu.Add(menuItem);
            menu.Add(versionItem);
            menuItem.Add(dateLeaf);
            menuItem.Add(TimeLeaf);
            versionItem.Add(capitalsLeaf);
            versionItem.Add(versionLeaf);
            menu.Show(); 
        }
    }
}