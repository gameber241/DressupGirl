using System;
using Spine.Unity;
using UnityEngine;

public class DollController : MonoBehaviour
{
    public BaseItemDoll[] skeletons;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        UpdateItemDoll(EITEMDOLL.WING, "Wing0");
        UpdateItemDoll(EITEMDOLL.TAIL, "Tail10");
        UpdateColor(EITEMDOLL.BODY, Color.black);
    }

    protected async virtual void UpdateItemDoll(EITEMDOLL type, String name)
    {

        switch (type)
        {
            case EITEMDOLL.HAIR:
                SkeletonDataAsset dataHair = await Utils.LoadSkeletonDataAsync(name, "Hair");
                string newName = name.Replace("Hair", "BackHair");
                SkeletonDataAsset dataBackHair = await Utils.LoadSkeletonDataAsync(newName, "BackHair");
                skeletons[(int)EITEMDOLL.BACKHAIR].Init(dataBackHair);
                skeletons[(int)EITEMDOLL.HAIR].Init(dataHair);
                skeletons[(int)EITEMDOLL.SUBHAIR].Init(dataHair);
                break;

            case EITEMDOLL.WING:
                SkeletonDataAsset dataWing = await Utils.LoadSkeletonDataAsync(name, "Wing");
                skeletons[(int)EITEMDOLL.WING].Init(dataWing);
                break;

            case EITEMDOLL.TAIL:
                SkeletonDataAsset dataTail = await Utils.LoadSkeletonDataAsync(name, "Tail");
                skeletons[(int)EITEMDOLL.TAIL].Init(dataTail);
                break;

            case EITEMDOLL.EYE:
                SkeletonDataAsset dataEye = await Utils.LoadSkeletonDataAsync(name, "Eye");
                skeletons[(int)EITEMDOLL.EYE].Init(dataEye);
                break;

            case EITEMDOLL.MOUSE:
                SkeletonDataAsset dataMouse = await Utils.LoadSkeletonDataAsync(name, "Mouse");
                skeletons[(int)EITEMDOLL.MOUSE].Init(dataMouse);
                break;

            case EITEMDOLL.GLASSES:
                SkeletonDataAsset dataGlasses = await Utils.LoadSkeletonDataAsync(name, "Glasses");
                skeletons[(int)EITEMDOLL.GLASSES].Init(dataGlasses);
                break;

            case EITEMDOLL.DRESS:
                SkeletonDataAsset dataDress = await Utils.LoadSkeletonDataAsync(name, "Dress");
                skeletons[(int)EITEMDOLL.GLASSES].Init(dataDress);
                skeletons[(int)EITEMDOLL.SHIRT].Hide();
                skeletons[(int)EITEMDOLL.SHORT_SKIRT].Hide();
                skeletons[(int)EITEMDOLL.TROUSER].Hide();
                break;

            case EITEMDOLL.SHIRT:
                SkeletonDataAsset dataShirt = await Utils.LoadSkeletonDataAsync(name, "Shirt");
                skeletons[(int)EITEMDOLL.SHIRT].Init(dataShirt);
                if (skeletons[(int)EITEMDOLL.DRESS].gameObject.activeSelf == true)
                {
                    skeletons[(int)EITEMDOLL.TROUSER].Show();
                }
                skeletons[(int)EITEMDOLL.DRESS].Hide();
                break;

            case EITEMDOLL.SHORT_SKIRT:
                SkeletonDataAsset dataShortSkirt = await Utils.LoadSkeletonDataAsync(name, "ShortSkirt");
                skeletons[(int)EITEMDOLL.SHIRT].Init(dataShortSkirt);

                if (skeletons[(int)EITEMDOLL.DRESS].gameObject.activeSelf == true)
                {
                    skeletons[(int)EITEMDOLL.SHIRT].Show();
                }
                skeletons[(int)EITEMDOLL.DRESS].Hide();
                skeletons[(int)EITEMDOLL.TROUSER].Hide();
                break;

            case EITEMDOLL.TROUSER:
                SkeletonDataAsset dataTrouser = await Utils.LoadSkeletonDataAsync(name, "Trouser");
                skeletons[(int)EITEMDOLL.TROUSER].Init(dataTrouser);
                if (skeletons[(int)EITEMDOLL.DRESS].gameObject.activeSelf == true)
                {
                    skeletons[(int)EITEMDOLL.SHIRT].Show();
                }
                skeletons[(int)EITEMDOLL.DRESS].Hide();
                skeletons[(int)EITEMDOLL.SHORT_SKIRT].Hide();
                break;

            case EITEMDOLL.JACKET:
                SkeletonDataAsset dataJacket = await Utils.LoadSkeletonDataAsync(name, "Jacket");
                skeletons[(int)EITEMDOLL.JACKET].Init(dataJacket);
                break;

            case EITEMDOLL.STOCKING:
                SkeletonDataAsset dataStocking = await Utils.LoadSkeletonDataAsync(name, "Stocking");
                skeletons[(int)EITEMDOLL.STOCKING].Init(dataStocking);
                break;

            case EITEMDOLL.SHOE:
                SkeletonDataAsset dataShoe = await Utils.LoadSkeletonDataAsync(name, "Shoe");
                skeletons[(int)EITEMDOLL.SHOE].Init(dataShoe);
                break;

            case EITEMDOLL.JEWELRY:
                SkeletonDataAsset dataJewelry = await Utils.LoadSkeletonDataAsync(name, "Jewelry");
                skeletons[(int)EITEMDOLL.JEWELRY].Init(dataJewelry);
                break;

            case EITEMDOLL.BAG:
                SkeletonDataAsset dataBag = await Utils.LoadSkeletonDataAsync(name, "Bag");
                skeletons[(int)EITEMDOLL.BAG].Init(dataBag);
                break;

            case EITEMDOLL.HAT:
                SkeletonDataAsset dataHat = await Utils.LoadSkeletonDataAsync(name, "Hat");
                skeletons[(int)EITEMDOLL.HAT].Init(dataHat);
                break;
        }
    }

    protected virtual void UpdateColor(EITEMDOLL type, Color color)
    {
        switch (type)
        {
            case EITEMDOLL.BODY:
                skeletons[(int)EITEMDOLL.BODY].UpdateColor(color);
                break;
        }
    }
}
