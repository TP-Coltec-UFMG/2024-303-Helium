using System.Collections; using System.Collections.Generic; 
using UnityEngine; 
/* Tarefas para o Level Builder: 
 *  - Criar a grid			  (Y) 
 *  - Posicionar o sol			  (Y)
 *  - Posicionar o feixe de luz		  (Y)
 *  - Instanciar as maçãs e posiciona-las (Y)
 *  - Criar Parede envolta da grid
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
 //*  - Posicionar o sol
	Sol = Instantiate(_SolPrefab, pontoInicialLuz, Quaternion.identity);
	Sol.GetComponent<RaioLuzToggle>().ObjetoFeixeDeLuz = FeixeDeLuz;
//*   - Maçãs aleatorias
	ColocarMaca(14012006);
//*   - Parede envolta da grid
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

    public void ColocarMaca(int espermatozoide)
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
	    Instantiate(_Maca, gridMaca, Quaternion.identity);
	}
    }

    public void CriarParedes()
    {

    }

}
