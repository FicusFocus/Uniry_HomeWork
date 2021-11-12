using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonDragAndDrop : MonoBehaviour , IBeginDragHandler, IDragHandler, IDropHandler
{
    [SerializeField] private Transform _container;

    private Transform _previousParrent;
    private Transform _previousPosition;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log(gameObject.name);
        _previousParrent = transform.parent;
        transform.parent = null;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnDrop(PointerEventData eventData)
    {
        transform.parent = _previousParrent;
    }
}
