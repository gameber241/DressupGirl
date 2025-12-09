using System.Threading.Tasks;
using Spine.Unity;
using UnityEngine;

public class Utils
{
    public static async Task<SkeletonDataAsset> LoadSkeletonDataAsync(string name, string type)
    {
        string path = $"spineassets/{type}/{name}/magic_SkeletonData";
        var request = Resources.LoadAsync<SkeletonDataAsset>(path);
        await Task.Yield();
        while (!request.isDone)
            await Task.Yield();
        var asset = request.asset as SkeletonDataAsset;
        return asset;
    }

    public static async Task<Sprite> LoadSprite(string name, string type)
    {
        string path = $"Thumb/{type}/{name}";
        var request = Resources.LoadAsync<Sprite>(path);
        while (!request.isDone)
        {
            await Task.Yield();
        }
        var result = request.asset as Sprite;
        return result;
    }

    public static Task<Sprite[]> LoadAllSprites(string type)
    {
        string path = $"Thumb/{type}";
        Sprite[] sprites = Resources.LoadAll<Sprite>(path);
        return Task.FromResult(sprites);
    }
}
