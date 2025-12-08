using Spine.Unity;
using UnityEngine;

public class EditDollUI : MonoBehaviour
{

    [SerializeField] protected GameObject dollPrefab;

    [SerializeField] protected Transform dolls;



    void Awake()
    {

    }


    public virtual void CreateDoll()
    {
        var dollsLocale = LocaleStorage.GetDolls();
        if (dollsLocale.Length == 0)
        {
            var doll = Instantiate(dollPrefab);
            doll.transform.SetParent(dolls);
        }
    }
}
