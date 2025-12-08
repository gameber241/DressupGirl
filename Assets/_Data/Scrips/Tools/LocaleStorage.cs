using System.Collections.Generic;
using UnityEngine;

public class LocaleStorage : MonoBehaviour
{
    public static void SaveDolls(DollModel dollModel)
    {
        var dolls = GetDolls();
        List<DollModel> list = new List<DollModel>(dolls);
        list.Add(dollModel);

        PlayerPrefs.SetString("Dolls", JsonUtility.ToJson(list.ToArray()));
    }

    public static DollModel[] GetDolls()
    {
        if (!PlayerPrefs.HasKey("Dolls"))
            return new DollModel[0];

        string json = PlayerPrefs.GetString("Dolls");
        return JsonUtility.FromJson<DollModel[]>(json);
    }
}
