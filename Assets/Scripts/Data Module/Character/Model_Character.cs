using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "ScriptableObjects/Characters")]
public class Model_Character : ScriptableObject
{
    public int Index;
    public string Name;
    public Sprite CharacterSprite;
    public int Price;
}
