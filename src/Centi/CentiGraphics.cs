using RWCustom;
using UnityEngine;

namespace CentiTest;

public class CentiGraphics : CentipedeGraphics
{
    public CentiGraphics(PhysicalObject ow) : base(ow)
    {
        
    }

    public override void ApplyPalette(RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, RoomPalette palette)
    {
        if (this.centipede.Glower != null)
		{
			this.centipede.Glower.color = Color.Lerp(new Color(palette.waterColor1.r, palette.waterColor1.g, palette.waterColor1.b, 1f), new Color(0.7f, 0.7f, 1f, 1f), 0.25f);
		}
		this.blackColor = palette.blackColor;
		for (int i = 0; i < sLeaser.sprites.Length; i++)
		{
			sLeaser.sprites[i].color = this.blackColor;
		}
		for (int j = 0; j < this.totalSecondarySegments; j++)
		{
			sLeaser.sprites[this.SecondarySegmentSprite(j)].color = Color.Lerp(Color.white, this.blackColor, Mathf.Lerp(0.4f, 1f, this.darkness));
		}


        for (int k = 0; k < base.owner.bodyChunks.Length; k++)
		{
			for (int l = 0; l < 2; l++)
			{
				(sLeaser.sprites[this.LegSprite(k, l, 1)] as VertexColorSprite).verticeColors[0] = Color.yellow;
				(sLeaser.sprites[this.LegSprite(k, l, 1)] as VertexColorSprite).verticeColors[1] = Color.yellow;
				(sLeaser.sprites[this.LegSprite(k, l, 1)] as VertexColorSprite).verticeColors[2] = Color.blue;
				(sLeaser.sprites[this.LegSprite(k, l, 1)] as VertexColorSprite).verticeColors[3] = Color.blue;
			}
		}
    }
    

    public override void DrawSprites(RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float timeStacker, Vector2 camPos)
    {
        base.DrawSprites(sLeaser, rCam, timeStacker, camPos);
		for (int i = 0; i < base.owner.bodyChunks.Length; i++)
		{
			sLeaser.sprites[this.ShellSprite(i, 0)].color = rCam.PixelColorAtCoordinate(base.owner.bodyChunks[i].pos);
		}
    }

}