using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;

    public GameObject lever1;

    public Texture2D clickcursor;
    public Texture2D defultcursor;

    public static bool isDown = true;
   

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
        if(isDown == true)
        {
         ChangeSpriteOne(0);
            isDown = false;
        }
        else if(isDown == false)
        {
        ChangeSpriteOne(1);
            isDown = true;
        }
    }

    void ChangeSpriteOne(int image)
    {
        lever1.GetComponent<SpriteRenderer>().sprite = spriteArray[image];
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
