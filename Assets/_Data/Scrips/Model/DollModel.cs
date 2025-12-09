using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;


public class DollModel
{
    public Dictionary<EITEMDOLL, ItemDollModel> dollItems = new();

    public DollModel()
    {
        AddDollItem(EITEMDOLL.BODY, new ItemDollModel(Color.white));
        AddDollItem(EITEMDOLL.BACKHAIR, new ItemDollModel("BackHair34"));
        AddDollItem(EITEMDOLL.HAIR, new ItemDollModel("Hair34"));
        AddDollItem(EITEMDOLL.SUBHAIR, new ItemDollModel("Hair34"));
        AddDollItem(EITEMDOLL.EYE, new ItemDollModel("Eye18"));
        AddDollItem(EITEMDOLL.MOUTH, new ItemDollModel("Mouth0"));
        AddDollItem(EITEMDOLL.SHIRT, new ItemDollModel("Shirt52"));
        AddDollItem(EITEMDOLL.TROUSER, new ItemDollModel("Trousers34"));
        AddDollItem(EITEMDOLL.SHOE, new ItemDollModel("Shoe52"));
    }

    public override String ToString()
    {
        return JsonConvert.SerializeObject(dollItems, Formatting.Indented);
    }


    public virtual void AddDollItem(EITEMDOLL type, ItemDollModel itemDoll)
    {
        dollItems[type] = itemDoll;
    }
}
