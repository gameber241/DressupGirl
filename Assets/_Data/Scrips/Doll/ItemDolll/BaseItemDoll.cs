using Spine.Unity;
using UnityEngine;

[RequireComponent(typeof(SkeletonAnimation))]
public class BaseItemDoll : MonoBehaviour
{
    [SerializeField] protected EITEMDOLL typeDoll;
    protected SkeletonAnimation _currentSkeleton;

    protected virtual void Awake()
    {

    }
    public virtual void Init(SkeletonDataAsset dataSkeleton)
    {
        gameObject.SetActive(true);
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
        gameObject.SetActive(false);
    }

}
