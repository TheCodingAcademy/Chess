using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChessPieceLogic
{
    protected int x;
    protected int y;
    public bool is_white;
    public bool has_moved = false;


    public int GetX()
    {
        return x;
    }

    public int GetY()
    {
        return y;
    }

    public ChessPieceLogic(int x, int y, bool is_white)
    {
        this.x = x;
        this.y = y;
        this.is_white = is_white;
    }

    public ChessPieceLogic(int x, int y, bool is_white, bool has_moved)
    {
        this.x = x;
        this.y = y;
        this.is_white = is_white;
        this.has_moved = has_moved;
    }

    public abstract bool[,] GetMoves(GameState gameState, bool isRecursive);
    public bool[,] GetMoves(GameState gameState)
    {
        return GetMoves(gameState, false);
    }

    public bool ActivateCell(bool[,] possibleMoves, int nextX, int nextY, GameState gameState, bool isRecursive)
    {
        if ((nextX >= 0) && (nextX < BoardManager.BOARDSIZE) && (nextY >= 0) && (nextY < BoardManager.BOARDSIZE))
        {
            if ((gameState.chessPieces[nextX, nextY] == null) || (gameState.chessPieces[nextX, nextY].is_white != is_white))
            {
                possibleMoves[nextX, nextY] = true;

                if (!isRecursive)
                {
                    GameState newGameState = gameState.Move(x, y, nextX, nextY);
                    if (newGameState.isInChess(is_white))
                    {
                        possibleMoves[nextX, nextY] = false;
                    }
                } 
            }

            return gameState.chessPieces[nextX, nextY] == null;
        }

        return false;
    }

    public void Move(int x, int y)
    {
        this.x = x;
        this.y = y;
        this.has_moved = true;
    }

    public abstract ChessPieceLogic Clone();
}
