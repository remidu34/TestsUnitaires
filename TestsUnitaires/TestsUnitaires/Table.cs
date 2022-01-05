namespace TestsUnitaires
{
    public class Table
    {
        public bool EstLibre { get; private set; } = true;

        public void InstallerClient()
        {
            if (!EstLibre) throw new InvalidOperationException();
            EstLibre = false;
        }

        public void Libérer()
        {
            EstLibre = true;
        }
    }
}
