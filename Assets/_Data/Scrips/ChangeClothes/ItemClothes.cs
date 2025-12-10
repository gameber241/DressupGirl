using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemClothes : BaseTouch, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] protected GameObject bgSelect;
    [SerializeField] protected Image iconClothes;
    [SerializeField] protected Image colorImg;
    [SerializeField] protected GameObject star;

    protected EITEMDOLL typeClothes;
    protected String nameClothes;
    protected Color colorClothes;


    bool isButtonColor = false;
    public virtual void Init(Sprite icon, EITEMDOLL type, String name)
    {
        nameClothes = name;
        typeClothes = type;
        iconClothes.sprite = icon;
        iconClothes.gameObject.SetActive(true);
    }

    public virtual void InitColor(EITEMDOLL type, Color color)
    {
        typeClothes = type;
        isButtonColor = true;
        colorImg.color = color;
        colorImg.gameObject.SetActive(true);
        colorClothes = color;
    }

    public virtual void Follow()
    {
        ChangeClothesController.Instance.HideListItemClothes();
        bgSelect.SetActive(true);
        star.SetActive(true);
    }

    public virtual void UnFollow()
    {
        bgSelect.SetActive(false);
        star.SetActive(false);
    }

    private ScrollRect _parentScrollRect;
    private void Awake()
    {
        _parentScrollRect = GetComponentInParent<ScrollRect>();

    }

    protected override void OnTap(PointerEventData eventData)
    {
        Follow();
        if (isButtonColor == false)
            ChangeClothesController.Instance.currentDoll.UpdateItemDoll(typeClothes, nameClothes);
        else
            ChangeClothesController.Instance.currentDoll.UpdateColor(typeClothes, colorClothes);
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
