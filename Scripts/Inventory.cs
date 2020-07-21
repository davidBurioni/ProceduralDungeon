using System;
using UnityEngine;
using UnityEngine.UI;


public class Inventory : MonoBehaviour
{
    public static int DiamondCount;
    public Image imgCel1, imgCell2, imgCell3;
    public Text textObj1, textObj2, textObj3;

    Item ip;
    Item firstCell, secondCell, thirdCell;
    int slotSpace;
    Texture2D texture;
    bool start;
    int counterObj1, counterObj2, counterObj3;
    Action<Item> action;
    Sprite startSprite;

    void OnEnable()
    {
        EventMng.OnItemPicked.AddListener(OnAddItemCallback);
        EventMng.OnItemRemoved.AddListener(OnItemRemovedCallback);
        slotSpace = 3;
        start = false;
        counterObj1 = 0;
        counterObj2 = 0;
        counterObj3 = 0;
        DiamondCount = 2;
    }

    void OnAddItemCallback(Item i, GameObject go)
    {
        if (start == false)
        {
            firstCell = i;
            Debug.Log("SetSprite");
            texture = Resources.Load<Texture2D>(i.spritePath) as Texture2D;
            startSprite = imgCel1.sprite;
            imgCel1.sprite = AddSprite(texture);
            imgCel1.transform.GetComponent<InvokeEvent>().Item = i;
            Debug.Log("i: " + imgCel1.transform.GetComponent<InvokeEvent>().Item.objPath);
            Destroy(go);
            start = true;
            slotSpace--;
            IncreaseCounterObject(i);
        }
        else
        {
            if (slotSpace >= 0)
            {
                //Ultima casella
                if (i.objPath != ip.objPath && slotSpace == 1)
                {
                    if (i.objPath == firstCell.objPath || i.objPath == secondCell.objPath)
                    {

                    }
                    else
                    {
                        thirdCell = i;
                        Sprite go3;
                        texture = Resources.Load<Texture2D>(i.spritePath) as Texture2D;
                        go3 = AddSprite(texture);
                        imgCell3.sprite = AddSprite(texture);
                        imgCell3.transform.GetComponent<InvokeEvent>().Item = i;
                        Destroy(go3);
                        slotSpace--;
                    }
                }
                //seconda casella
                if (i.objPath != ip.objPath && slotSpace == 2)
                {
                    secondCell = i;
                    Sprite go2;
                    texture = Resources.Load<Texture2D>(i.spritePath) as Texture2D;
                    go2 = AddSprite(texture);
                    imgCell2.sprite = AddSprite(texture);
                    imgCell2.transform.GetComponent<InvokeEvent>().Item = i;
                    Destroy(go2);
                    slotSpace--;
                }
                IncreaseCounterObject(i);
            }

        }
        ip = i;
    }

    void IncreaseCounterObject(Item i)
    {
        if (i.objPath == firstCell.objPath)
        {
            counterObj1++;
            string value = counterObj1.ToString();
            textObj1.text = "X" + value;
        }
        else if (i.objPath == secondCell.objPath)
        {
            counterObj2++;
            string value = counterObj2.ToString();
            textObj2.text = "X" + value;

        }
        else if (i.objPath == thirdCell.objPath)
        {
            counterObj3++;
            string value = counterObj3.ToString();
            textObj3.text = "X" + value;
        }
    }

    public Sprite AddSprite(Texture2D tex)
    {
        Texture2D _texture = tex;
        Sprite newSprite = Sprite.Create(_texture, new Rect(0f, 0f, _texture.width, _texture.height), new Vector2(0.5f, 0.5f), 128f);
        GameObject sprGameObj = new GameObject();
        sprGameObj.name = "something";
        sprGameObj.AddComponent<SpriteRenderer>();
        SpriteRenderer sprRenderer = sprGameObj.GetComponent<SpriteRenderer>();
        sprRenderer.sprite = newSprite;
        return newSprite;
    }

    public void OnItemRemovedCallback(Item i)
    {
        if (i.objPath == firstCell.objPath)
        {
            counterObj1--;
            string value = counterObj1.ToString();
            textObj1.text = "X" + value;
            if (counterObj1 == 0)
                imgCel1.sprite = startSprite;

            slotSpace++;
            start = false;
        }
        if (secondCell != null)
        {
            if (i.objPath == secondCell.objPath)
            {
                counterObj2--;
                string value = counterObj2.ToString();
                textObj2.text = "X" + value;
                slotSpace++;
                if (counterObj2 == 0)
                    imgCell2.sprite = startSprite;      
            }
        }
        if (thirdCell != null)
        {
            if (i.objPath == thirdCell.objPath)
            {
                counterObj3--;
                string value = counterObj3.ToString();
                textObj3.text = "X" + value;
                if (counterObj3 == 0)
                    imgCell3.sprite = startSprite;
                slotSpace++;
            }
        }
    }
}
