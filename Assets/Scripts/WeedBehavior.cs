using UnityEngine;

public class WeedBehavior : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private bool isTouching  = false;
    private Vector3 mousePositionOffset;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(isTouching && CursorController.clenching){
            Destroy(gameObject);
        } else {

        }
    }

    // void OnMouseDrag()
    // {
    //     transform.position = GetMouseWorldPosition() + mousePositionOffset;
    // }

    // void OnMouseDown()
    // {
    //     isTouching = true;
    //     mousePositionOffset = gameObject.transform.position - GetMouseWorldPosition();
    // }

    void OnMouseOver()
    {
        isTouching = true;
    }
    
    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = Camera.main.WorldToScreenPoint(transform.position).z; // Maintain object's Z-depth
        return Camera.main.ScreenToWorldPoint(mouseScreenPosition);
    }
}