using Spine.Unity;
using UnityEngine;

[RequireComponent(typeof(SkeletonAnimation))]
public class BaseItemDoll : MonoBehaviour
{
    protected SkeletonAnimation _currentSkeleton;


    protected virtual void Init(SkeletonDataAsset dataSkeleton)
    {
        _currentSkeleton.skeletonDataAsset = dataSkeleton;
        _currentSkeleton.Initialize(true);
    }

    protected virtual void OnEnable()
    {
        _currentSkeleton = GetComponent<SkeletonAnimation>();
    }

}
