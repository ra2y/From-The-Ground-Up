using UnityEngine;
using OpenBCI.Network.Streams;

public class CursorController : MonoBehaviour
{
    [SerializeField] private Texture2D cursorTextureDefault;
    [SerializeField] private Texture2D holdingCursorTexture;

    [SerializeField] private Vector2 clickPosition = Vector2.zero;

    [SerializeField] private EMGStream Stream;

    [SerializeField] private float emgValue;

    public static bool clenching = false;

    void Start()
    {
        Cursor.visible = true;

        // Use ForceSoftware for testing (more consistent across platforms)
        if (cursorTextureDefault != null)
            Cursor.SetCursor(cursorTextureDefault, clickPosition, CursorMode.ForceSoftware);
    }

    void Update()
    {
        if (Stream.Channels[0] > 0.9f)
        {
            clenching = true;
            if (holdingCursorTexture != null)
                Cursor.SetCursor(holdingCursorTexture, clickPosition, CursorMode.ForceSoftware);
        }
        else
        {
            clenching = false;
            if (cursorTextureDefault != null)
                Cursor.SetCursor(cursorTextureDefault, clickPosition, CursorMode.ForceSoftware);
        }

        // show the holding texture while the button is held
        // if (Input.GetMouseButton(0))
        // {
        //     if (holdingCursorTexture != null)
        //         Cursor.SetCursor(holdingCursorTexture, clickPosition, CursorMode.ForceSoftware);
        // }
        // else
        // {
        //     if (cursorTextureDefault != null)
        //         Cursor.SetCursor(cursorTextureDefault, clickPosition, CursorMode.ForceSoftware);
        // }
    }
}

