using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorMgr : Singleton<CursorMgr>
{
    public Vector3 mouseWorldPos => Camera.current.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
    protected Texture2D cursorTexture;
    protected Texture2D cursorTexture1;
    Vector2 cursorPos;
    bool canClick;
    bool defaultCursor;
    void Start()
    {
        cursorTexture = (Texture2D)Resources.Load("Picture/cursor/cursorNormal");
        cursorTexture1 = (Texture2D)Resources.Load("Picture/cursor/cursorFind");
        cursorPos = new Vector2(25, 25);
        
        DefaultCursor();
        canClick = true;
    }
    
    public void DefaultCursor()
    {
        if(defaultCursor)
        return;
        Cursor.SetCursor(cursorTexture, cursorPos, CursorMode.Auto);
        defaultCursor=true;
    }

    public void FindCursor()
    {
        if(!defaultCursor)
        {
            return;
        }

        Cursor.SetCursor(cursorTexture1, cursorPos, CursorMode.Auto);
        defaultCursor=false;
    }


}
