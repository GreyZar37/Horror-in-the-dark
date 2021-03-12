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

    [Header("Entities")]
    public GameObject scaryFace;

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

    [Header("level3")]
    public GameObject level3Scene;

    [Header("level4")]
    public GameObject level4Scene;

    [Header("level5")]
    public GameObject level5Scene;

    private float cooldownTimer = 0.7f;
    private float currentTimer;

    private float cooldownTimer2 = 1.5f;
    private float currentTimer2;


    [Header("Other")]
    public TextMeshProUGUI currentLocationText;
    public string location;


    public Texture2D clickcursor;
    public Texture2D defultcursor;




    void Start()
    {
        Cursor.SetCursor(defultcursor, Vector2.zero, CursorMode.Auto);
        location = ("Bedroom");

        currentTimer = cooldownTimer;
        currentTimer2 = cooldownTimer2;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentLocationText.text == "Living Room")
        {
            currentTimer -= Time.deltaTime;

            if(currentTimer <= 0)
            {

                scaryFace.SetActive(true);
                currentTimer2 -= Time.deltaTime;
                if(currentTimer2 <= 0)
                {
                    scaryFace.SetActive(false);
                }
            }
        }

       
    }




    public void changeLocationBedroomToShelf()
    {
        level1Scene.SetActive(false);
        shelfOne.SetActive(true);
        location = "Shelf";
        currentLocationText.text = location;
        Cursor.SetCursor(defultcursor, Vector2.zero, CursorMode.Auto);
    }

    public void changeLocationShelfToBedroom()
    {
        level1Scene.SetActive(true);
        shelfOne.SetActive(false);
        location = "Bedroom";
        currentLocationText.text = location;
        Cursor.SetCursor(defultcursor, Vector2.zero, CursorMode.Auto);
    }

    public void changeLocationBedroomToToilet()
    {
        level1Scene.SetActive(false);
        toiletOne.SetActive(true);
        location = "Toilet";
        currentLocationText.text = location;
        Cursor.SetCursor(defultcursor, Vector2.zero, CursorMode.Auto);
    }

    public void changeLocationToiletToBedroom()
    {
        level1Scene.SetActive(true);
        toiletOne.SetActive(false);
        location = "Bedroom";
        currentLocationText.text = location;
        Cursor.SetCursor(defultcursor, Vector2.zero, CursorMode.Auto);
    }


    public void changeLocationBedroomToDoor()
    {
        level1Scene.SetActive(false);
        doorOne.SetActive(true);
        location = "Door";
        currentLocationText.text = location;
        Cursor.SetCursor(defultcursor, Vector2.zero, CursorMode.Auto);
    }

    public void EnterMouse()
    {
        Cursor.SetCursor(clickcursor, Vector2.zero, CursorMode.Auto);
        
    }

    public void toiletChange()
    {
        toiletWithKey.SetActive(false);
        toiletWithoutKey.SetActive(true);

        hasYellowKey = true;
    }

    public void changeLocationDoorToLevel2()
    {
        if(hasYellowKey == true)
        {
            doorOne.SetActive(false);
            level2Scene.SetActive(true);
            location = "Living Room";
            currentLocationText.text = location;
            Cursor.SetCursor(defultcursor, Vector2.zero, CursorMode.Auto);



            scaryFace.SetActive(true);

        }
        else
        {
            //Play Locked Sound
        }
        
    }

    public void changeLocationDoorToBedroom()
    {
        
            doorOne.SetActive(false);
            level1Scene.SetActive(true);
            location = "Bedroom";
            currentLocationText.text = location;
            Cursor.SetCursor(defultcursor, Vector2.zero, CursorMode.Auto);

    }

    public void ExitMouse()
    {
        Cursor.SetCursor(defultcursor, Vector2.zero, CursorMode.Auto);
        
    }

}
