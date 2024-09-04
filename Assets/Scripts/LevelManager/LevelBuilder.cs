using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 

/* Tarefas para o Level Builder: 
 *  - Criar a grid			  (Y) 
 *  - Posicionar o sol			  (Y)
 *  - Posicionar o feixe de luz		  (Y)
 *  - Instanciar as maçãs e posiciona-las (Y)
 *  - Criar Parede envolta da grid	  (Y)
 *   */ 

public class LevelBuilder : MonoBehaviour { 
    public bool doDevMode = false; 
    [SerializeField] private int columns, rows; 
    [SerializeField] private GameObject _tilePrefab; 
    [SerializeField] private GameObject _SolPrefab; 
    [SerializeField] private GameObject _FeixeDeLuzPrefab; 
    [SerializeField] private GameObject _Maca;

    private GameObject Sol; 
    private GameObject FeixeDeLuz; 

    GameObject levelGrid; 
    private GridManager gridManager; 

    private float TILE_WIDTH; 
    private float TILE_HEIGHT;



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
	FeixeDeLuz.name = "raioSolar";

 //*  - Posicionar o sol
	Sol = Instantiate(_SolPrefab, pontoInicialLuz, Quaternion.identity);
	Sol.GetComponent<RaioLuzToggle>().ObjetoFeixeDeLuz = FeixeDeLuz;
	Sol.name = "Sol";

//*   - Maçãs aleatorias
	ColocarMaca(14012006);
//*   - Parede envolta da grid
	CriarParedes();
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

    public int ColocarMaca(int espermatozoide)
    {
	Random.InitState(espermatozoide);
	
	int amountMaca = Random.Range(1,8);

	int[,] macaPos = new int[amountMaca, 2];

	//Decidir coordenada
	for(int i=0; i<amountMaca; i++)
	{
	    int x = Random.Range(0, columns);
	    int y = Random.Range(0, rows);
	    macaPos[i, 0] = x;
	    macaPos[i, 1] = y;
	}

	for(int i = 0; i<amountMaca; i++)
	{
	    Vector3 gridMaca = gridManager.grid[macaPos[i, 0], macaPos[i, 1]].transform.position;
	    Debug.Log($"Maca {i}: x = {macaPos[i, 0]}, y = {macaPos[i, 1]}");
	    Debug.Log(gridMaca);
	    var maca = Instantiate(_Maca, gridMaca, Quaternion.identity);
	    maca.name = "massan";
	}

	return amountMaca;
    }

    public void CriarParedes()
    {
	
	for(int i=0; i<columns; i++)
	{
	//teto (não tampar o sol)
	    var tileTeto = Instantiate(_tilePrefab, new Vector3(
			gridManager.offsetX + (TILE_WIDTH*i),
			(gridManager.offsetY * -1) + TILE_HEIGHT,
			0), Quaternion.identity);
	    tileTeto.name = $"tileTeto{i}";
	    Destroy(tileTeto.GetComponent<GridCell>());
	    tileTeto.GetComponent<SpriteRenderer>().enabled = false;

	//chão
	    var tileChao = Instantiate(_tilePrefab, new Vector3(
			gridManager.offsetX + (TILE_WIDTH*i),
			gridManager.offsetY + (TILE_HEIGHT*-1),
			0), Quaternion.identity);
	    tileChao.name = $"tileChao{i}";
	    Destroy(tileChao.GetComponent<GridCell>());
	    tileChao.GetComponent<SpriteRenderer>().enabled = false;
	}

	for(int i=0; i<rows; i++)
	{
	//parede direita
	    var tileParedeDir = Instantiate(_tilePrefab, new Vector3(
			gridManager.offsetX + (TILE_WIDTH*-1),
			gridManager.offsetY + (TILE_HEIGHT*i),
			0), Quaternion.identity);
	    tileParedeDir.name = $"tileParedeDir{i}";
	    Destroy(tileParedeDir.GetComponent<GridCell>());
	    tileParedeDir.GetComponent<SpriteRenderer>().enabled = false;

	//parede esquerda
	    var tileParedeEsq = Instantiate(_tilePrefab, new Vector3(
			(gridManager.offsetX * -1) + TILE_WIDTH,
			gridManager.offsetY + (TILE_HEIGHT*i),
			0), Quaternion.identity);
	    tileParedeEsq.name = $"tileParedeEsq{i}";
	    Destroy(tileParedeEsq.GetComponent<GridCell>());
	    tileParedeEsq.GetComponent<SpriteRenderer>().enabled = false;
	}

	//Não tampar o sol
	var tampa = GameObject.Find("tileTeto0");
	if (tampa != null)
	{
	    Destroy(tampa);
	}
    }

}
