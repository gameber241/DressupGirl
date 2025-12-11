using UnityEngine;
using UnityEngine.UI;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using DG.Tweening; // Để dùng Enum

public class ChangeClothesController : MonoBehaviour
{

    public static ChangeClothesController Instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public ScrollRect listButton;
    public ScrollRect pageClothes;

    [SerializeField] protected DataClothes dataClothes;
    [SerializeField] protected BtnChooseList btnChooseList;
    [SerializeField] protected ItemClothes itemClothes;
    [SerializeField] protected DataColorHairs dataColorHairs;

    public List<BtnChooseList> listBtnChooseClothes;
    public List<ItemClothes> listItemClothes;

    [SerializeField] public DollController currentDoll;

    [SerializeField] private Transform leftObj;
    [SerializeField] private Transform rightObj;
    [SerializeField] private Transform headObj;
    [SerializeField] private Transform changeClothes;
    [SerializeField] private GameObject UIPhoTo;
    private void Awake()
    {
        Instance = this;
        listBtnChooseClothes = new();
        this.LoadAssetListButtonClothes();
    }

    private void LoadAssetListButtonClothes()
    {

        for (int i = 0; i < dataClothes.listThumbnailClothes.Length; i++)
        {
            var model = dataClothes.listThumbnailClothes[i];
            BtnChooseList btn = Instantiate(btnChooseList, listButton.content);
            btn.Init(model);
            if (i == dataClothes.listThumbnailClothes.Length - 1)
            {
                btn.HideLine();
            }
            listBtnChooseClothes.Add(btn);
        }

        listBtnChooseClothes[0].Follow();
    }


    public virtual void HideBtnClothes()
    {
        foreach (var item in listBtnChooseClothes)
        {
            item.UnFollow();

        }
    }

    // Hàm này phải khớp tham số với Event (nhận vào THUMB_DOLL)
    public async void LoadAndSpawnClothesFromResource(BtnChooseList btn)
    {

        ClearChildren(pageClothes.content);
        listItemClothes.Clear();
        if (btn.thumbModels.type == EITEMDOLL.BODY)
        {
            foreach (Color sp in dataColorHairs.colors)
            {
                var item = Instantiate(itemClothes, pageClothes.content);
                listItemClothes.Add(item);
                item.InitColor(btn.thumbModels.type, sp);
            }
        }
        else
        {
            var sprites = await Utils.LoadAllSprites(btn.thumbModels.name);
            string nameClothes = "";

            if (currentDoll.dollModel.dollItems.TryGetValue(btn.thumbModels.type, out var dollItem))
            {
                nameClothes = dollItem.name;
            }

            foreach (Sprite sp in sprites)
            {
                var item = Instantiate(itemClothes, pageClothes.content);
                listItemClothes.Add(item);

                item.Init(sp, btn.thumbModels.type, sp.name);

                if (nameClothes == sp.name)
                {
                    item.Follow();
                }
            }
        }

    }

    public virtual void HideListItemClothes()
    {
        foreach (var item in listItemClothes)
        {
            item.UnFollow();

        }
    }
    public static void ClearChildren(Transform parent)
    {
        foreach (Transform child in parent)
        {
            Destroy(child.gameObject);
        }
    }

    public virtual void BtnPhoto()
    {
        ShowUIPhoto();
    }


    private void ShowUIPhoto()
    {
        rightObj.DOLocalMove(rightObj.localPosition + new Vector3(500f, 0f, 0f), 1f).SetEase(Ease.InOutBack)
                .OnComplete(() => { rightObj.gameObject.SetActive(false); });

        leftObj.DOLocalMove(leftObj.localPosition + new Vector3(-500f, 0f, 0f), 1f).SetEase(Ease.InOutBack)
                .OnComplete(() => { rightObj.gameObject.SetActive(false); });

        headObj.DOLocalMove(headObj.localPosition + new Vector3(0f, 700f, 0f), 1f).SetEase(Ease.InOutBack)
                .OnComplete(() => { headObj.gameObject.SetActive(false); });

        changeClothes.DOLocalMove(changeClothes.localPosition + new Vector3(0f, -700f, 0f), 1f).SetEase(Ease.InOutBack)
                .OnComplete(() =>
                {
                    changeClothes.gameObject.SetActive(false);
                    UIPhoTo.SetActive(true);
                });



    }

}
