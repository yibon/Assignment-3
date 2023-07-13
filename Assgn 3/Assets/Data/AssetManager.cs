// UXG2520 & UXG2165 Assignment 3
// Team Name: Lavon
// File Name: AssetManager.cs
// Author: Yvonne Lim

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public static class AssetManager
{
    private static string imagePath = "Assets/Sprites/{0}";

    public static void LoadSprite(string spriteName, System.Action<Sprite> onLoaded)
    {
        Addressables.LoadAssetAsync<Sprite>(string.Format(imagePath, spriteName)).Completed += (loadedSprite) =>
        {
            onLoaded?.Invoke(loadedSprite.Result);
        };
    }
}
