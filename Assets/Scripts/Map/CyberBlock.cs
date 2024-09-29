using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CyberBlock : MonoBehaviour
{
    [SerializeField]
    public bool fixedBlock;
    [SerializeField]
    Sprite red, blue, green, black;
    public SpriteRenderer blockColor;
    public BoxCollider2D box;

    // Start is called before the first frame update
    void Start()
    {
        blockColor = GetComponent<SpriteRenderer>();
        box = GetComponent<BoxCollider2D>();
        if (!fixedBlock)
        {
            newBlock();
        }
    }

    IEnumerator BlueBlock()
    {
        blockColor.sprite = blue;
        blockColor.enabled = true;
        yield return new WaitForSeconds(4.0f);
        StartCoroutine(GreenBlock());
    }

    IEnumerator GreenBlock()
    {
        blockColor.sprite = green;
        blockColor.enabled = true;
        yield return new WaitForSeconds(4.0f);
        StartCoroutine(RedBlock());
    }

    IEnumerator RedBlock()
    {
        blockColor.sprite = red;
        blockColor.enabled = true;
        yield return new WaitForSeconds(4.0f);
        blockColor.enabled = false;
        box.enabled = false;
        yield return new WaitForSeconds(2.0f);
        newBlock();
    }

    public void newBlock()
    {
        int t = Random.Range(0, 2);
        if(t == 0) StartCoroutine(BlueBlock());
        else if(t == 1) StartCoroutine(GreenBlock());
        box.enabled = true;
    }
}
