using UnityEngine;

namespace CentiTest;

public class Centi : Centipede
{
    public Centi(AbstractCreature abstractCreature, World world) : base(abstractCreature, world)
    {
        size = GenerateSize();
        bites = 4;
        bodyChunks = new BodyChunk[(int)Mathf.Lerp(7, 17, size)];

    }

    /// <summary>
    /// Values from [0, 1]
    /// 0 for mini centipede
    /// 1 for full size as red
    /// not limited to 1, example, aquapede can use 1.8
    /// </summary>
    /// <returns></returns>
    private static float GenerateSize()
    {
        return Mathf.Lerp(0.6f, 1f, Random.value);
    }

    public override void InitiateGraphicsModule() => graphicsModule = new CentiGraphics(this);
}