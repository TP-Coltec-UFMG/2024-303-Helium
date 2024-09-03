using System.Collections; using System.Collections.Generic; 
using UnityEngine; 
/* Tarefas para o Level Builder: 
 * - Criar a grid - Posicionar o sol 
 * - Posicionar o feixe de luz 
 * - Instanciar as maçãs e posiciona-las 
 *   */ 

public class LevelBuilder : MonoBehaviour { 
    public bool doDevMode = false; 
    [SerializeField] private int columns, rows; 
    [SerializeField] private GameObject _tilePrefab; 
    [SerializeField] private GameObject _SolPrefab; 
    [SerializeField] private GameObject _FeixeDeLuzPrefab; 

    private GameObject Sol; 
    private GameObject FeixeDeLuz; 

    GameObject levelGrid; 
    private GridManager gridManager; 

    private float TILE_WIDTH; private float TILE_HEIGHT;


    // Start is called before the first frame update
    void Awake()
    {
	Debug.Log("Level Builder Awake");
 //*  - Criar a grid
	levelGrid = new GameObject("levelGrid", typeof(GridManager));

 	TILE_WIDTH = _tilePrefab.transform.localScale.x;
 	TILE_HEIGHT = _tilePrefab.transform.localScale.y;

	gridManager = levelGrid.GetComponent<GridManager>();

        gridManager.tilePrefab = _tilePrefab;
	gridManager.doDevMode = doDevMode;
 	gridManager.offsetX = ((columns * TILE_WIDTH)/2 - TILE_WIDTH/2) * -1; 
 	gridManager.offsetY = ((rows * TILE_HEIGHT)/2 - TILE_HEIGHT/2) * -1;
 	gridManager.grid = new GameObject[columns, rows];
 	gridManager.GenerateGrid();
//=========================================

	Vector3 pontoInicialLuz = gridManager.grid[0,8].transform.position + new Vector3(0,TILE_HEIGHT*3,0);

 //*  - Posicionar o feixe de luz
	FeixeDeLuz = Instantiate(_FeixeDeLuzPrefab, pontoInicialLuz, Quaternion.identity);
	FeixeDeLuz.GetComponent<movimento_do_raio>().posInicial = pontoInicialLuz;
 //*  - Posicionar o sol
	Sol = Instantiate(_SolPrefab, pontoInicialLuz, Quaternion.identity);
	Sol.GetComponent<RaioLuzToggle>().ObjetoFeixeDeLuz = FeixeDeLuz;
    }

    void OnEnable()
    {
	Debug.Log("Level Builder OnEnable");
    }

    void Start()
    {
	Debug.Log("Level Builder Start");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void posicionarSol()
    {
	GameObject sol = GameObject.Find("SOL");
	GameObject raio = GameObject.Find("LightSource");
	GameObject primeiroTile = GameObject.Find("Tile(0:8)");

	sol.GetComponent<Transform>().position = primeiroTile.GetComponent<Transform>().position +
	    new Vector3(0, 3, 0);
	raio.GetComponent<Transform>().position = sol.GetComponent<Transform>().position; 

	raio.GetComponent<LineRenderer>().SetPosition(0, sol.GetComponent<Transform>().position);
	raio.GetComponent<LineRenderer>().SetPosition(raio.GetComponent<LineRenderer>().positionCount - 1, sol.GetComponent<Transform>().position);
    }

}
