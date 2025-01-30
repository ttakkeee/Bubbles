using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bubbles : MonoBehaviour, IPointerClickHandler
{

    public NotorieteManager notorieteManager;
    public AudioClip clickSound;
    private AudioSource audioSource;
    [SerializeField] private float soundVolume = 1.0f;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

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

        if (clickSound != null)
        {
            AudioSource.PlayClipAtPoint(clickSound, Camera.main.transform.position, soundVolume);
        }
        Destroy(gameObject); // Destroy the bubble 
    }
}
