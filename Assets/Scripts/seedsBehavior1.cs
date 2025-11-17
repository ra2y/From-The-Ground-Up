using UnityEngine;

public class seedsBehavior1 : MonoBehaviour
{
    private bool isTouching  = false;
    private Vector3 mousePositionOffset;
    private Vector3 originalPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake(){
        originalPosition = transform.position;
    }
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isTouching && CursorController.clenching){
            transform.position = GetMouseWorldPosition();
        } else {
            isTouching = false;
            transform.position = originalPosition;
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
