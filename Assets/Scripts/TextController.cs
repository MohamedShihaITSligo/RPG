using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextController : MonoBehaviour {


    public TextMesh[] texts;

    public void Level(string newText)
    {
        texts[0].text = newText;
    }
    public void Health(string newText)
    {
        texts[1].text = newText;
    }
    public void Killed(string newText)
    {
        texts[2].text = newText;
    }
    public void Fule(string newText)
    {
        texts[3].text = newText;
    }
    public void GoodPoints(string newText)
    {
        texts[4].text = newText;
    }
    public void BadPoints(string newText)
    {
        texts[5].text = newText;
    }
}
