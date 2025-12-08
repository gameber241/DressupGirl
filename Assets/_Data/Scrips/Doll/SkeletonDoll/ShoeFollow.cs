using UnityEngine;

public class ShoeFollow : SkeletonFollow
{
    protected override void Update()
    {
        if (_master == null) return;
        foreach (var masterBone in _master.Bones)
        {
            var shoeBone = _skeletonCurrent.FindBone(masterBone.Data.Name);
            if (shoeBone == null || shoeBone.Parent == null) continue;

            // World pos của masterBone
            float worldX = masterBone.WorldX;
            float worldY = masterBone.WorldY;

            // Convert World -> Local theo parent của shoeBone
            shoeBone.Parent.WorldToLocal(worldX, worldY, out float localX, out float localY);

            shoeBone.X = localX;
            shoeBone.Y = localY;

            // Rotation world
            shoeBone.Rotation = masterBone.WorldRotationX;

            // Copy world scale
            shoeBone.ScaleX = masterBone.WorldScaleX;
            shoeBone.ScaleY = masterBone.WorldScaleY;
        }

    }
}
