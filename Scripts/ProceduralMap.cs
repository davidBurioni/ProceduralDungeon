using System.IO;
using UnityEngine;

public class ProceduralMap : MonoBehaviour
{
    public static GameObject pla;

    public Transform Parent;
    public int amountBush;

    //ALGORITHM 
    int[][] startMatrix;
    int[][] finalMatrix;
    int[] cells;

    public int[] GetCells { get { return cells; } }

    MapSettings ms;


    void Awake()
    {
        CreateMap(Parent);
    }

    private void Start()
    {
        pla = GameObject.Find("Lady Fairy(Clone)");
    }


    private void CreateMap(Transform parent)
    {
        ms = JsonUtility.FromJson<MapSettings>(FunctionMenu.JsonConfig);

        //Inizialiate subarray
        startMatrix = new int[ms.MapHeight][];
        finalMatrix = new int[ms.MapHeight][];

        for (int i = 0; i < startMatrix.Length; i++)
            startMatrix[i] = new int[ms.MapWidth];

        for (int i = 0; i < finalMatrix.Length; i++)
            finalMatrix[i] = new int[ms.MapWidth];

        int[][] newfinal = new int[ms.MapHeight][];
        for (int i = 0; i < newfinal.Length; i++)
            newfinal[i] = new int[ms.MapWidth];

        int[][] cleanWall = new int[ms.MapHeight][];
        for (int i = 0; i < cleanWall.Length; i++)
            cleanWall[i] = new int[ms.MapWidth];

        //set random value in the matrix
        for (int x = 1; x < ms.MapHeight - 1; x++)
        {
            for (int y = 1; y < ms.MapWidth - 1; y++)
            {
                startMatrix[x][y] = Random.Range(0, 2);
            }
        }
        //Apply the algorithm
        for (int i = 0; i < ms.Ncicles; i++)
        {
            AlgorithmCell(startMatrix, finalMatrix);
        }

        //smoothing wall in the map
        CleanMatrix(finalMatrix, cleanWall);
        //add prefabs in basic map (floor, mall,tree)
        AddObjectAtMap(cleanWall, newfinal);

        //save
        //SaveMaps(newfinal, "FinalMapProcedural");
        //copy the maps in int array

        cells = new int[ms.MapWidth * ms.MapHeight];
        for (int i = 0; i < cells.Length; i++)
        {
            for (int j = 0; j < ms.MapWidth; j++)
            {
                int index = i * ms.MapWidth + j;
                if (index >= cells.Length)
                    return;

                cells[index] = newfinal[i][j];
            }
        }
    }

    public void AlgorithmCell(int[][] matrix, int[][] matrix2)
    {
        for (int x = 1; x < ms.MapHeight - 1; x++)
        {
            for (int y = 1; y < ms.MapWidth - 1; y++)
            {
                // find numbers for compare
                int rightNumber = matrix[x + 1][y];
                int leftNumber = matrix[x - 1][y];
                int UpNumber = matrix[x][y - 1];
                int DownNumber = matrix[x][y + 1];

                // Applys som
                int somma = rightNumber + leftNumber + UpNumber + DownNumber;
                if (somma >= ms.AmountCells)
                {
                    matrix2[x][y] = 1;
                }
                else
                {
                    matrix2[x][y] = 0;
                }
            }
        }
    }

    public void SaveMaps(int[][] matrix, string name)
    {
        string path = Application.dataPath + "/Text/" + name + ".txt";
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(ms.MapWidth.ToString(), ms.MapHeight.ToString());
        string value;
        for (int x = 0; x < ms.MapHeight; x++)
        {
            for (int y = 0; y < ms.MapWidth; y++)
            {
                int row = matrix[x][y];
                value = row.ToString();
                writer.Write(value + " ");
            }
            writer.WriteLine();
        }
        writer.Close();
        Debug.Log("creato");

    }

    public void AddObjectAtMap(int[][] matrix, int[][] matrix2)
    {
        bool done = false;
        bool doneMagicRock = false;

        for (int x = 0; x < ms.MapHeight - 1; x++)
        {
            for (int y = 0; y < ms.MapWidth - 1; y++)
            {
                if (x == 0 || y == 0 || x == ms.MapHeight - 2 || y == ms.MapWidth - 2)
                {
                    matrix2[x][y] = 2;
                    continue;
                }
                // find numbers for compare
                int rightNumber = matrix[x + 1][y];
                int leftNumber = matrix[x - 1][y];
                int UpNumber = matrix[x][y - 1];
                int DownNumber = matrix[x][y + 1];
                // Applys som
                int somma = rightNumber + leftNumber + UpNumber + DownNumber;
                if (matrix[x][y] == 1)
                {
                    matrix2[x][y] = 1;
                    continue;
                }
                if (matrix[x][y] == 2)
                {
                    continue;
                }
                //add bush
                if (somma == amountBush)
                {
                    matrix2[x][y] = 3;
                    continue;
                }
                //add chest
                if (somma == 0 && x % ms.XmoduleChest == 0 && y % ms.YmoduleChest == 0)
                {
                    matrix2[x][y] = 4;
                    continue;
                }
                //add player
                if (somma == 0 && x % ms.XmodulePlayer == 0 && done == false && y % ms.YmodulePlayer == 0)
                {
                    matrix2[x][y] = 9;
                    done = true;
                    continue;
                }
                //add magick rock
                if (somma == 0 && x % 5 == 0 && doneMagicRock == false && y % 10 == 0)
                {
                    matrix2[x][y] = 6;
                    doneMagicRock = true;
                    continue;
                }
                //add flowers 
                if (somma == ms.AmountFlower && x % ms.XmoduleFlower == 0)
                {
                    matrix2[x][y] = 8;
                    continue;
                }
                //add enemy 
                if (somma == ms.AmountEnemy && x % ms.XmoduleEnemy == 0 && y % ms.YmoduleEnemy == 0)
                {
                    matrix2[x][y] = 7;
                    continue;
                }
                //add magic flower 
                if (somma <= 1 && x % 5 == 0 && y % 10 == 0)
                {
                    matrix2[x][y] = 5;
                    continue;
                }
            }
        }
    }

    public void CleanMatrix(int[][] matrix, int[][] matrix2)
    {
        for (int x = 1; x < ms.MapHeight - 1; x++)
        {
            for (int y = 1; y < ms.MapWidth - 1; y++)
            {
                // find numbers for compare
                int rightNumber = matrix[x + 1][y];
                int leftNumber = matrix[x - 1][y];

                int UpNumber = matrix[x][y - 1];
                int UpRightNumber = matrix[x + 1][y - 1];
                int UpLeftNumber = matrix[x - 1][y - 1];

                int DownNumber = matrix[x][y + 1];
                int DownRightNumber = matrix[x + 1][y + 1];
                int DownLeftNumber = matrix[x - 1][y + 1];

                // Applys som
                int somma = rightNumber + leftNumber + UpNumber + DownNumber + UpRightNumber + UpLeftNumber + DownLeftNumber + DownRightNumber;

                if (matrix[x][y] == 1)
                {
                    if (somma <= ms.AmountCleanWalls)
                    {
                        matrix2[x][y] = 1;
                    }
                    else
                        matrix2[x][y] = 0;
                }
            }
        }
    }
}