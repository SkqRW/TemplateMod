global using static CentiTest.Enums;
namespace CentiTest;

public class Enums
{
    public class CreatureTemplateType
    {
        // change Centi to your lizard's name
        public static CreatureTemplate.Type Centi = new(nameof(Centi), true);
        public void UnregisterValues()
        {
            if (Centi != null)
            {
                Centi.Unregister();
                Centi = null;
            }
        }
    }

    public class SandboxUnlockID
    {
        // same as above
        public static MultiplayerUnlocks.SandboxUnlockID Centi = new(nameof(Centi), true);

        public void UnregisterValues()
        {
            if (Centi != null)
            {
                Centi.Unregister();
                Centi = null;
            }
        }
    }
}