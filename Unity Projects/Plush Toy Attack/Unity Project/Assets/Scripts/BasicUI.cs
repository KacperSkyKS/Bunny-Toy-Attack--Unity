using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class BasicUI : MonoBehaviour
{
    GUIStyle style = new GUIStyle();
    void OnGUI()
    {
        style.fontSize=30;
        style.normal.textColor = Color.yellow;
        style.font = Resources.Load<Font>("Fonts/BlackOpsOne");
        int posX = 5;
        int posY = 50;
        int width = 100;
        int height = 60;
        int buffer = 100;
        List<string> itemList = Managers.Inventory.GetItemList();
        if (itemList.Count == 0)
        {
            GUI.Box(new Rect(posX, posY, width, height), new GUIContent("0", Resources.Load<Texture2D>("Icons/coin")), style);
        }
        foreach (string item in itemList)
        {
            int count = Managers.Inventory.GetItemCount(item);
            Texture2D image = Resources.Load<Texture2D>("Icons/" + item);
            GUI.Box(new Rect(posX, posY, width, height),
            new GUIContent("" + count + "", image),style);
            posX += width + buffer;
        }
    }
}
