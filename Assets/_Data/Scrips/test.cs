using Spine;
using Spine.Unity;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField] SkeletonAnimation x;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        ApplyPart(GetComponent<SkeletonAnimation>(), x, "bag", "bag71001401");
    }
    public void ApplyPart(SkeletonAnimation sourceAnim, SkeletonAnimation xAnim, string slotName, string attachmentName)
    {
        Skeleton source = sourceAnim.Skeleton;  // nhân vật chính
        Skeleton target = xAnim.Skeleton;       // item

        // 1. Lấy attachment từ skeleton X
        Attachment attX = target.GetAttachment(slotName, attachmentName);
        if (attX == null)
        {
            Debug.LogError("Không tìm thấy attachment trong skeleton X: " + attachmentName);
            return;
        }

        // 2. Lấy slot của source
        Slot slotSource = source.FindSlot(slotName);
        if (slotSource == null)
        {
            Debug.LogError("Slot không tồn tại trong skeleton source: " + slotName);
            return;
        }

        // 3. Gán trực tiếp attachment vào source (nếu dùng chung atlas)
        slotSource.Attachment = attX;

        // 4. Update pose
        source.SetSlotsToSetupPose();
        sourceAnim.AnimationState.Apply(source);
        sourceAnim.Update(0);
    }

}
