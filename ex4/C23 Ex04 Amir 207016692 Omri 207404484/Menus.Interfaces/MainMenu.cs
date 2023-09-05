using System;

namespace Ex04
{
    public class MainMenu
    {
        internal string m_MainMenuName;
        internal List<object> m_MainmenuItems = new List<object>();

        public MainMenu(string i_CurrentMenu)
        {
            m_MainMenuName = i_CurrentMenu;
        }

        public void Add(object i_ItemInMenu)
        {
            if (i_ItemInMenu is MenuItem i_MenuItem)
            {
                m_MainmenuItems.Add(i_MenuItem);
            }
            else if (i_ItemInMenu is Leaf i_Leaf)
            {
                m_MainmenuItems.Add(i_Leaf);
            }
            else
            {
                throw new ArgumentException("Unsupported item type. Only MenuItem and Leaf are supported.");
            }
        }

        public void Show()
        {
            bool quit = false;

            Console.Clear();
            while (!quit)
            {
                byte menuCounter = 1;

                Console.WriteLine(String.Format("**{0}**", m_MainMenuName));
                Console.WriteLine("-----------------------");
                foreach (object i_Item in m_MainmenuItems)
                {
                    Console.WriteLine(String.Format("{0} -> {1}", menuCounter, i_Item));
                    menuCounter++;
                }
                Console.WriteLine("0 -> Exit");
                Console.WriteLine("-----------------------");
                Console.WriteLine(String.Format("Enter your request: (1 to {0} or press '0' to Exit).", m_MainmenuItems.Count));
                if (int.TryParse(Console.ReadLine(), out int io_Choice))
                {
                    if (io_Choice == 0)
                    {
                        quit = true;
                    }
                    else if (io_Choice > 0 && io_Choice <= m_MainmenuItems.Count)
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

        private void ExecuteSelectedMenuItem(int i_UserChoice) // Merge both functions into 1. Send the actual item/pass correct list
        {
            if (m_MainmenuItems[i_UserChoice] is MenuItem)
            {
                MenuItem? selectedMenuItem = m_MainmenuItems[i_UserChoice] as MenuItem;
                if (selectedMenuItem != null) //redundant? 
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
                Leaf? selectedLeaf = m_MainmenuItems[i_UserChoice] as Leaf;
                if (selectedLeaf != null)
                {
                    selectedLeaf.MethodToExecute();
                }
                else
                {
                    Console.WriteLine("The selected item is not a leaf");
                }
            }
        }

    }
}
