using Spine.Unity;
using UnityEngine;

public class BodyDoll : BaseItemDoll
{
    void Reset()
    {
        typeDoll = EITEMDOLL.BODY;
        _currentSkeleton = GetComponent<SkeletonAnimation>();
        HideHands();
    }
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

    // Hàm ẩn slot
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
        HideSlot("handR");
        HideSlot("armR_down");
        HideSlot("handR1");
        HideSlot("handR2");
        HideSlot("handR3");
        HideSlot("handR4");

        HideSlot("handL4");
        HideSlot("handL3");
        HideSlot("handL2");
        HideSlot("handL1");
        HideSlot("handL5");
        HideSlot("handL");
        HideSlot("armL_down");
    }

}
