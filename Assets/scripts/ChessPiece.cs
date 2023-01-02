using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPiece : MonoBehaviour
{
    private bool isWhite = true;
    private BoardManager boardManager;

    public void Instantiate(bool isWhite, BoardManager boardManager)
    {
        this.isWhite = isWhite;
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
