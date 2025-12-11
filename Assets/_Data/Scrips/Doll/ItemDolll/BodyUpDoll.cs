using Spine.Unity;
using UnityEngine;

public class BodyUpDoll : BaseItemDoll
{
    void Reset()
    {
        typeDoll = EITEMDOLL.BODYUP;
        _currentSkeleton = GetComponent<SkeletonAnimation>();
        HideHands();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Init(SkeletonDataAsset dataSkeleton)
    {
        base.Init(dataSkeleton);
        HideHands();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        HideHands();
    }

    void HideSlot(string slotName)
    {
        var slot = _currentSkeleton.Skeleton.FindSlot(slotName);
        if (slot != null)
        {
            slot.A = 0f; // alpha = 0 → ẩn hoàn toàn
        }
    }

    // Gọi ẩn tất cả các slot tay trái + tay phải
    void HideHands()
    {
        HideSlot("head");
        HideSlot("body");
        HideSlot("legR");
        HideSlot("legL");
        HideSlot("armR_up");
        HideSlot("armL_up");
    }
}
