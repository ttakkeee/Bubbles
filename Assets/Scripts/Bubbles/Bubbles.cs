using UnityEngine;
using UnityEngine.EventSystems;

public class Bubbles : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("clicked");
        Destroy(gameObject);
    }
}
