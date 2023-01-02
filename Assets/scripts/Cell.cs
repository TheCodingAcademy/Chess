using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    private BoardManager boardManager;

    public void Instantiate(BoardManager boardManager)
    {
        this.boardManager = boardManager;
    }

    public int GetX()
    {
        return (int)transform.position.x;
    }

    public int GetY()
    {
        return (int)transform.position.z;
    }

    public void OnMouseDown()
    {
        boardManager.OnEventTriggered(GetX(), GetY());
    }
}
