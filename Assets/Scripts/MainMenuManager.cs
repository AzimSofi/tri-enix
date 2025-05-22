using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MainMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        // Debug.Log("�Q�[���J�n�{�^����������܂����I");
        SceneManager.LoadScene("��");
    }

    public void QuitGame()
    {
        Debug.Log("�Q�[���I���{�^����������܂����I");
        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}