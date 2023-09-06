using System.Linq;

namespace Ex03
{
    internal class FuelCar : Car
    {
        protected const float k_MaximumFuelCapacityLitres = 44;

        internal FuelCar(string i_LicensePlate)
           : base(i_LicensePlate)  
        {
            Engine = new FuelEngine(k_MaximumFuelCapacityLitres);
            AddKeyValPairsToDict(m_Enigne.r_QuestionsToCreateNewEngine);
        }
    }
}
