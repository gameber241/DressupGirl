using System;
using Spine.Unity;
using UnityEngine;

[RequireComponent(typeof(SkeletonAnimation))]
public class BaseItemDoll : MonoBehaviour
{
    [SerializeField] protected EITEMDOLL typeDoll;
    protected SkeletonAnimation _currentSkeleton;

    // protected virtual void Awake()
    // {
    //     // _currentSkeleton = GetComponent<SkeletonAnimation>();
    //     // _currentSkeleton.Skeleton.SetAttachment("bang", null);

    // }
    public virtual void Init(SkeletonDataAsset dataSkeleton)
    {

        gameObject.SetActive(true);
        _currentSkeleton = GetComponent<SkeletonAnimation>();
        _currentSkeleton.skeletonDataAsset = dataSkeleton;
        _currentSkeleton.Initialize(true);
    }

    protected virtual void OnEnable()
    {
        _currentSkeleton = GetComponent<SkeletonAnimation>();

    }


    public virtual void UpdateColor(Color color)
    {
        _currentSkeleton.skeleton.SetColor(color);
    }

    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }

    public virtual void Show()
    {
        gameObject.SetActive(true);
    }

    public virtual void PlayAnimation(String name)
    {

        _currentSkeleton.state.SetAnimation(0, name, false);
    }


}
