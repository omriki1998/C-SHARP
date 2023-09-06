
namespace Ex03
{
    internal class FuelMotorcycle : Motorcycle
    {
        protected const float k_MaximumFuelCapacityLitres = 6.2f;

        internal FuelMotorcycle(string i_LicensePlate) : base(i_LicensePlate)
        {
            Engine = new FuelEngine(k_MaximumFuelCapacityLitres);
            AddKeyValPairsToDict(m_Enigne.r_QuestionsToCreateNewEngine);
        }
    }
}
