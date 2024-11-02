using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CyberBlock : NetworkBehaviour
{
    [SerializeField]
    public bool fixedBlock;
    [SerializeField]
    Sprite red, blue, green, black;
    public SpriteRenderer blockColor;
    public BoxCollider2D box;

    [Networked] int randomcolor { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        blockColor = GetComponent<SpriteRenderer>();
        box = GetComponent<BoxCollider2D>();

        if (!fixedBlock)
        {
            StartCoroutine(StartBlock());
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
        SetRandom();
        yield return new WaitForSeconds(2.0f);
        Rpc_newBlock();
    }


    [Rpc(RpcSources.StateAuthority, RpcTargets.All)]
    private void Rpc_newBlock()
    {
        if (randomcolor == 0) StartCoroutine(BlueBlock());
        else if(randomcolor == 1) StartCoroutine(GreenBlock());
    }

    IEnumerator StartBlock()
    {
        yield return new WaitForSeconds(2.0f);
        SetRandom();
        Rpc_newBlock();
    }

    public void SetRandom()
    {
        if (HasStateAuthority)
        {
            randomcolor = Random.Range(0, 2);
        }
    }
}
