using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChessPieceLogic
{
    protected int x;
    protected int y;
    protected bool is_white;

    public ChessPieceLogic(int x, int y, bool is_white)
    {
        this.x = x;
        this.y = y;
        this.is_white = is_white;
    }

    public abstract bool[,] GetMoves(GameState gameState);

    public void ActivateCell(bool[,] possibleMoves, int x, int y, GameState gameState)
    {
        if ((x >= 0) && (x < BoardManager.BOARDSIZE) && (y >= 0) && (y < BoardManager.BOARDSIZE))
        {
            if ((gameState.chessPieces[x, y] == null) || (gameState.chessPieces[x, y].is_white != is_white))
            {
                possibleMoves[x, y] = true;
            }
        }
        
    }

    public void Move(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}
