using System;

namespace Ex04
{
    public class MenuItem : IMenuItem
    {
        internal string m_MenuName;
        internal List<object> m_MenuItems = new List<object>();

        public MenuItem(string i_MenuName)
        {
            m_MenuName = i_MenuName;
        }
        public void DisplayMenu()
        {
            bool quit = false;

            Console.Clear();
            while (!quit)
            {
                byte menuCounter = 1;
                
                Console.WriteLine(String.Format("**{0}**\n" +
                    "-----------------------", m_MenuName));
                foreach (object i_Item in m_MenuItems)
                {
                    Console.WriteLine(String.Format("{0} -> {1}", menuCounter, i_Item.ToString()));
                    menuCounter++;
                }
                Console.WriteLine(String.Format("0 -> Back\n" +
                    "-----------------------\n" +
                    "Enter your request: (1 to {0} or press '0' to go back).", m_MenuItems.Count));
                if (int.TryParse(Console.ReadLine(), out int io_Choice))
                {
                    if (io_Choice == 0)
                    {
                        quit = true;
                        Console.Clear();
                        break;
                    }
                    else if (io_Choice > 0 && io_Choice <= m_MenuItems.Count)
                    {
                        ExecuteSelectedMenuItem(io_Choice - 1);
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice, please try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        private void ExecuteSelectedMenuItem(int i_UserChoice)
        {
            if (m_MenuItems[i_UserChoice] is MenuItem)
            {
                MenuItem? selectedMenuItem = m_MenuItems[i_UserChoice] as MenuItem;
                if (selectedMenuItem != null)
                {
                    selectedMenuItem.DisplayMenu();
                }
                else
                {
                    Console.WriteLine("The selected item is not a menu item.");
                }
            }
            else
            {
                Leaf? selectedLeaf = m_MenuItems[i_UserChoice] as Leaf;
                if (selectedLeaf != null)
                {
                    Console.Clear();
                    selectedLeaf.MethodToExecute();
                }
                else
                {
                    Console.WriteLine("The selected item is not a leaf");
                }
            }
        }

        public override string ToString()
        {
            return m_MenuName;
        }

        public void Add(object i_ItemInMenu)
        {
            if (i_ItemInMenu is MenuItem i_MenuItem)
            {
                m_MenuItems.Add(i_MenuItem);
            }
            else if (i_ItemInMenu is Leaf i_Leaf)
            {
                m_MenuItems.Add(i_Leaf);
            }
            else
            {
                throw new ArgumentException("Unsupported item type. Only MenuItem and Leaf are supported.");
            }
        }
    }
}
