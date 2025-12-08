using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI; // Cần thư viện này để gọi ScrollRect

public class BtnChooseList : BaseTouch, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] protected THUMB_DOLL typeDoll;
    [SerializeField] private Text txtLabel;

    // Biến lưu tham chiếu ScrollRect để đỡ phải GetComponent nhiều lần
    private ScrollRect _parentScrollRect;

    private void Awake()
    {
        // Tìm ScrollRect ở các object cha
        _parentScrollRect = GetComponentInParent<ScrollRect>();
    }

    public void SetType(THUMB_DOLL type)
    {
        this.typeDoll = type;
        if (txtLabel != null) txtLabel.text = type.ToString();
    }

    // --- 1. QUAN TRỌNG: CHUYỂN LOGIC TỪ START SANG TAP ---
    // Tuyệt đối không để logic chọn đồ ở OnTouchStart, vì chạm cái nó ăn luôn thì sao mà kịp kéo?
    protected override void OnTap(PointerEventData eventData)
    {
        // Chỉ khi nào Tap (Click nhanh tại chỗ) mới chọn đồ
        GameEvents.OnRequestChangeCategory.Invoke(this.typeDoll);
        Debug.Log($"Đã chọn: {typeDoll}");
    }

    // --- 2. QUAN TRỌNG: TRẢ SỰ KIỆN KÉO VỀ CHO SCROLL VIEW ---

    // Khi bắt đầu kéo
    public void OnBeginDrag(PointerEventData eventData)
    {
        // Nếu có ScrollView cha, hãy bảo nó: "Ê, người dùng đang kéo đấy, mày xử lý đi"
        if (_parentScrollRect != null) _parentScrollRect.OnBeginDrag(eventData);
    }

    // Khi đang kéo (Override lại hàm OnDrag của BaseTouch)
    public override void OnDrag(PointerEventData eventData)
    {
        // Gọi base nếu BaseTouch có logic riêng cần chạy
        base.OnDrag(eventData);

        // Chuyền tiếp cho ScrollView để nó di chuyển danh sách
        if (_parentScrollRect != null) _parentScrollRect.OnDrag(eventData);
    }

    // Khi thả tay ra
    public void OnEndDrag(PointerEventData eventData)
    {
        if (_parentScrollRect != null) _parentScrollRect.OnEndDrag(eventData);
    }
}