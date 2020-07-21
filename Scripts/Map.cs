using UnityEngine;

public class Map : MonoBehaviour
{
    private int width;
    private int height;
    private int[] cells;

    public int Level { get { return level; } }
    protected int level;

    public GameObject Wall, Floor, tree, rock, Bush, Chest, Player, Flower, Grass, Enemy, Enemy2, Enemy3, Warp;
    public Transform Parent;

    public ProceduralMap PM;
    MapSettings ms;

    private void Awake()
    {
        ms = JsonUtility.FromJson<MapSettings>(FunctionMenu.JsonConfig);
        this.width = ms.MapWidth;
        this.height = ms.MapHeight;
        this.cells = PM.GetCells;

        for (int i = 0; i < cells.Length; i++)
        {
            float x = i % width + 0.5f;
            float y = i / width + 0.5f;

            //Instanciate Floor
            if (cells[i] == 0)
            {
                GameObject go;
                go = Instantiate(Floor, Parent);
                go.transform.position = new Vector3(x, 0, y);
                continue;
            }
            //Instanciate Wall
            else if (cells[i] == 1)
            {
                GameObject go;
                go = Instantiate(Wall, Parent);
                go.transform.position = new Vector3(x, 1, y);
                continue;
            }
            //Instanciate Tree
            else if (cells[i] == 2)
            {
                GameObject go;
                go = Instantiate(Floor, Parent);
                go.transform.position = new Vector3(x, 0, y);

                GameObject go2;
                go2 = Instantiate(tree, Parent);
                go2.transform.position = new Vector3(x, 0, y);
                continue;
            }
            //Instanciate bush
            else if (cells[i] == 3)
            {
                GameObject go;
                go = Instantiate(Floor, Parent);
                go.transform.position = new Vector3(x, 0, y);

                GameObject go2;
                go2 = Instantiate(Bush, Parent);
                go2.transform.position = new Vector3(x, 0.1f, y);
                continue;
            }
            //Instanciate Chest
            else if (cells[i] == 4)
            {
                GameObject go;
                go = Instantiate(Floor, Parent);
                go.transform.position = new Vector3(x, 0, y);

                GameObject go2;
                go2 = Instantiate(Chest, Parent);
                go2.transform.position = new Vector3(x, 0.07f, y);
                continue;
            }
            //Instanciate Player
            else if (cells[i] == 9)
            {
                GameObject go;
                go = Instantiate(Floor, Parent);
                go.transform.position = new Vector3(x, 0, y);

                GameObject go2;
                go2 = Instantiate(Player, Parent);
                go2.transform.position = new Vector3(x, 0.45f, y);
                continue;
            }
            //Instanciate Flower
            else if (cells[i] == 8)
            {
                GameObject go;
                go = Instantiate(Floor, Parent);
                go.transform.position = new Vector3(x, 0, y);

                int random = Random.Range(0, 2);
                if (random == 0)
                {
                    GameObject go2;
                    go2 = Instantiate(Flower, Parent);
                    go2.transform.position = new Vector3(x, 0.1f, y);
                    continue;
                }
                else
                {
                    GameObject go2;
                    go2 = Instantiate(Grass, Parent);
                    go2.transform.position = new Vector3(x, 0.1f, y);
                    continue;
                }
            }
            //Instanciate Enemy
            else if (cells[i] == 7)
            {
                GameObject go;
                go = Instantiate(Floor, Parent);
                go.transform.position = new Vector3(x, 0, y);

                int random = Random.Range(0, 3);
                GameObject go2;
                if (random == 0)
                {
                    go2 = Instantiate(Enemy, Parent);
                    go2.transform.position = new Vector3(x, 0.55f, y);
                    continue;
                }
                else if (random == 1)
                {
                    go2 = Instantiate(Enemy2, Parent);
                    go2.transform.position = new Vector3(x, 0.55f, y);
                    continue;
                }
                else if (random == 2)
                {
                    go2 = Instantiate(Enemy3, Parent);
                    go2.transform.position = new Vector3(x, 0.55f, y);
                    continue;
                }
            }
            //instanciate Magic Rock
            else if (cells[i] == 6)
            {
                GameObject go;
                go = Instantiate(Floor, Parent);
                go.transform.position = new Vector3(x, 0, y);

                GameObject go2;
                go2 = Instantiate(rock, Parent);
                go2.transform.position = new Vector3(x, 0, y);
                continue;
            }
            //Instaciate Warp
            else if (cells[i] == 5)
            {
                GameObject go;
                go = Instantiate(Floor, Parent);
                go.transform.position = new Vector3(x, 0, y);

                GameObject go2;
                go2 = Instantiate(Warp, Parent);
                go2.transform.position = new Vector3(x, 0, y);
                continue;
            }
        }
    } 
}
