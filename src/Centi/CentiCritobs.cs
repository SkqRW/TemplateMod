using Fisobs.Creatures;
using Fisobs.Core;
using Fisobs.Sandbox;
using UnityEngine;
using System.Collections.Generic;
using DevInterface;

using static PathCost.Legality;

namespace CentiTest;

public class CentiCritob : Critob
{
    public CentiCritob() : base(Enums.CreatureTemplateType.Centi)
    {
        LoadedPerformanceCost = 50f;
        SandboxPerformanceCost = new(.25f, .25f);
        // unlock stuff
        RegisterUnlock(KillScore.Configurable(1), SandboxUnlockID.Centi, parent: MultiplayerUnlocks.SandboxUnlockID.Slugcat, data: 0);
    }

    public override ArtificialIntelligence CreateRealizedAI(AbstractCreature acrit) => new CentipedeAI(acrit, acrit.world);

    public override Creature CreateRealizedCreature(AbstractCreature acrit) => new Centi(acrit, acrit.world);

        public override int ExpeditionScore() => 29;

         public override IEnumerable<string> WorldFileAliases() => ["centi"];


    public override Color DevtoolsMapColor(AbstractCreature acrit) => Color.red;

    public override string DevtoolsMapName(AbstractCreature acrit) => "Centi";

    public override IEnumerable<RoomAttractivenessPanel.Category> DevtoolsRoomAttraction() => [RoomAttractivenessPanel.Category.LikesInside];

    // copyaste red horror
    public override CreatureTemplate CreateTemplate()
    {
        var t = new CreatureFormula(Enums.CreatureTemplateType.Centi, Type, "Centi")
        {
            TileResistances = new()
            {
                OffScreen = new(1f, Allowed),
                Floor = new(1f, Allowed),
                Corridor = new(1f, Allowed),
                Climb = new(1f, Allowed),
                Wall = new(1f, Allowed),
                Ceiling = new(1f, Allowed),
                Air = new(1f, Allowed)
            },
            ConnectionResistances = new()
            {
                Standard = new(1f, Allowed),
                OpenDiagonal = new(3f, Allowed),
                ReachOverGap = new(3f, Allowed),
                DoubleReachUp = new(2f, Allowed),
                SemiDiagonalReach = new(2f, Allowed),
                NPCTransportation = new(25f, Allowed),
                OffScreenMovement = new(1f, Allowed),
                BetweenRooms = new(10f, Allowed),
                Slope = new(1.5f, Allowed),
                DropToFloor = new(5f, Allowed),
                DropToClimb = new(5f, Allowed),
                ShortCut = new(1f, Allowed),
                ReachUp = new(1.1f, Allowed),
                ReachDown = new(1.1f, Allowed),
                CeilingSlope = new(2f, Allowed)
            },
            DefaultRelationship = new(CreatureTemplate.Relationship.Type.Eats, 1f),
            DamageResistances = new() { Base = 1f, Electric = 102f },
            StunResistances = new() { Base = .75f, Electric = 102f },
            HasAI = true,
            Pathing = PreBakedPathing.Ancestral(CreatureTemplate.Type.BlueLizard)
        }.IntoTemplate();
        t.canFly = true;
        t.dangerousToPlayer = 1f;
        t.visualRadius = 1200f;
        t.offScreenSpeed = .45f;
        t.abstractedLaziness = 50;
        t.waterVision = .6f;
        t.lungCapacity = 1100f;
        return t;
    }
    public override void EstablishRelationships()
    {
        var s = new Relationships(Type);
        s.IsInPack(CreatureTemplate.Type.Slugcat, .1f);
    }

    public override void LoadResources(RainWorld rainWorld) { }

    public override CreatureState CreateState(AbstractCreature acrit) => new Centipede.CentipedeState(acrit);

    public override CreatureTemplate.Type? ArenaFallback() => CreatureTemplate.Type.PinkLizard;
}