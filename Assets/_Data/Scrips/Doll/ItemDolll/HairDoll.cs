using Spine.Unity;
using UnityEngine;

public class HairDoll : BaseItemDoll
{
    
    public override void Init(SkeletonDataAsset dataSkeleton)
    {
        base.Init(dataSkeleton);
        _currentSkeleton.Skeleton.SetAttachment("hairback", null);

    }

    protected override void OnEnable()
    {
        base.OnEnable();
        _currentSkeleton.Skeleton.SetAttachment("hairback", null);

    }

}
