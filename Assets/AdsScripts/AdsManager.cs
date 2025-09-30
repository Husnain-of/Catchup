// // using System.Collections;
// // using System.Collections.Generic;
// // using UnityEngine;

// // public class AdsManager : MonoBehaviour
// // {
// //     public InitializeAds initializeAds;
// //     public BannerAds bannerAds;
// //     public InterstitialAds interstitialAds;
// //     public RewardedAds rewardedAds;

// //     public static AdsManager Instance { get; private set; }



// //     private void Awake()
// //     {
// //         if (Instance != null && Instance != this)
// //         {
// //             Destroy(gameObject);
// //             return;
// //         }
// //         Instance = this;
// //         DontDestroyOnLoad(gameObject);


// //         bannerAds.LoadBannerAd();
// //         interstitialAds.LoadInterstitialAd();
// //         rewardedAds.LoadRewardedAd();


// //     }
// // }










// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class AdsManager : MonoBehaviour
// {
//     public InitializeAds initializeAds;
//     public BannerAds bannerAds;
//     public InterstitialAds interstitialAds;
//     public RewardedAds rewardedAds;

//     public static AdsManager Instance { get; private set; }

//     private void Awake()
//     {
//         if (Instance != null && Instance != this)
//         {
//             Destroy(gameObject);
//             return;
//         }

//         Instance = this;
//         DontDestroyOnLoad(gameObject);

//         // ✅ Sab ads pehle load karo
//         bannerAds.LoadBannerAd();
//         interstitialAds.LoadInterstitialAd();
//         rewardedAds.LoadRewardedAd();
//     }

//     private void Start()
//     {
//         // ✅ Scene start hote hi banner show karo
//         if (bannerAds != null)
//         {
//             bannerAds.ShowBannerAd();
//         }
//     }
// }










// using System.Collections;
// using UnityEngine;
// using UnityEngine.Advertisements;

// public class AdsManager : MonoBehaviour
// {
//     [Header("Unity Ads Game ID")]
//     [SerializeField] private string androidGameId = "5955409";   // apna Android Game ID
//     [SerializeField] private string iosGameId = "5955408";       // apna iOS Game ID
//     [SerializeField] private bool testMode = true;

//     [Header("Ad Unit IDs")]
//     [SerializeField] private string bannerAdUnitId = "Banner_Android";       // apna Banner ID
//     [SerializeField] private string interstitialAdUnitId = "Interstitial_Android"; // apna Interstitial ID

//     public static AdsManager Instance { get; private set; }

//     private void Awake()
//     {
//         if (Instance != null && Instance != this)
//         {
//             Destroy(gameObject);
//             return;
//         }

//         Instance = this;
//         DontDestroyOnLoad(gameObject);

// #if UNITY_ANDROID
//         Advertisement.Initialize(androidGameId, testMode);
// #elif UNITY_IOS
//         Advertisement.Initialize(iosGameId, testMode);
// #endif
//     }

//     private void Start()
//     {
//         // ✅ Scene start hote hi banner show
//         ShowBannerAd();

//         // ✅ Interstitial preload
//         LoadInterstitialAd();
//     }

//     // ===============================
//     // ✅ Banner Ads
//     // ===============================
//     public void ShowBannerAd()
//     {
//         Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
//         Advertisement.Banner.Show(bannerAdUnitId);
//         Debug.Log("✅ Banner Ad Requested.");
//     }

//     public void HideBannerAd()
//     {
//         Advertisement.Banner.Hide();
//     }

//     // ===============================
//     // ✅ Interstitial Ads
//     // ===============================
//     public void LoadInterstitialAd()
//     {
//         Debug.Log("Loading Interstitial Ad...");
//         Advertisement.Load(interstitialAdUnitId);
//     }

//     public void ShowInterstitialAd()
//     {
//         if (Advertisement.isInitialized)
//         {
//             Debug.Log("✅ Showing Interstitial Ad...");
//             Advertisement.Show(interstitialAdUnitId);
//             LoadInterstitialAd(); // show ke baad dobara load
//         }
//         else
//         {
//             Debug.LogWarning("⚠️ Interstitial ad abhi ready nahi hai.");
//             LoadInterstitialAd();
//         }
//     }
// }
















 
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [Header("Unity Ads Game ID")]
    [SerializeField] private string androidGameId = "5955409";
    [SerializeField] private string iosGameId = "5955408";
    [SerializeField] private bool testMode = true;

    [Header("Ad Unit IDs")]
    [SerializeField] private string bannerAdUnitId = "Banner_Android";
    [SerializeField] private string interstitialAdUnitId = "Interstitial_Android";

    public static AdsManager Instance { get; private set; }

    private string gameId;
    private bool interstitialReady = false; // ✅ flag to track ad readiness

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

#if UNITY_ANDROID
        gameId = androidGameId;
#elif UNITY_IOS
        gameId = iosGameId;
#endif

        Debug.Log("🔄 Initializing Unity Ads (TestMode=" + testMode + ")...");
        Advertisement.Initialize(gameId, testMode, this);
    }

    private void Start()
    {
        ShowBannerAd();
    }

    // ===============================
    // ✅ Initialization
    // ===============================
    public void OnInitializationComplete()
    {
        Debug.Log("✅ Unity Ads Initialization Complete.");
        LoadInterstitialAd();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.LogError($"❌ Unity Ads Initialization Failed: {error} - {message}");
    }

    // ===============================
    // ✅ Banner Ads
    // ===============================
    public void ShowBannerAd()
    {
        Debug.Log("🔄 Requesting Banner Ad...");
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show(bannerAdUnitId);
    }

    public void HideBannerAd()
    {
        Advertisement.Banner.Hide();
        Debug.Log("🛑 Banner Ad Hidden.");
    }

    // ===============================
    // ✅ Interstitial Ads
    // ===============================
    public void LoadInterstitialAd()
    {
        Debug.Log("🔄 Loading Interstitial Ad...");
        Advertisement.Load(interstitialAdUnitId, this);
    }

    public void ShowInterstitialAd()
    {
        if (interstitialReady)
        {
            Debug.Log("✅ Attempting to Show Interstitial Ad...");
            Advertisement.Show(interstitialAdUnitId, this);
            interstitialReady = false; // reset so it forces reload after completion
        }
        else
        {
            Debug.LogWarning("⚠️ Tried to show Interstitial but it's not ready yet!");
            LoadInterstitialAd();
        }
    }

    // ===============================
    // ✅ Load Callbacks

    // ===============================public void OnUnityAdsAdLoaded(string placementId)
    public void OnUnityAdsAdLoaded(string placementId)


    {

        Debug.Log($"✅ Ad Loaded: {placementId}");
        if (placementId == interstitialAdUnitId)
        {
            interstitialReady = true;
            Debug.Log("🎉 Interstitial is READY!");
        }
        else
        {
            Debug.LogWarning($"⚠️ Loaded Ad does not match interstitial ID. Got: {placementId}, Expected: {interstitialAdUnitId}");
        }
    }
    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.LogError($"❌ Failed to Load Ad {placementId}: {error} - {message}");
        interstitialReady = false;
    }

    // ===============================
    // ✅ Show Callbacks
    // ===============================
    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.LogError($"❌ Failed to Show Ad {placementId}: {error} - {message}");
        interstitialReady = false;
        LoadInterstitialAd();
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log($"▶️ Ad Started: {placementId}");
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        Debug.Log($"🖱️ Ad Clicked: {placementId}");
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        Debug.Log($"✅ Ad Completed: {placementId} - State: {showCompletionState}");
        interstitialReady = false;
        LoadInterstitialAd(); // reload for next
    }
}







