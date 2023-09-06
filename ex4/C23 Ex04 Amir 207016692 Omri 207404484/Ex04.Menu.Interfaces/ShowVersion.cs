using System;
using System.Reflection;

namespace Ex04
{
    public class ShowVersion : Leaf
    {
        public ShowVersion(string i_LeafName) : base(i_LeafName)
        {
        }
        public override void MethodToExecute()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Version version = assembly.GetName().Version;

            Console.WriteLine(String.Format("Version is: {0}\n", version));
        }
    }
}
