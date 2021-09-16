using UnityEngine;
using UnityEngine.Events;

public class ButtonScript : MonoBehaviour
{
    public UnityEvent _event;

    [SerializeField] Color stadart;
    [SerializeField] Color hightlight;

    private void OnMouseEnter()
    {
        GetComponent<Renderer>().material.color = hightlight;
    }

    private void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = stadart;
    }

    public void OnMouseDown()
    {
        Debug.Log("Restart is pressed");
        _event.Invoke();
    }
}
