using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI; // Cần thư viện này để gọi ScrollRect

[RequireComponent(typeof(Toggle))]
public class BtnChooseList : BaseTouch, IBeginDragHandler, IEndDragHandler
{
    public ThumbnailClothesModel thumbModels;

    [SerializeField] protected Image iconThumbnail;

    [SerializeField] protected GameObject line;
    [SerializeField] protected GameObject bgFollow;

    [SerializeField] protected GameObject bgUnFollow;

    public virtual void HideLine()
    {
        line.SetActive(false);
    }

    public virtual void Init(ThumbnailClothesModel model)
    {
        thumbModels = model;
        iconThumbnail.sprite = model.imageIcon;
        UnFollow();

    }



    public virtual void Follow()
    {
        ChangeClothesController.Instance.HideBtnClothes();
        bgFollow.SetActive(true);
        ChangeClothesController.Instance.LoadAndSpawnClothesFromResource(this);
    }

    public virtual void UnFollow()
    {
        bgFollow.SetActive(false);
        bgUnFollow.SetActive(true);
    }


    // [SerializeField] protected THUMB_DOLL typeDoll;
    // [SerializeField] private Text txtLabel;

    private ScrollRect _parentScrollRect;

    private void Awake()
    {
        _parentScrollRect = GetComponentInParent<ScrollRect>();
    }

    protected override void OnTap(PointerEventData eventData)
    {
        Follow();

    }

    public override void OnBeginDrag(PointerEventData eventData)
    {

        if (_parentScrollRect != null) _parentScrollRect.OnBeginDrag(eventData);
    }

    public override void OnDrag(PointerEventData eventData)
    {

        base.OnDrag(eventData);


        if (_parentScrollRect != null) _parentScrollRect.OnDrag(eventData);
    }

    // Khi thả tay ra
    public override void OnEndDrag(PointerEventData eventData)
    {
        if (_parentScrollRect != null) _parentScrollRect.OnEndDrag(eventData);
    }
}