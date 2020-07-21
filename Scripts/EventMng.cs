using UnityEngine;
using UnityEngine.Events;

public class ItemPicked : UnityEvent<Item, GameObject> { }
public class ItemRemoved : UnityEvent<Item> { }

public class EventMng : MonoBehaviour
{
    public static ItemPicked OnItemPicked = new ItemPicked();
    public static ItemRemoved OnItemRemoved = new ItemRemoved();

}
