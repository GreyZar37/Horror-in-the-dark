using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update


    [Header("Progression")]

    public bool hasYellowKey = false;
    public bool hasRedKey = false;
    public bool hasBlueKey = false;
    public bool doorOpened = false;
    public bool codeCorrect = false;

    public string code;
    public string currentCode;
    public bool wasPulled = false;

    

    bool hasPlayed = false;
    float timer = 0.5f;

    [Header("Sounds")]

    public AudioSource audioSource;
    

    public AudioClip doorLock;
    public AudioClip footSteps;
    public AudioClip doorOpen;
    public AudioClip pickUpSound;
    public AudioClip chestOpenSound;
    public AudioClip chestCloseSound;
    public AudioClip ScaryEffect;
    public AudioClip jumpScareSound;
    public AudioClip clothSound;
    public AudioClip bibSound;
    public AudioClip correct;
    public AudioClip wrong;
    public AudioClip jumpScare2Sound;
    public AudioClip jumpScare3Sound;
    public AudioClip jumpScare4Sound;

    [Header("Entities")]
    public GameObject scaryFace;
    public GameObject jumpScare;
    public GameObject jumpScare2;
    public GameObject jumpScare3;
    public GameObject jumpScare4;

    public bool jum2HasPlayed = false;
    public bool jum3HasPlayed = false;
    public bool jum4HasPlayed = false;


  

    public bool jumpScareWasActive = false;
    public bool scaryFigure = false;
    public bool scaryFaceWasActivated = false;
    public bool RightCode;

    [Header("level1")]

    public GameObject level1Scene;
    public GameObject toiletOne;
    public GameObject shelfOne;
    public GameObject doorOne;



    [Header("ToiletScene")]

    public GameObject toiletWithKey;
    public GameObject toiletWithoutKey;

    [Header("level2")]
    public GameObject level2Scene;
    public GameObject ChestScene;
    public GameObject HallwayScene;
    public GameObject DoorRedKey;
    public GameObject DoorExit;

    public GameObject Box1;
    public GameObject Box2;
    public GameObject Box3;

    public GameObject BoxW;
    public GameObject BoxN;

    public GameObject doorExitRed;
    public GameObject doorExitGreen;

    public GameObject doorExitRed2;
    public GameObject doorExitGreen2;



    [Header("ChestScene")]
    
    public GameObject OpenChest;

    [Header("level3")]
    public GameObject level3Scene;
    public GameObject greenLight;
    public GameObject redLight;

    public GameObject drawerWK;
    public GameObject drawerNK;
    public GameObject drwerOpen;
    public GameObject drawerScene;
    public GameObject drawerClosed;
    public GameObject drawerEmpty;

    public GameObject doorGreenLight;
    public GameObject doorRedLight;
    public GameObject door3Scene;
    public GameObject boxScene;



    [Header("level4")]
    public GameObject level4Scene;
    public GameObject PocketScene;
    public GameObject PocketClose;
    public GameObject PocketFar;
    public GameObject NoteScene;
    public GameObject pocketButton;

    [Header("level5")]


    public float gameTimer;
    public GameObject creditScene;

    private float cooldownTimer = 0.2f;
    private float currentTimer;

    private float cooldownTimer2 = 1f;
    private float currentTimer2;


    [Header("Other")]
    public TextMeshProUGUI currentLocationText;
    public TextMeshProUGUI usedTime;

    public GameObject music;

    public GameObject settings;
    private bool escapeWasPressed = false;


    public Slider musicSlider;
    public Slider soundSlider;

    public GameObject soundRain;
    public GameObject endMusic;
    public GameObject mainMusic;


    public Texture2D clickcursor;
    public Texture2D defultcursor;


    public Sprite[] SpriteArray;


    void Start()
    {

        musicSlider.value = PlayerPrefs.GetFloat("musicSlider", 1);
        soundSlider.value = PlayerPrefs.GetFloat("soundSlider", 1);

        Cursor.SetCursor(defultcursor, Vector2.zero, CursorMode.Auto);
        currentLocationText.text = ("Bedroom");

        currentTimer = cooldownTimer;
        currentTimer2 = cooldownTimer2;
    }

    // Update is called once per frame
    void Update()
    {

        soundRain.GetComponent<AudioSource>().volume = soundSlider.value;
        endMusic.GetComponent<AudioSource>().volume = musicSlider.value;
        mainMusic.GetComponent<AudioSource>().volume = musicSlider.value;
        audioSource.volume = soundSlider.value;

        if (Input.GetKeyDown(KeyCode.Escape) && escapeWasPressed == false)
        {
            settings.SetActive(true);
            escapeWasPressed = true;

        }
        else if (Input.GetKeyDown(KeyCode.Escape) && escapeWasPressed == true)
        {
            settings.SetActive(false);
            escapeWasPressed = false;
            PlayerPrefs.SetFloat("soundSlider", soundSlider.value);
            PlayerPrefs.SetFloat("musicSlider", musicSlider.value);
        }

        gameTimer += Time.deltaTime;


        if(doorOpened == true && currentLocationText.text == "Office" && jum2HasPlayed == false)
        {
            jumpScare2.SetActive(true);
            audioSource.PlayOneShot(jumpScare2Sound);
            jum2HasPlayed = true;
        }

        if (wasPulled == true && currentLocationText.text == "Hallway" && jum3HasPlayed == false)
        {
            jumpScare3.SetActive(true);
            audioSource.PlayOneShot(jumpScare3Sound);
            jum3HasPlayed = true;
        }


        if (jumpScareWasActive == false && scaryFigure == true && currentLocationText.text == "Bedroom")
        {
            
            timer -= Time.deltaTime;

            if(jumpScare != null && timer <= 0)
            {
                jumpScare.SetActive(true);
            }
           

           

            if(hasPlayed == false && timer <= 0)
            {
                audioSource.PlayOneShot(jumpScareSound);
                hasPlayed = true;
            }
           
        }

        if (LeverScript.isDown == false && LeverScript1.isDown2 == true && LeverScript2.isDown3 == true && LeverScript3.isDown4 == false && LeverScript4.isDown5 == false)
        {
            doorExitRed.SetActive(false);
            doorExitGreen.SetActive(true);

            doorExitRed2.SetActive(false);
            doorExitGreen2.SetActive(true);
            RightCode = true;
        }
        else
        {
            doorExitRed2.SetActive(true);
            doorExitGreen2.SetActive(false);

            doorExitRed.SetActive(true);
            doorExitGreen.SetActive(false);
            RightCode = false;
        }
        



        if(LeverScript1.isDown2 == false && LeverScript5.isDown6 == false)
        {
            redLight.SetActive(false);
            greenLight.SetActive(true);

            doorGreenLight.SetActive(true);
            doorRedLight.SetActive(false);

            doorOpened = true;
        }
        else
        {
            redLight.SetActive(true);
            greenLight.SetActive(false);

            doorGreenLight.SetActive(false);
            doorRedLight.SetActive(true);

            doorOpened = false;
        }
       

      

    }

    
    public void BeedRoomScene()
    {

        audioSource.PlayOneShot(footSteps);

        level1Scene.SetActive(true);
        toiletOne.SetActive(false);
        shelfOne.SetActive(false);
        doorOne.SetActive(false);
        currentLocationText.text = "Bedroom";
        Cursor.SetCursor(defultcursor, Vector2.zero, CursorMode.Auto);
    }
    public void ToiletScene()
    {
        audioSource.PlayOneShot(footSteps);
        level1Scene.SetActive(false);
        toiletOne.SetActive(true);
        shelfOne.SetActive(false);
        doorOne.SetActive(false);
        currentLocationText.text = "Toilet";
        Cursor.SetCursor(defultcursor, Vector2.zero, CursorMode.Auto);
    }
    public void ShelfScene()
    {
        audioSource.PlayOneShot(footSteps);
        level1Scene.SetActive(false);
        toiletOne.SetActive(false);
        shelfOne.SetActive(true);
        doorOne.SetActive(false);
        currentLocationText.text = "Shelf";
        Cursor.SetCursor(defultcursor, Vector2.zero, CursorMode.Auto);
    }
    public void DoorScene()
    {
        audioSource.PlayOneShot(footSteps);
        level1Scene.SetActive(false);
        toiletOne.SetActive(false);
        shelfOne.SetActive(false);
        doorOne.SetActive(true);
        level2Scene.SetActive(false);
        currentLocationText.text = "Door";
        Cursor.SetCursor(defultcursor, Vector2.zero, CursorMode.Auto);
    }
    public void ChangeToiletScene()
    {
        audioSource.PlayOneShot(pickUpSound);
        toiletWithKey.SetActive(false);
        toiletWithoutKey.SetActive(true);
        hasYellowKey = true;
        Cursor.SetCursor(defultcursor, Vector2.zero, CursorMode.Auto);
    }


    public void level2Scene_()
    {
        

        if (hasYellowKey == true)
        {
            if(currentLocationText.text == "Door")
            {
                audioSource.PlayOneShot(doorOpen);
            }
            
            level2Scene.SetActive(true);
            doorOne.SetActive(false);
            ChestScene.SetActive(false);
            HallwayScene.SetActive(false);
            Box1.SetActive(false);
            Box2.SetActive(false);
            Box3.SetActive(false);

            currentLocationText.text = "Living room";
            Cursor.SetCursor(defultcursor, Vector2.zero, CursorMode.Auto);
            audioSource.PlayOneShot(footSteps);
        }
        else
        {
            audioSource.PlayOneShot(doorLock);
        }
        
    }
    public void chestScene_()
    {
        if(currentLocationText.text == "Living room")
        {
            audioSource.PlayOneShot(footSteps);
        }
        
        if(currentLocationText.text == "Chest")
        {
            audioSource.PlayOneShot(chestCloseSound); 
        }
        

        level2Scene.SetActive(false);
        ChestScene.SetActive(true);
        OpenChest.SetActive(false);
        currentLocationText.text = "Chest";
        Cursor.SetCursor(defultcursor, Vector2.zero, CursorMode.Auto);
    }
    public void chestScene_Open()
    {
        if(hasBlueKey == true)
        {
            audioSource.PlayOneShot(chestOpenSound);
            OpenChest.SetActive(true);
            ChestScene.SetActive(false);
            currentLocationText.text = "Chest";
            Cursor.SetCursor(defultcursor, Vector2.zero, CursorMode.Auto);
        }
        else
        {
            audioSource.PlayOneShot(doorLock);
        }
       
    }
    public void doorRedKey()
    {
        audioSource.PlayOneShot(footSteps);
       
        HallwayScene.SetActive(false);
        DoorRedKey.SetActive(true);
        DoorExit.SetActive(false);
        level3Scene.SetActive(false);

        currentLocationText.text = "Door";
        Cursor.SetCursor(defultcursor, Vector2.zero, CursorMode.Auto);
    }
    public void HallwayScene_()
    {
        audioSource.PlayOneShot(footSteps);

        if(scaryFigure == false)
        {
            audioSource.PlayOneShot(ScaryEffect);
        }

        scaryFigure = true;
        level2Scene.SetActive(false);
        HallwayScene.SetActive(true);
        DoorRedKey.SetActive(false);
        DoorExit.SetActive(false);
        level3Scene.SetActive(false);



        currentLocationText.text = "Hallway";
        Cursor.SetCursor(defultcursor, Vector2.zero, CursorMode.Auto);
    }
    public void DoorExit_()
    {
        audioSource.PlayOneShot(footSteps);

        HallwayScene.SetActive(false);
        DoorRedKey.SetActive(false);
        DoorExit.SetActive(true);

        currentLocationText.text = "Exit door";
        Cursor.SetCursor(defultcursor, Vector2.zero, CursorMode.Auto);
    }

    public void Level3Scene_()
    {
        if (hasRedKey == true)
        {
            if (currentLocationText.text == "Door")
            {
                audioSource.PlayOneShot(doorOpen);
            }

            audioSource.PlayOneShot(footSteps);
            DoorRedKey.SetActive(false);
            level3Scene.SetActive(true);
            drawerScene.SetActive(false);
            door3Scene.SetActive(false);
            boxScene.SetActive(false);

            currentLocationText.text = "Office";
            Cursor.SetCursor(defultcursor, Vector2.zero, CursorMode.Auto);
            
        }
        else
        {
            audioSource.PlayOneShot(doorLock);
        }
    }

    public void Box1_()
    {
        audioSource.PlayOneShot(footSteps);

        level2Scene.SetActive(false);
        Box1.SetActive(true);

        currentLocationText.text = "Box 1";
        Cursor.SetCursor(defultcursor, Vector2.zero, CursorMode.Auto);
    }
    public void Box2_()
    {
        audioSource.PlayOneShot(footSteps);

        level2Scene.SetActive(false);
        Box2.SetActive(true);

        currentLocationText.text = "Box 2";
        Cursor.SetCursor(defultcursor, Vector2.zero, CursorMode.Auto);
    }
    public void Box3_()
    {
        audioSource.PlayOneShot(footSteps);

        level2Scene.SetActive(false);
        Box3.SetActive(true);

        currentLocationText.text = "Box 3";
        Cursor.SetCursor(defultcursor, Vector2.zero, CursorMode.Auto);
    }
    public void Box2_Change()
    {

        audioSource.PlayOneShot(pickUpSound);
        BoxN.SetActive(true);
        BoxW.SetActive(false);
        hasRedKey = true;
        
        currentLocationText.text = "Box 2";
        Cursor.SetCursor(defultcursor, Vector2.zero, CursorMode.Auto);
    }


    public void drawerScene_()
    {
       
        audioSource.PlayOneShot(footSteps);

       drawerScene.SetActive(true);
       level3Scene.SetActive(false);

        currentLocationText.text = "Drawer";
        Cursor.SetCursor(defultcursor, Vector2.zero, CursorMode.Auto);
    }

    public void drawerClosed_()
    {
        
        
        drawerClosed.SetActive(true);
        drwerOpen.SetActive(false);
        drawerEmpty.SetActive(false);

        currentLocationText.text = "Drawer";
        Cursor.SetCursor(defultcursor, Vector2.zero, CursorMode.Auto);
    }

    public void drawerOpen_()
    {

        
        audioSource.PlayOneShot(doorOpen);

        drawerClosed.SetActive(false);
        drwerOpen.SetActive(true);

        currentLocationText.text = "Drawer";
        Cursor.SetCursor(defultcursor, Vector2.zero, CursorMode.Auto);
    }

    public void drawerEmpty_()
    {
        audioSource.PlayOneShot(doorOpen);

        drawerClosed.SetActive(false);
        drawerEmpty.SetActive(true);

        currentLocationText.text = "Drawer";
        Cursor.SetCursor(defultcursor, Vector2.zero, CursorMode.Auto);
    }

    public void drawerChange_()
    {
        audioSource.PlayOneShot(pickUpSound);

        hasBlueKey = true;
        drawerNK.SetActive(true);
        drawerWK.SetActive(false);

        currentLocationText.text = "Drawer";
        Cursor.SetCursor(defultcursor, Vector2.zero, CursorMode.Auto);
    }

    public void door3Scene_()
    {
        
       
            audioSource.PlayOneShot(footSteps);
            door3Scene.SetActive(true);
            level3Scene.SetActive(false);
        level4Scene.SetActive(false);
        boxScene.SetActive(false);
        NoteScene.SetActive(false);
        





        currentLocationText.text = "Door ";
        Cursor.SetCursor(defultcursor, Vector2.zero, CursorMode.Auto);
    }
    public void level4Scene_()
    {

        if (doorOpened == true)
        {

            if (currentLocationText.text == "Door ")
            {
                audioSource.PlayOneShot(doorOpen);
            }
            currentLocationText.text = "Room 2";
            audioSource.PlayOneShot(footSteps);
            door3Scene.SetActive(false);
            level4Scene.SetActive(true);
            PocketScene.SetActive(false);
            NoteScene.SetActive(false);
            Cursor.SetCursor(defultcursor, Vector2.zero, CursorMode.Auto);
        }
        else
        {
            audioSource.PlayOneShot(doorLock);
        }


        
      
    }

    public void JacketScene_()
    {
        audioSource.PlayOneShot(footSteps);

        PocketScene.SetActive(true);
        level4Scene.SetActive(false);


        currentLocationText.text = "Jacket";
        Cursor.SetCursor(defultcursor, Vector2.zero, CursorMode.Auto);
    }
    public void JacketSceneChange()
    {

        audioSource.PlayOneShot(clothSound);
        PocketClose.SetActive(true);
        PocketFar.SetActive(false);
        pocketButton.SetActive(false);
        wasPulled = true;

        currentLocationText.text = "Jacket";
        Cursor.SetCursor(defultcursor, Vector2.zero, CursorMode.Auto);
    }

    public void NoteScene_()
    {
        audioSource.PlayOneShot(footSteps);

        NoteScene.SetActive(true);
        level3Scene.SetActive(false);


        currentLocationText.text = "Jacket";
        Cursor.SetCursor(defultcursor, Vector2.zero, CursorMode.Auto);
    }
    public void BoxScene()
    {
        audioSource.PlayOneShot(footSteps);

        boxScene.SetActive(true);
        level3Scene.SetActive(false);


        currentLocationText.text = "Jacket";
        Cursor.SetCursor(defultcursor, Vector2.zero, CursorMode.Auto);
    }


    public void EnterMouse()
    {
        Cursor.SetCursor(clickcursor, Vector2.zero, CursorMode.Auto);

    }
    public void ExitMouse()
    {
        Cursor.SetCursor(defultcursor, Vector2.zero, CursorMode.Auto);

    }


    public void one()
    {
        audioSource.PlayOneShot(bibSound);

        currentCode += "1";
       
        
    }
    public void two()
    {
        audioSource.PlayOneShot(bibSound);

        currentCode += "2";

        
    }
    public void three()
    {
        audioSource.PlayOneShot(bibSound);

        currentCode += "3";

     
    }
    public void four()
    {
        audioSource.PlayOneShot(bibSound);

        currentCode += "4";

        
    }
    public void five()
    {
        audioSource.PlayOneShot(bibSound);

        currentCode += "5";

        
    }
    public void six()
    {
        audioSource.PlayOneShot(bibSound);

        currentCode += "6";

        
    }
    public void seven()
    {
        audioSource.PlayOneShot(bibSound);

        currentCode += "7";

        
    }
    public void eight()
    {
        audioSource.PlayOneShot(bibSound);

        currentCode += "8";

      
    }
    public void nine()
    {
        audioSource.PlayOneShot(bibSound);

        currentCode += "9";

      
    }
    public void submit()
    {
        audioSource.PlayOneShot(bibSound);

        code = currentCode;

        if (code == "5264")
        {

            audioSource.PlayOneShot(correct);
            codeCorrect = true;
            
        }
        else if (code != "5264")
        {
            code = null;
            currentCode = null;
            audioSource.PlayOneShot(wrong);

         
            if (jum4HasPlayed == false)
            {
                jumpScare4.SetActive(true);
                audioSource.PlayOneShot(jumpScare4Sound);
                jum4HasPlayed = true;

            }
           
        }

        
    }


    public void ExitGame()
    {
        if (RightCode == true && codeCorrect == true)
        {
            currentLocationText.text = null;
            creditScene.SetActive(true);
            DoorExit.SetActive(false);
            gameTimer = (int)gameTimer;
            usedTime.text = gameTimer.ToString() + " seconds";
            music.SetActive(false);
            Cursor.SetCursor(defultcursor, Vector2.zero, CursorMode.Auto);

        }
        else
        {
            audioSource.PlayOneShot(doorLock);
        }

     
    }
    public void Exit()
    {
        Application.Quit();

    }


}
