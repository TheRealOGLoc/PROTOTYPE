using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Button helpButton;
    public Button helpInfo;
    public Button exitButton;
    private AudioSource ButtonAudioSource;
    public AudioClip clickSound;
    // Start is called before the first frame update
    void Start()
    {
        // Bind funciton to the buttons
        helpButton.onClick.AddListener(ShowHelpInfo);
        helpInfo.onClick.AddListener(CloseHelpInfo);
        exitButton.onClick.AddListener(ExitTheGame);
        ButtonAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Show the help information
    void ShowHelpInfo()
    {
        helpInfo.gameObject.SetActive(true);
        PlayClickSound();
    }

    // Close the help information
    void CloseHelpInfo()
    {
        helpInfo.gameObject.SetActive(false);
        PlayClickSound();
    }

    // Play the click sound
    void PlayClickSound()
    {
        ButtonAudioSource.PlayOneShot(clickSound, 1.0f);
    }

    // Exit the game
    void ExitTheGame()
    {
        Application.Quit();
    }
}
