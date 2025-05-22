using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MainMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        // Debug.Log("ゲーム開始ボタンが押されました！");
        SceneManager.LoadScene("仮");
    }

    public void QuitGame()
    {
        Debug.Log("ゲーム終了ボタンが押されました！");
        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}