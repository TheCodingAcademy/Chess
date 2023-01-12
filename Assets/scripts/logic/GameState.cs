using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState
{
    public ChessPieceLogic[, ] chessPieces = new ChessPieceLogic[BoardManager.BOARDSIZE, BoardManager.BOARDSIZE];

    // Start is called before the first frame update
    public GameState()
    {
        InstantiateChessPieces();
    }

    public bool[, ] GetPossibleMoves(int x, int y)
    {
        return chessPieces[x, y].GetMoves(this);
    }

    private void InstantiateChessPieces()
    {
        InstantiateWhitePieces();
        InstantiateBlackPieces();
    }

    public void Move(int prevX, int prevY, int nextX, int nextY)
    {
        ChessPieceLogic tmp = chessPieces[prevX, prevY];
        chessPieces[nextX, nextY] = tmp;
        chessPieces[prevX, prevY] = null;

        tmp.Move(nextX, nextY);
    }

    private void InstantiateWhitePieces()
    {
        chessPieces[0, 0] = new Rock(0, 0, true);
        chessPieces[BoardManager.BOARDSIZE-1, 0] = new Rock(BoardManager.BOARDSIZE - 1, 0, true);
        chessPieces[1, 0] = new Knight(1, 0, true);
        chessPieces[BoardManager.BOARDSIZE - 2, 0] = new Knight(BoardManager.BOARDSIZE - 2, 0, true);
        chessPieces[2, 0] = new Bishop(2, 0, true);
        chessPieces[BoardManager.BOARDSIZE - 3, 0] = new Bishop(BoardManager.BOARDSIZE - 3, 0, true);
        chessPieces[3, 0] = new King(3, 0, true);
        chessPieces[4, 0] = new Queen(4, 0, true);

        for(int i=0; i<BoardManager.BOARDSIZE; i++)
        {
            chessPieces[i, 1] = new Pawn(i, 1, true);
        }
    }

    private void InstantiateBlackPieces()
    {
        chessPieces[0, BoardManager.BOARDSIZE - 1] = new Rock(0, BoardManager.BOARDSIZE - 1, false);
        chessPieces[BoardManager.BOARDSIZE - 1, BoardManager.BOARDSIZE - 1] = new Rock(BoardManager.BOARDSIZE - 1,
            BoardManager.BOARDSIZE - 1, false);
        chessPieces[1, BoardManager.BOARDSIZE - 1] = new Knight(1, BoardManager.BOARDSIZE - 1, false);
        chessPieces[BoardManager.BOARDSIZE - 2, BoardManager.BOARDSIZE - 1] = new Knight(BoardManager.BOARDSIZE - 2,
            BoardManager.BOARDSIZE - 1, false);
        chessPieces[2, BoardManager.BOARDSIZE - 1] = new Bishop(2, BoardManager.BOARDSIZE - 1, false);
        chessPieces[BoardManager.BOARDSIZE - 3, BoardManager.BOARDSIZE - 1] = new Bishop(BoardManager.BOARDSIZE - 3,
            BoardManager.BOARDSIZE - 1, false);
        chessPieces[3, BoardManager.BOARDSIZE - 1] = new King(3, BoardManager.BOARDSIZE - 1, false);
        chessPieces[4, BoardManager.BOARDSIZE - 1] = new Queen(4, BoardManager.BOARDSIZE - 1, false);

        for (int i = 0; i < BoardManager.BOARDSIZE; i++)
        {
            chessPieces[i, BoardManager.BOARDSIZE - 2] = new Pawn(i, BoardManager.BOARDSIZE - 2, false);
        }
    }
}
