using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CEndManager : _MonoBehaviour
{
    public Text _bestText;

    private void Start()
    {
        _bestText.text = PlayerPrefs.GetInt("BEST_CLICK_COUNT").ToString();
    }

    public void OnIntroButtonClick()
    {
        SceneManager.LoadScene("Intro");
    }

    public void OnRestartButtonClick()
    {
        SceneManager.LoadScene("Game");
    }
}
