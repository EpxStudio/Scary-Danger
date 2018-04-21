using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public Button startText;

    // Use this for initialization
    void Start()
    {
        startText = startText.GetComponent<Button>();
    }

    // Update is called once per frame

    public void StartLevel()
    {
        SceneManager.LoadSceneAsync("mainScene");
    }
}
