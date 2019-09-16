using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//MARKER This Script will be responsible for the Game Menu
public class GameMenu : MonoBehaviour
{
    public Image gameMenuImage;

    public Toggle BGMToggle;
    private AudioSource BGMSource;//MARKER BGM Source

    //OPTIONAL 
    private PlayerMovement player;

    private void Start()
    {
        gameMenuImage.gameObject.SetActive(false);
        BGMSource = GetComponent<AudioSource>();

        player = FindObjectOfType<PlayerMovement>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameManager.instance.isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        BGMManager();
    }

    public void Resume()
    {
        Debug.Log("RESUME");
        gameMenuImage.gameObject.SetActive(false);
        Time.timeScale = 1;
        GameManager.instance.isPaused = false;
    }

    public void Pause()
    {
        Debug.Log("PAUSE");
        gameMenuImage.gameObject.SetActive(true);
        Time.timeScale = 0;
        GameManager.instance.isPaused = true;
    }

    //MARKER THIS BUTTON WILL BE ATTACHED ON THE SAVE BUTTON ON OPTIONS MENU 
    public void BGMToggleButton()
    {
        if(BGMToggle.isOn)
        {
            //OPEN the BGM
            PlayerPrefs.SetInt("BGM", 1);//OPEN
            Debug.Log(PlayerPrefs.GetInt("BGM"));
        }
        else
        {
            //CLOSE the BGM
            PlayerPrefs.SetInt("BGM", 0);//CLOSE
            Debug.Log(PlayerPrefs.GetInt("BGM"));
        }
    }

    private void BGMManager()
    {
        if (PlayerPrefs.GetInt("BGM") == 1)
        {
            BGMToggle.isOn = true;
            BGMSource.enabled = true;
        }
        else if (PlayerPrefs.GetInt("BGM") == 0)
        {
            BGMToggle.isOn = false;
            BGMSource.enabled = false;
        }
    }

    //MARKER THIS BUTTON WILL BE ATTACHED ON THE SAVE BUTTON ON OPTIONS MENU 
    public void SaveButton()
    {
        SaveByPlayerPrefs();
    }

    public void LoadButton()
    {
        LoadByPlayerPrefs();
        Resume();
    }

    private void SaveByPlayerPrefs()
    {
        PlayerPrefs.SetInt("Coins", GameManager.instance.coins);
        PlayerPrefs.SetInt("Diamonds", GameManager.instance.diamonds);

        //OPTIONAL
        PlayerPrefs.SetFloat("PlayerPosX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerPosY", player.transform.position.y);
    }

    private void LoadByPlayerPrefs()
    {
        if(PlayerPrefs.HasKey("Coins"))//MARKER MAKING SURE 
        {
            GameManager.instance.coins = PlayerPrefs.GetInt("Coins");
        }

        if(PlayerPrefs.HasKey("Diamonds"))
        {
            GameManager.instance.diamonds = PlayerPrefs.GetInt("Diamonds");
        }

        //OPTIONAL
        if(PlayerPrefs.HasKey("PlayerPosX"))
        {
            player.playerPosX = PlayerPrefs.GetFloat("PlayerPosX");//IF GETINT, Cause Zero(DEFAULT VALUE)
        }

        if (PlayerPrefs.HasKey("PlayerPosY"))
        {
            player.playerPosY = PlayerPrefs.GetFloat("PlayerPosY");
        }

        player.transform.position = new Vector2(player.playerPosX, player.playerPosY);
    }


}
