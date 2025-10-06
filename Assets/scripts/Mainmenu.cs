// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class MainMenu : MonoBehaviour
// {
//     // Ye function Start Button se call hoga
//     public void PlayGame()
//     {
//         // "Game" ki jagah apna game scene ka exact naam likhna
//         SceneManager.LoadScene("Game");
//         //Debug.log("loading Game Scene...");   
//         AdsManager.Instance.LoadInterstitialAd();


        
//     }

//     // Agar Exit button bhi chahiye
//     public void QuitGame()
//     {
//         Debug.Log("Quit pressed!");
//         Application.Quit();
//     }
// }





using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
        AdsManager.Instance.LoadInterstitialAd();
    }

    public void QuitGame()
    {
        Debug.Log("Quit pressed!");
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}


