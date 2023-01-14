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

    public GameState(ChessPieceLogic[,] chessPieces)
    {
        this.chessPieces = chessPieces;
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

    public GameState Move(int prevX, int prevY, int nextX, int nextY)
    {
        ChessPieceLogic[,] newChessPieces = new ChessPieceLogic[BoardManager.BOARDSIZE, BoardManager.BOARDSIZE];
        for(int x=0; x<BoardManager.BOARDSIZE; x++)
        {
            for (int y = 0; y < BoardManager.BOARDSIZE; y++)
            {
                if(chessPieces[x, y] != null)
                {
                    newChessPieces[x, y] = chessPieces[x, y].Clone();
                }
            }
        }

        // ...
        ChessPieceLogic tmp = newChessPieces[prevX, prevY];
        newChessPieces[nextX, nextY] = tmp;
        newChessPieces[prevX, prevY] = null;
        tmp.Move(nextX, nextY);

        if(tmp is King)
        {
            // Rock
            // Large Rock
            if ((prevX - nextX) == 2)
            {

            }
            // Small Rock
            else if ((prevX - nextX) == -2)
            {
                ChessPieceLogic rock = newChessPieces[BoardManager.BOARDSIZE - 1, prevY];
                newChessPieces[nextX - 1, nextY] = rock;
                newChessPieces[BoardManager.BOARDSIZE - 1, prevY] = null;
                rock.Move(nextX - 1, nextY);
            }
        }
        
        return new GameState(newChessPieces);
    }

    private void InstantiateWhitePieces()
    {
        chessPieces[0, 0] = new Rock(0, 0, true);
        chessPieces[BoardManager.BOARDSIZE-1, 0] = new Rock(BoardManager.BOARDSIZE - 1, 0, true);
        chessPieces[1, 0] = new Knight(1, 0, true);
        chessPieces[BoardManager.BOARDSIZE - 2, 0] = new Knight(BoardManager.BOARDSIZE - 2, 0, true);
        chessPieces[2, 0] = new Bishop(2, 0, true);
        chessPieces[BoardManager.BOARDSIZE - 3, 0] = new Bishop(BoardManager.BOARDSIZE - 3, 0, true);
        chessPieces[4, 0] = new King(4, 0, true);
        chessPieces[3, 0] = new Queen(3, 0, true);

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
        chessPieces[4, BoardManager.BOARDSIZE - 1] = new King(4, BoardManager.BOARDSIZE - 1, false);
        chessPieces[3, BoardManager.BOARDSIZE - 1] = new Queen(3, BoardManager.BOARDSIZE - 1, false);

        for (int i = 0; i < BoardManager.BOARDSIZE; i++)
        {
            chessPieces[i, BoardManager.BOARDSIZE - 2] = new Pawn(i, BoardManager.BOARDSIZE - 2, false);
        }
    }

    private List<ChessPieceLogic> GetWhitePieces()
    {
        List<ChessPieceLogic> pieces = new List<ChessPieceLogic>();

        for (int x = 0; x < BoardManager.BOARDSIZE; x++)
        {
            for (int y = 0; y < BoardManager.BOARDSIZE; y++)
            {
                if ((chessPieces[x, y] != null) && (chessPieces[x, y].is_white))
                {
                    pieces.Add(chessPieces[x, y]);
                }
            }
        }

        return pieces;
    }

    private List<ChessPieceLogic> GetBlackPieces()
    {
        List<ChessPieceLogic> pieces = new List<ChessPieceLogic>();

        for (int x = 0; x < BoardManager.BOARDSIZE; x++)
        {
            for (int y = 0; y < BoardManager.BOARDSIZE; y++)
            {
                if ((chessPieces[x, y] != null) && (!chessPieces[x, y].is_white))
                {
                    pieces.Add(chessPieces[x, y]);
                }
            }
        }

        return pieces;
    }

    private King GetBlackKing()
    {
        King blackKing = null;

        for(int x=0; x<BoardManager.BOARDSIZE; x++)
        {
            for (int y = 0; y < BoardManager.BOARDSIZE; y++)
            {
                if((chessPieces[x, y] != null) && (chessPieces[x, y] is King) && (!chessPieces[x, y].is_white))
                {
                    blackKing = (King)chessPieces[x, y];
                    return blackKing;
                }
            }
        }

        return blackKing;
    }

    private King GetWhiteKing()
    {
        King whiteKing = null;

        for (int x = 0; x < BoardManager.BOARDSIZE; x++)
        {
            for (int y = 0; y < BoardManager.BOARDSIZE; y++)
            {
                if ((chessPieces[x, y] != null) && (chessPieces[x, y] is King) && (chessPieces[x, y].is_white))
                {
                    whiteKing = (King)chessPieces[x, y];
                    return whiteKing;
                }
            }
        }

        return whiteKing;
    }

    public bool isInChess(bool isWhiteTurn)
    {
        King king = isWhiteTurn ? GetWhiteKing() : GetBlackKing();
        return isInChess(isWhiteTurn, king.GetX(), king.GetY());
    }

    public bool isInChess(bool isWhiteTurn, int x, int y)
    {
        List<ChessPieceLogic> otherPieces = isWhiteTurn ? GetBlackPieces() : GetWhitePieces();

        foreach (ChessPieceLogic c in otherPieces)
        {
            bool[,] possible_moves = c.GetMoves(this, true);
            if (possible_moves[x, y])
            {
                return true;
            }
        }
        return false;
    }
}
