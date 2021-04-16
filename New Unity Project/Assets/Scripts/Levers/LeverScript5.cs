using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript5 : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;

    public GameObject lever6;

    public Texture2D clickcursor;
    public Texture2D defultcursor;

    public static bool isDown6 = true;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if(isDown6 == true)
        {
         ChangeSpriteOne(0);
            isDown6 = false;
        }
        else if(isDown6 == false)
        {
        ChangeSpriteOne(1);
            isDown6 = true;
        }
    }

    void ChangeSpriteOne(int image)
    {
        lever6.GetComponent<SpriteRenderer>().sprite = spriteArray[image];
    }
    private void OnMouseOver()
    {
        Cursor.SetCursor(clickcursor, Vector2.zero, CursorMode.Auto);
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(defultcursor, Vector2.zero, CursorMode.Auto);
    }
}
