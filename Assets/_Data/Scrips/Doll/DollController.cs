using System;
using Spine.Unity;
using UnityEngine;
using DG.Tweening;
using Random = UnityEngine.Random;
using System.Collections;

public class DollController : MonoBehaviour
{
    public BaseItemDoll[] skeletons;

    public String[] animationNames = { "interactive1", "interactive2", "interactive3", "interactive4" };
    public String[] poseName = { "pose1", "pose2", "pose3", "pose4", "pose5", "pose6", "stand" };

    public DollModel dollModel;

    [Header("--- FOCUS SETTINGS ---")]
    [SerializeField] private Vector3 defaultPos = new(0, -3.6f, 0);
    [SerializeField] private Vector3 defaultScale = new(1.3f, 1.3f, 1f);

    [SerializeField] private Vector3 upperBodyPos = new(0, -25f, 0);
    [SerializeField] private Vector3 upperBodyScale = new(3f, 3f, 1f);
    [SerializeField] private float animDuration = 0.5f; // Thời gian zoom (giây)

    void Awake()
    {
        dollModel = new DollModel();
    }

    public async virtual void UpdateItemDoll(EITEMDOLL type, String name)
    {
        if (dollModel.dollItems.ContainsKey(type) == true)
            if (dollModel.dollItems[type]?.name == name) return;
        dollModel.AddDollItem(type, new ItemDollModel(name));
        switch (type)
        {
            case EITEMDOLL.HAIR:
                SkeletonDataAsset dataHair = await Utils.LoadSkeletonDataAsync(name, "Hair");
                string newName = name.Replace("Hair", "BackHair");
                SkeletonDataAsset dataBackHair = await Utils.LoadSkeletonDataAsync(newName, "BackHair");
                skeletons[(int)EITEMDOLL.BACKHAIR].Init(dataBackHair);
                skeletons[(int)EITEMDOLL.HAIR].Init(dataHair);
                skeletons[(int)EITEMDOLL.SUBHAIR].Init(dataHair);

                skeletons[(int)EITEMDOLL.HAIR].gameObject.GetComponent<SkeletonFollow>().Init();
                skeletons[(int)EITEMDOLL.BACKHAIR].gameObject.GetComponent<SkeletonFollow>().Init();
                skeletons[(int)EITEMDOLL.SUBHAIR].gameObject.GetComponent<SkeletonFollow>().Init();

                break;

            case EITEMDOLL.WING:
                SkeletonDataAsset dataWing = await Utils.LoadSkeletonDataAsync(name, "Wing");
                skeletons[(int)EITEMDOLL.WING].Init(dataWing);
                skeletons[(int)EITEMDOLL.WING].gameObject.GetComponent<SkeletonFollow>().Init();

                break;

            case EITEMDOLL.TAIL:
                SkeletonDataAsset dataTail = await Utils.LoadSkeletonDataAsync(name, "Tail");
                skeletons[(int)EITEMDOLL.TAIL].Init(dataTail);
                skeletons[(int)EITEMDOLL.TAIL].gameObject.GetComponent<SkeletonFollow>().Init();

                break;

            case EITEMDOLL.EYE:
                SkeletonDataAsset dataEye = await Utils.LoadSkeletonDataAsync(name, "Eye");
                skeletons[(int)EITEMDOLL.EYE].Init(dataEye);
                skeletons[(int)EITEMDOLL.EYE].gameObject.GetComponent<SkeletonFollow>().Init();

                break;

            case EITEMDOLL.MOUTH:
                SkeletonDataAsset dataMouse = await Utils.LoadSkeletonDataAsync(name, "Mouth");
                skeletons[(int)EITEMDOLL.MOUTH].Init(dataMouse);
                skeletons[(int)EITEMDOLL.MOUTH].gameObject.GetComponent<SkeletonFollow>().Init();

                break;

            case EITEMDOLL.GLASSES:
                SkeletonDataAsset dataGlasses = await Utils.LoadSkeletonDataAsync(name, "Glasses");
                skeletons[(int)EITEMDOLL.GLASSES].Init(dataGlasses);
                skeletons[(int)EITEMDOLL.GLASSES].gameObject.GetComponent<SkeletonFollow>().Init();

                break;

            case EITEMDOLL.DRESS:
                SkeletonDataAsset dataDress = await Utils.LoadSkeletonDataAsync(name, "Dress");
                skeletons[(int)EITEMDOLL.DRESS].Init(dataDress);
                skeletons[(int)EITEMDOLL.SHIRT].Hide();
                skeletons[(int)EITEMDOLL.SHORT_SKIRT].Hide();
                skeletons[(int)EITEMDOLL.TROUSER].Hide();

                skeletons[(int)EITEMDOLL.DRESS].gameObject.GetComponent<SkeletonFollow>().Init();

                break;

            case EITEMDOLL.SHIRT:
                SkeletonDataAsset dataShirt = await Utils.LoadSkeletonDataAsync(name, "Shirt");
                skeletons[(int)EITEMDOLL.SHIRT].Init(dataShirt);
                if (skeletons[(int)EITEMDOLL.DRESS].gameObject.activeSelf == true)
                {
                    skeletons[(int)EITEMDOLL.TROUSER].Show();
                    skeletons[(int)EITEMDOLL.TROUSER].gameObject.GetComponent<SkeletonFollow>().Init();

                }
                skeletons[(int)EITEMDOLL.DRESS].Hide();
                skeletons[(int)EITEMDOLL.SHIRT].gameObject.GetComponent<SkeletonFollow>().Init();

                break;

            case EITEMDOLL.SHORT_SKIRT:
                SkeletonDataAsset dataShortSkirt = await Utils.LoadSkeletonDataAsync(name, "ShortSkirt");
                skeletons[(int)EITEMDOLL.SHORT_SKIRT].Init(dataShortSkirt);

                if (skeletons[(int)EITEMDOLL.DRESS].gameObject.activeSelf == true)
                {
                    skeletons[(int)EITEMDOLL.SHIRT].Show();
                    skeletons[(int)EITEMDOLL.SHIRT].gameObject.GetComponent<SkeletonFollow>().Init();

                }
                skeletons[(int)EITEMDOLL.DRESS].Hide();
                skeletons[(int)EITEMDOLL.TROUSER].Hide();
                skeletons[(int)EITEMDOLL.SHORT_SKIRT].gameObject.GetComponent<SkeletonFollow>().Init();

                break;

            case EITEMDOLL.TROUSER:
                SkeletonDataAsset dataTrouser = await Utils.LoadSkeletonDataAsync(name, "Trousers");
                skeletons[(int)EITEMDOLL.TROUSER].Init(dataTrouser);
                if (skeletons[(int)EITEMDOLL.DRESS].gameObject.activeSelf == true)
                {
                    skeletons[(int)EITEMDOLL.SHIRT].Show();
                    skeletons[(int)EITEMDOLL.SHIRT].gameObject.GetComponent<SkeletonFollow>().Init();

                }
                skeletons[(int)EITEMDOLL.DRESS].Hide();
                skeletons[(int)EITEMDOLL.SHORT_SKIRT].Hide();

                skeletons[(int)EITEMDOLL.TROUSER].gameObject.GetComponent<SkeletonFollow>().Init();

                break;

            case EITEMDOLL.JACKET:
                SkeletonDataAsset dataJacket = await Utils.LoadSkeletonDataAsync(name, "Jacket");
                skeletons[(int)EITEMDOLL.JACKET].Init(dataJacket);
                skeletons[(int)EITEMDOLL.JACKET].gameObject.GetComponent<SkeletonFollow>().Init();

                break;

            case EITEMDOLL.STOCKING:
                SkeletonDataAsset dataStocking = await Utils.LoadSkeletonDataAsync(name, "Stockings");
                skeletons[(int)EITEMDOLL.STOCKING].Init(dataStocking);
                skeletons[(int)EITEMDOLL.STOCKING].gameObject.GetComponent<SkeletonFollow>().Init();

                break;

            case EITEMDOLL.SHOE:
                SkeletonDataAsset dataShoe = await Utils.LoadSkeletonDataAsync(name, "Shoe");
                skeletons[(int)EITEMDOLL.SHOE].Init(dataShoe);
                skeletons[(int)EITEMDOLL.SHOE].gameObject.GetComponent<SkeletonFollow>().Init();

                break;

            case EITEMDOLL.JEWELRY:
                SkeletonDataAsset dataJewelry = await Utils.LoadSkeletonDataAsync(name, "Jewelry");
                skeletons[(int)EITEMDOLL.JEWELRY].Init(dataJewelry);
                skeletons[(int)EITEMDOLL.JEWELRY].gameObject.GetComponent<SkeletonFollow>().Init();

                break;

            case EITEMDOLL.BAG:
                SkeletonDataAsset dataBag = await Utils.LoadSkeletonDataAsync(name, "Bag");
                skeletons[(int)EITEMDOLL.BAG].Init(dataBag);
                skeletons[(int)EITEMDOLL.BAG].gameObject.GetComponent<SkeletonFollow>().Init();

                break;

            case EITEMDOLL.HAT:
                SkeletonDataAsset dataHat = await Utils.LoadSkeletonDataAsync(name, "Hat");
                skeletons[(int)EITEMDOLL.HAT].Init(dataHat);
                skeletons[(int)EITEMDOLL.HAT].gameObject.GetComponent<SkeletonFollow>().Init();

                break;
        }

        PlayRandomAnimation();
    }

    public virtual void UpdateColor(EITEMDOLL type, Color color)
    {
        dollModel.AddDollItem(type, new ItemDollModel(color));

        switch (type)
        {
            case EITEMDOLL.BODY:
                skeletons[(int)EITEMDOLL.BODY].UpdateColor(color);
                skeletons[(int)EITEMDOLL.BODYUP].UpdateColor(color);
                break;
        }
    }

    protected virtual void PlayAnimation(String name)
    {
        skeletons[(int)EITEMDOLL.BODY].PlayAnimation(name);
        skeletons[(int)EITEMDOLL.BODYUP].PlayAnimation(name);
    }

    private bool IsBodyPlayingAnimation()
    {
        var bodySkeletonAnim = skeletons[(int)EITEMDOLL.BODY].GetComponent<SkeletonAnimation>();

        if (bodySkeletonAnim == null) return false;

        var currentTrack = bodySkeletonAnim.AnimationState.GetCurrent(0);

        if (currentTrack != null)
        {
            foreach (var animName in animationNames)
            {
                if (currentTrack.Animation.Name == animName && !currentTrack.IsComplete)
                {
                    return true;
                }
            }
        }

        return false;
    }


    public void PlayRandomAnimation()
    {

        if (IsBodyPlayingAnimation())
        {
            return;
        }

        int randomIndex = Random.Range(1, animationNames.Length);
        PlayAnimation(animationNames[randomIndex]);
    }
    public virtual void PlayPose(EPOSEDOLL type)
    {
        skeletons[(int)EITEMDOLL.BODY].PlayAnimation(poseName[(int)type]);
        skeletons[(int)EITEMDOLL.BODYUP].PlayAnimation(poseName[(int)type]);

    }

    // Hàm xác định loại nào là thân trên
    private bool IsUpperBody(EITEMDOLL type)
    {
        switch (type)
        {
            case EITEMDOLL.HAIR:
            case EITEMDOLL.BACKHAIR:
            case EITEMDOLL.SUBHAIR:
            case EITEMDOLL.EYE:
            case EITEMDOLL.MOUTH:
            case EITEMDOLL.GLASSES:
            case EITEMDOLL.HAT:
            case EITEMDOLL.JEWELRY:
            case EITEMDOLL.SHIRT:
            case EITEMDOLL.JACKET:
                return true;

            default:
                return false;
        }
    }

    // Hàm thực hiện Zoom/Move bằng DOTween
    public void SwitchView(EITEMDOLL type)
    {
        bool isUpper = IsUpperBody(type);
        Vector3 targetPos = isUpper ? upperBodyPos : defaultPos;
        Vector3 targetScale = isUpper ? upperBodyScale : defaultScale;
        transform.DOKill();
        transform.DOLocalMove(targetPos, animDuration).SetEase(Ease.OutCubic);

        transform.DOScale(targetScale, animDuration).SetEase(Ease.OutCubic);
    }
}
