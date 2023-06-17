using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Vkgame : MonoBehaviour
{
    public VkBridgeController bridge;

    public void ShowAds()
    {
        bridge.VKWebAppShowNativeAds(new VKWebAppShowNativeAdsStruct
        {
            ad_format = AdFormat.interstitial
        }, AdsResult);

    }

    public void AdsResult(VKWebAppShowNativeAdsResultStruct result)
    {
        var adsIsShow = result.result;
    }
}
