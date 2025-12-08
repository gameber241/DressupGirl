using System;
using System.Collections.Generic;
using Newtonsoft.Json;

public class DollModel
{
    public Dictionary<EITEMDOLL, ItemDollModel> dollItems = new();


    public override String ToString()
    {
        return JsonConvert.SerializeObject(dollItems, Formatting.Indented);
    }


    public virtual void AddDollItem(EITEMDOLL type, ItemDollModel itemDoll)
    {
        dollItems[type] = itemDoll;
    }
}
