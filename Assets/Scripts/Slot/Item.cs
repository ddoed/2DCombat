using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="skill", menuName ="Item/skill")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite IconImage;
    public BaseStrategy skillData;

}
