using UnityEngine;
using UnityEngine.EventSystems;

public class Bubbles : MonoBehaviour, IPointerClickHandler
{

    public NotorieteManager notorieteManager;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("clicked");

        if (notorieteManager != null)
        {
            notorieteManager.BubbleClicked(); // Trigger notoriety increase when clicked
        }
        else
        {
            Debug.LogWarning("NotorieteManager is not assigned.");
        }

        Destroy(gameObject); // Destroy the bubble
    }
}
