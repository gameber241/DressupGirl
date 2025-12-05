using Spine.Unity;
using UnityEngine;

public class SubHairDoll : BaseItemDoll
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Init(SkeletonDataAsset dataSkeleton)
    {
        base.Init(dataSkeleton);
        _currentSkeleton.Skeleton.SetAttachment("bang", null);

    }

    protected override void OnEnable()
    {
        base.OnEnable();
        _currentSkeleton.Skeleton.SetAttachment("bang", null);

    }
}
