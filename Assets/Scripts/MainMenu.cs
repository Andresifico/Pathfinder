using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static int N;
    public static int M;
    [SerializeField] private TextMeshProUGUI _MenuText2;
    [SerializeField] private TextMeshProUGUI _MenuText;

    public void PlayGame()
    {
        N = int.Parse(_MenuText.text);
        M = int.Parse(_MenuText2.text);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

}