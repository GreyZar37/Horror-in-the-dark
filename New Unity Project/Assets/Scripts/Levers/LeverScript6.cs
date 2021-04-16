using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript6 : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;

    public GameObject lever7;

    public Texture2D clickcursor;
    public Texture2D defultcursor;

    public static bool isDown7 = true;
   

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
        if(isDown7 == true)
        {
         ChangeSpriteOne(0);
            isDown7 = false;
        }
        else if(isDown7 == false)
        {
        ChangeSpriteOne(1);
            isDown7 = true;
        }
    }

    void ChangeSpriteOne(int image)
    {
        lever7.GetComponent<SpriteRenderer>().sprite = spriteArray[image];
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
