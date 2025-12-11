using System;
using UnityEngine;

public class BtnPose : MonoBehaviour
{
    [SerializeField] protected EPOSEDOLL type;

    public virtual void OnClick()
    {
        ChangeClothesController.Instance.currentDoll.PlayPose(type);
    }
}
