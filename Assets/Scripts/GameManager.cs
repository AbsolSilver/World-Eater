using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //this allows you use Canvas elements
using UnityEngine.SceneManagement; // this allows you to change scenes

public class GameManager : MonoBehaviour
{
    #region Variables
    [Header("GAME MANAGER")] //nice heading
    [Space(10)] //10 unit space between main heading and sub heading
    [Header("Levels")] //sub heading 1
    public int levelToLoad; // the level number we want to load
    public Scene curScene;
    public bool paused;
    [Space(5)] // 5 unit space between the two sub headings
    [Header("OPTIONS")]// sub heading 2
    [Space(3)]
    [Header("Resolution")]//all the variables for resilution
    public int index;//the refernce number to the array of resolutions
    public Vector2[] res;//this is our array of resolutions
    public bool fullScreen;//this will allow us to toggle the full screeen vs windowed

    [Header("References")]//all objects we need to interact with
    public AudioSource music; //the element that plays music
    public float tempMusic;// this holds the volume amount if muted
    public bool muted;//allos us to toggle mute
    public Light brightness;//is the element that controlls the light rendered on a 3D model
    [Header("Keys")]//Keys for Keybinding
    public KeyCode left;
    public KeyCode right;
    public KeyCode shoot;
    ///////////////////////////
    public KeyCode tempKey;
    [Header("Screen Elements")]//all GUI elements
    public bool showOption; //toggle for showing the options menu
    public GameObject menu, optionsMenu; // main menu and options menu screen objects
    public Dropdown resolutionDropDown;
    public Toggle fullscreenToggle;
    public Slider volumeSlider, brightnessSlider;
    public Text leftText, rightText, shootText;
    #endregion
    void Start()
    {
        Time.timeScale = 1;//makes time run at the start of a scene
        curScene = SceneManager.GetActiveScene();
        if (optionsMenu != null)
        {
            #region Sliders
            brightness = GameObject.FindGameObjectWithTag("Light").GetComponent<Light>();
            music = GameObject.Find("Music").GetComponent<AudioSource>();
            volumeSlider.value = music.volume;
            brightnessSlider.value = brightness.intensity;
            #endregion
            #region Keys
         
            left = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left", "A"));
            leftText.text = left.ToString();
            right = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right", "D"));
            rightText.text = right.ToString();
            shoot = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Shoot", "Space"));
            shootText.text = shoot.ToString();
            #endregion
        }

    }
    void Update()
    {
        if (curScene.name == "Game")
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                TogglePause();
            }
        }
    }
    #region Key Bind
    public void Left()
    {
        if (!(right == KeyCode.None || shoot == KeyCode.None))
        {
            //set our holding key to the key of this button
            tempKey = left;

            left = KeyCode.None;

            leftText.text = left.ToString();
        }

    }
    public void Right()
    {
        if (!(left == KeyCode.None || shoot == KeyCode.None))
        {
            //set our holding key to the key of this button
            tempKey = right;

            right = KeyCode.None;

            rightText.text = right.ToString();
        }

    }
    public void Shoot()
    {
        if (!(left == KeyCode.None || right == KeyCode.None))
        {
            //set our holding key to the key of this button
            tempKey = shoot;

            shoot = KeyCode.None;

            shootText.text = shoot.ToString();
        }

    }
    #endregion
    public void ChangeAudioVolume()
    {
        music.volume = volumeSlider.value;
    }
    public void ChngeBrightness()
    {
        brightness.intensity = brightnessSlider.value;
    }

    public void ChangeScene() //publicly avaliable function that let us change scenes
    {
        SceneManager.LoadScene(levelToLoad); //using scene manager we are loading a new scene, that scene is our level to load.
    }

    public void ExitGame() // lets us leave the game
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void ToggleOptions() //making a function to toggle the Options menu
    {
        OptionsToggle(); // activates the boolean below
    }
    bool OptionsToggle()
    {
        if (showOption) // showOption == true
        {
            showOption = false; // set our toggle to false
            menu.SetActive(true); //show our menu
            optionsMenu.SetActive(false); // hide our options
            return false;
        }
        else // other wise if we arent showing our options menu
        {
            showOption = true; //set our toggle to true
            menu.SetActive(false); //hide our menu
            optionsMenu.SetActive(true); // show our options
            return true;
        }
    }
    public void ResolutionChange()
    {
        index = resolutionDropDown.value;
        Screen.SetResolution((int)res[index].x, (int)res[index].y, fullScreen);
    }
    public bool ToggleFullscreen()
    {
        if (fullScreen)//if fullscreen is on...when we toggle
        {
            fullScreen = false;//set the bool for the resolution to false
            Screen.fullScreen = false;//set the fullscreen to windowed
            fullscreenToggle.isOn = false;//untick our toggle
            return false;
        }
        else//otherwise if fullscreen is ogg when we toggle
        {
            fullScreen = true;//set the bool for the resolution to turn
            Screen.fullScreen = true;//set the window to fullscreen
            fullscreenToggle.isOn = true;//tick our toggle
            return true;
        }
    }
    public void FullscreenToggle()//allows the toggle to be seen by the canvas element and used
    {
        ToggleFullscreen();// this runs the toggle for the fullscreen
    }
    void OnGUI()
    {
        if (optionsMenu != null)
        {


            #region Set New Key or Set Key Back

            Event e = Event.current;
            if (left == KeyCode.None)
            {
                if (e.isKey)
                {
                    Debug.Log("Key Code: " + e.keyCode);
                    if (!(e.keyCode == right || e.keyCode == shoot))
                    {
                        left = e.keyCode;

                        tempKey = KeyCode.None;

                        leftText.text = left.ToString();
                    }
                    else
                    {
                        left = tempKey;

                        tempKey = KeyCode.None;

                        leftText.text = left.ToString();
                    }
                }
            }
            if (right == KeyCode.None)
            {
                if (e.isKey)
                {
                    Debug.Log("Key Code: " + e.keyCode);
                    if (!(e.keyCode == left || e.keyCode == shoot))
                    {
                        right = e.keyCode;

                        tempKey = KeyCode.None;

                        rightText.text = right.ToString();
                    }
                    else
                    {
                        right = tempKey;

                        tempKey = KeyCode.None;

                        rightText.text = right.ToString();
                    }
                }
            }
            if (shoot == KeyCode.None)
            {
                if (e.isKey)
                {
                    Debug.Log("Key Code: " + e.keyCode);
                    if (!(e.keyCode == left ||
                        e.keyCode == right || e.keyCode == shoot))
                    {
                        shoot = e.keyCode;

                        tempKey = KeyCode.None;

                        shootText.text = shoot.ToString();
                    }
                    else
                    {
                        shoot = tempKey;

                        tempKey = KeyCode.None;

                        shootText.text = shoot.ToString();
                    }
                }
            }
            #endregion
        }
    }
    public void SaveOptions()
    {
        PlayerPrefs.SetString("Left", left.ToString());
        PlayerPrefs.SetString("Right", right.ToString());
        PlayerPrefs.SetString("Shoot", shoot.ToString());

    }
    public void TogglePauseMenu()
    {
        TogglePause();
    }
    bool TogglePause()
    {
        if (paused == true)
        {
            //set paused to false
            paused = false;
            menu.SetActive(false);
            Time.timeScale = 1;
            return false;
        }
        else //we are not paused
        {
            //setpaused to true
            paused = true;
            Time.timeScale = 0;
            menu.SetActive(true);
            return true;

        }
    }
    //static void Swap(, )
    //{
    //    KeyCode tempKey = KeyCode a;
    //
    //}
}
