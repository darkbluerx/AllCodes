using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private Transform mainCamera; //ammutaan mainkameran suunnasta
    [SerializeField]
    private GameObject particles;

    [SerializeField] // t‰ll‰ voidaan esim tuhota kaikki objektit
    private List<GameObject> cubeList = new List<GameObject>();

    [SerializeField]
    private GameObject areYouSureText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F)) //lis‰t‰‰n lista, jonka cubet voidaan tuhota F-n‰pp‰imell‰
        {
            for (int i=0; i < cubeList.Count; i++)
            {
                Destroy(cubeList[i]);//tuhotaan listan cubet i
                
            }
            cubeList = new List<GameObject>(); // luodaan peliobjekteista lista
        }

        //t‰ll‰ tuhotaan kaikki kent‰n cubet, myˆs valmiina olevat kent‰ss‰. muista laittaa cubeille tag "Cube"
        if (Input.GetKeyDown(KeyCode.T))
        {
            areYouSureText.SetActive(true); //painaessa te tulee Are you sure Y/N teksti
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            areYouSureText.SetActive(false); //kysymysteksti l‰htee pois
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            
            if (areYouSureText.activeSelf) DestroyAll();
            areYouSureText.SetActive(false);//kysymysteksti l‰htee pois
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo; // saadaan raycast kirjasto ylˆs, jotta voidaan m‰‰ritell‰ mihin ray osuu
            if (Physics.Raycast(mainCamera.position, mainCamera.forward, out hitInfo, 100f))//m‰‰ritet‰‰n ampuminen kameran keskipisteest‰, m‰‰ritet‰‰n ampumisen suunta,
                                                                                            //out hitinfo = m‰‰ritet‰‰n mihin soutaan, 100f = ray pituus
            {
                GameObject go = Instantiate(particles, hitInfo.point, Quaternion.identity);
                //Intantiate m‰‰ritell‰‰n osumaan kohtaan syntyy partikkeli, hitinfo = osuma kohta, m‰‰ritell‰‰n objektin pyˆritys kulma
                //Intantie palauttaa ina gameobjektin
                go.transform.tag = "Cube";
                cubeList.Add(go); //lis‰t‰‰n ammuttu cube listaan
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(mainCamera.position, mainCamera.forward, out hitInfo, 100f))                                                                                         
            {
                if (hitInfo.transform.CompareTag("Cube")) Destroy(hitInfo.transform.gameObject);
                // tuhotaan vain ammutut Cubet, ei tarvitse olla tagia erikseen laitettu objektille
                // tuhotaan ampumakohta pinta                
            }
        }
    }  

    private void DestroyAll()
    {
        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cube");
        for (int i = 0; i < cubes.Length; i++)
        {
            Destroy(cubes[i]);//tuhotaan listan cubet i
        }
        cubeList = new List<GameObject>();
    }
}
