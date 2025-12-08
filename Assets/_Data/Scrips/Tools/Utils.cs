using System.Threading.Tasks;
using Spine.Unity;
using UnityEngine;

public class Utils
{
    public static async Task<SkeletonDataAsset> LoadSkeletonDataAsync(string name, string type)
    {
        string path = $"spineassets/{type}/{name}/magic_SkeletonData";
        var request = Resources.LoadAsync<SkeletonDataAsset>(path);

        await Task.Yield(); // Đảm bảo không block main thread

        while (!request.isDone)
            await Task.Yield();

        var asset = request.asset as SkeletonDataAsset;

        if (asset == null)
            Debug.LogError($"❌ Không load được SkeletonDataAsset: {path}");

        return asset;
    }

}
