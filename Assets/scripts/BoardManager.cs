using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    // Cells
    public GameObject blackCell;
    public GameObject whiteCell;

    // Black pieces
    public GameObject blackPawn;
    public GameObject blackKing;
    public GameObject blackQueen;
    public GameObject blackBishop;
    public GameObject blackKnight;
    public GameObject blackRock;

    // White pieces
    public GameObject whitePawn;
    public GameObject whiteKing;
    public GameObject whiteQueen;
    public GameObject whiteBishop;
    public GameObject whiteKnight;
    public GameObject whiteRock;

    private ChessPiece[, ] chessPieces = new ChessPiece[BOARDSIZE, BOARDSIZE];
    private GameObject[,] cells = new GameObject[BOARDSIZE, BOARDSIZE];
    private ChessPiece selectedChessPiece = null;
    GameState gameState;

    public const int BOARDSIZE = 8;

    void Start()
    {
        gameState = new GameState();
        InstantiateBoard();
        InstantiateChessPieces();
    }

    private void Move(ChessPiece chessPiece, int x, int y)
    {
        int prevx = chessPiece.GetX();
        int prevy = chessPiece.GetY();

        // Update UI
        chessPiece.gameObject.transform.position = new Vector3(x, 0, y);
        chessPieces[x, y] = chessPiece;
        chessPieces[prevx, prevy] = null;

        // Update logic
        gameState = gameState.Move(prevx, prevy, x, y);
        Debug.Log(gameState.isInChess(false));
    }

    public void ShowPossibleMoves(bool[,] possibleMoves)
    {
        for(int x=0; x<BOARDSIZE; x++)
        {
            for (int y = 0; y < BOARDSIZE; y++)
            {
                if(possibleMoves[x, y])
                {
                    cells[x, y].gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                }
            }
        }
    }

    public void ReinitializeColors()
    {
        for (int x = 0; x < BOARDSIZE; x++)
        {
            for (int y = 0; y < BOARDSIZE; y++)
            {
                cells[x, y].GetComponent<MeshRenderer>().material.color = Color.white;
            }
        }
    }

    /* Logic */
    public void OnEventTriggered(int x, int y)
    {
        if(selectedChessPiece == null)
        {
            selectedChessPiece = chessPieces[x, y];

            if (selectedChessPiece != null)
            {
                cells[x, y].GetComponent<MeshRenderer>().material.color = Color.green;
                bool[,] possibleMoves = gameState.GetPossibleMoves(x, y);
                ShowPossibleMoves(possibleMoves);
            }
        }
        else // A chess piece is already selected
        {
            if(chessPieces[x, y] == null)
            {
                ReinitializeColors();
                //cells[selectedChessPiece.GetX(), selectedChessPiece.GetY()].GetComponent<MeshRenderer>().material.color = Color.white;
                Move(selectedChessPiece, x, y);
                selectedChessPiece = null;
            }
            else // Changing selected piece
            {
                ReinitializeColors();
                //cells[selectedChessPiece.GetX(), selectedChessPiece.GetY()].GetComponent<MeshRenderer>().material.color = Color.white;
                selectedChessPiece = chessPieces[x, y];
                cells[x, y].GetComponent<MeshRenderer>().material.color = Color.green;
                bool[,] possibleMoves = gameState.GetPossibleMoves(x, y);
                ShowPossibleMoves(possibleMoves);
            }
        }
        
    }

    /*  Board setup  */

    void InstantiateChessPieces()
    {
        InstantiateWhitePieces();
        InstantiateBlackPieces();
    }

    void InstantiateWhitePieces()
    {
        GameObject go;

        // Rock
        go = Instantiate(whiteRock, new Vector3(0, 0.0f, 0), new Quaternion());
        go.GetComponent <ChessPiece>().Instantiate(true, this);
        chessPieces[0, 0] = go.GetComponent<ChessPiece>();
        go = Instantiate(whiteRock, new Vector3(BOARDSIZE - 1, 0.0f, 0), new Quaternion());
        go.GetComponent<ChessPiece>().Instantiate(true, this);
        chessPieces[BOARDSIZE - 1, 0] = go.GetComponent<ChessPiece>();

        // Knight
        go = Instantiate(whiteKnight, new Vector3(1, 0.0f, 0), new Quaternion());
        go.GetComponent<ChessPiece>().Instantiate(true, this);
        chessPieces[1, 0] = go.GetComponent<ChessPiece>();
        go = Instantiate(whiteKnight, new Vector3(BOARDSIZE - 2, 0.0f, 0), new Quaternion());
        go.GetComponent<ChessPiece>().Instantiate(true, this);
        chessPieces[BOARDSIZE - 2, 0] = go.GetComponent<ChessPiece>();

        // Bishop
        go = Instantiate(whiteBishop, new Vector3(2, 0.0f, 0), new Quaternion());
        go.GetComponent<ChessPiece>().Instantiate(true, this);
        chessPieces[2, 0] = go.GetComponent<ChessPiece>();
        go = Instantiate(whiteBishop, new Vector3(BOARDSIZE - 3, 0.0f, 0), new Quaternion());
        go.GetComponent<ChessPiece>().Instantiate(true, this);
        chessPieces[BOARDSIZE - 3, 0] = go.GetComponent<ChessPiece>();

        // King
        go = Instantiate(whiteKing, new Vector3(3, 0.0f, 0), new Quaternion());
        go.GetComponent<ChessPiece>().Instantiate(true, this);
        chessPieces[3, 0] = go.GetComponent<ChessPiece>();

        // Queen
        go = Instantiate(whiteQueen, new Vector3(4, 0.0f, 0), new Quaternion());
        go.GetComponent<ChessPiece>().Instantiate(true, this);
        chessPieces[4, 0] = go.GetComponent<ChessPiece>();

        // Pawn
        for (int i = 0; i < BOARDSIZE; i++)
        {

            go = Instantiate(whitePawn, new Vector3(i, 0.0f, 1), new Quaternion());
            go.GetComponent<ChessPiece>().Instantiate(true, this);
            chessPieces[i, 1] = go.GetComponent<ChessPiece>();
        }
    }

    void InstantiateBlackPieces()
    {
        GameObject go;

        // Rock
        go = Instantiate(blackRock, new Vector3(0, 0.0f, BOARDSIZE - 1), new Quaternion());
        go.GetComponent<ChessPiece>().Instantiate(false, this);
        chessPieces[0, BOARDSIZE - 1] = go.GetComponent<ChessPiece>();
        go = Instantiate(blackRock, new Vector3(BOARDSIZE - 1, 0.0f, BOARDSIZE - 1), new Quaternion());
        go.GetComponent<ChessPiece>().Instantiate(false, this);
        chessPieces[BOARDSIZE - 1, BOARDSIZE - 1] = go.GetComponent<ChessPiece>();

        // Knight
        go = Instantiate(blackKnight, new Vector3(1, 0.0f, BOARDSIZE - 1), new Quaternion());
        go.GetComponent<ChessPiece>().Instantiate(false, this);
        chessPieces[1, BOARDSIZE - 1] = go.GetComponent<ChessPiece>();
        go = Instantiate(blackKnight, new Vector3(BOARDSIZE - 2, 0.0f, BOARDSIZE - 1), new Quaternion());
        go.GetComponent<ChessPiece>().Instantiate(false, this);
        chessPieces[BOARDSIZE - 2, BOARDSIZE - 1] = go.GetComponent<ChessPiece>();

        // Bishop
        go = Instantiate(blackBishop, new Vector3(2, 0.0f, BOARDSIZE - 1), new Quaternion());
        go.GetComponent<ChessPiece>().Instantiate(false, this);
        chessPieces[2, BOARDSIZE - 1] = go.GetComponent<ChessPiece>();
        go = Instantiate(blackBishop, new Vector3(BOARDSIZE - 3, 0.0f, BOARDSIZE - 1), new Quaternion());
        go.GetComponent<ChessPiece>().Instantiate(false, this);
        chessPieces[BOARDSIZE - 3, BOARDSIZE - 1] = go.GetComponent<ChessPiece>();

        // King
        go = Instantiate(blackKing, new Vector3(3, 0.0f, BOARDSIZE - 1), new Quaternion());
        go.GetComponent<ChessPiece>().Instantiate(false, this);
        chessPieces[3, BOARDSIZE - 1] = go.GetComponent<ChessPiece>();

        // Queen
        go = Instantiate(blackQueen, new Vector3(4, 0.0f, BOARDSIZE - 1), new Quaternion());
        go.GetComponent<ChessPiece>().Instantiate(false, this);
        chessPieces[4, BOARDSIZE - 1] = go.GetComponent<ChessPiece>();

        // Pawn
        for(int i=0; i<BOARDSIZE; i++)
        {

            go = Instantiate(blackPawn, new Vector3(i, 0.0f, BOARDSIZE - 2), new Quaternion());
            go.GetComponent<ChessPiece>().Instantiate(false, this);
            chessPieces[i, BOARDSIZE - 2] = go.GetComponent<ChessPiece>();
        }

    }

    void InstantiateBoard()
    {
        for (int j = 0; j < BOARDSIZE; j++)
        {
            for (int i = 0; i < BOARDSIZE; i++)
            {
                if((i % 2) == (j % 2))
                {
                    cells[i, j] = Instantiate(blackCell, new Vector3(i, 0.0f, j), new Quaternion());
                }
                else
                {
                    cells[i, j] = Instantiate(whiteCell, new Vector3(i, 0.0f, j), new Quaternion());
                }

                cells[i, j].GetComponent<Cell>().Instantiate(this);
            }
        }
    }
}
