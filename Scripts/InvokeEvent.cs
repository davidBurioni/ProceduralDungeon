using UnityEngine;
using UnityEngine.EventSystems;



public class InvokeEvent : MonoBehaviour, IPointerClickHandler
{
    public Item Item { get { return item; } set { item = value; } }
    Item item;

    void InvokeEventMethod(Item i)
    {
        EventMng.OnItemRemoved.Invoke(i);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log(name + " OnPointerClick");
        EventMng.OnItemRemoved.Invoke(item);
    }
}
