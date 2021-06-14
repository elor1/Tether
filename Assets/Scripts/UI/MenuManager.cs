using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject mainButtons;
    [SerializeField]
    private GameObject instructions;

    // Start is called before the first frame update
    void Start()
    {
        mainButtons.SetActive(true);
        instructions.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Instructions()
    {
        mainButtons.SetActive(false);
        instructions.SetActive(true);
    }

    public void BackToMenu()
    {
        mainButtons.SetActive(true);
        instructions.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
