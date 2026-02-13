using Unity.Mathematics;
using UnityEngine;


public class GameObjectPlacer : MonoBehaviour
{
    public GameObject CornerW;
    public GameObject StraightW;
    public GameObject SmallBox;
    public GameObject MediumBox;
    public GameObject LargeBox;
    public GameObject Floor;

   // private GameObject[] GO;//remove
    private Vector2 MINSpace;
    private Vector2 MAXSpace;

    public int ObNum;
    private int ObLimit=48;
    private int ObMin =20;

    public int ObChance;
    public int RootBox;
    public bool Xsymm;
    public bool Zsymm;

    private void Start()
    {
        Debug.Log("start");
        //placement(StraightW);
        setup();

    }

    private void setup()
    {
        
        MINSpace = new Vector2(0-(Floor.transform.localScale.x/2) + Floor.transform.position.x, 0-(Floor.transform.localScale.z/2)+ Floor.transform.position.x);
        MAXSpace = new Vector2((Floor.transform.localScale.x/2) + Floor.transform.position.x, (Floor.transform.localScale.z/2)+ Floor.transform.position.x);


        if (Xsymm)
        {
            ObLimit /= 2;
            ObMin /= 2;
            MINSpace.x = 0;
        }
        if (Zsymm)
        {
            ObLimit /= 2;
            ObMin /= 2;
            MINSpace.y = 0;
        }

        /* if(ObNum < 1){
         Debug.Log("yeah");
         ObNum = UnityEngine.Random.Range(ObMin, ObLimit);}
         for(int i=0; i < ObNum; i++)
         {
             int rand = UnityEngine.Random.Range(1,5);
             if(rand == 1){
                 placement(CornerW);}
             if(rand == 2){
                 placement(StraightW);}
             if(rand == 3){
                 placement(SmallBox);}
             if(rand == 4){
                 placement(MediumBox);}
             if(rand == 5){
                 placement(LargeBox);}

         }*/

        for (int x =0; x < RootBox; x++)
        {
            for (int y=0; y <RootBox; y++)
            {
                int rand = UnityEngine.Random.Range(1, 100);
                if (rand <= ObChance)
                {
            int rand2 = UnityEngine.Random.Range(1,5);
             if(rand2 == 1){
                 tileplace(CornerW, x, y);}
             if(rand2 == 2){
                 tileplace(StraightW, x, y);}
             if(rand2 == 3){
                 tileplace(SmallBox, x, y);}
             if(rand2 == 4){
                 tileplace(MediumBox, x, y);}
             if(rand2 == 5){
                 tileplace(LargeBox, x, y);}
                }
            }
            
        }



    }
    private void placement(GameObject GO){
        //Instantiate(GO);

        GO.transform.position = new Vector3(UnityEngine.Random.Range(MINSpace.x,MAXSpace.x),GO.transform.localScale.y/2,UnityEngine.Random.Range(MINSpace.y,MAXSpace.y));
        int rotate = UnityEngine.Random.Range(0,360);
        GameObject temp = GO;
        GO.transform.Rotate(0,rotate,0);
        Instantiate(GO);
        GO.transform.rotation = temp.transform.rotation;
        if (Xsymm)
        {
            GO.transform.position = new Vector3(-temp.transform.position.x,temp.transform.position.y,temp.transform.position.z);

            GO.transform.rotation = Quaternion.Inverse(temp.transform.rotation);
            GO.transform.localScale = new Vector3(-temp.transform.localScale.x, temp.transform.localScale.y, temp.transform.localScale.z);
            Instantiate(GO);
            GO.transform.rotation = temp.transform.rotation;
            }
        if (Zsymm)
        {
            GO.transform.position = new Vector3(temp.transform.position.x,temp.transform.position.y,-temp.transform.position.z);
            GO.transform.rotation = Quaternion.Inverse(temp.transform.rotation);
            GO.transform.localScale = new Vector3(temp.transform.localScale.x, temp.transform.localScale.y, -temp.transform.localScale.z);
            Instantiate(GO);
            GO.transform.rotation = temp.transform.rotation;

        }
        if (Xsymm && Zsymm)
        {
            GO.transform.position = new Vector3(-temp.transform.position.x,temp.transform.position.y,temp.transform.position.z);
            GO.transform.rotation = Quaternion.Inverse(temp.transform.rotation);
            GO.transform.localScale = new Vector3(-temp.transform.localScale.x, temp.transform.localScale.y, temp.transform.localScale.z);
            Instantiate(GO);
        }
    }

    private void tileplace(GameObject GO, float x, float y)
    {
        float xpoint= ((x*2) -1) /(RootBox*2);
        float ypoint=((y*2) -1) /(RootBox*2);
        float totalspacex = MAXSpace.x - MINSpace.x;
        float totalspacey = MAXSpace.y - MINSpace.y;
        xpoint = totalspacex*xpoint;
        ypoint = totalspacey*ypoint;
        GO.transform.position = new Vector3(xpoint,GO.transform.localScale.y/2,ypoint);
        Instantiate(GO);
    }

    private void pathgen(GameObject GO)
    {

        Vector2 spawnpos = new Vector2(0,0);

        Vector2 pointpos = new Vector2(RootBox,0);

        Vector2 pathpos = spawnpos;

        float lastmove = spawnpos.y;

        float ymin=1;
        float ymax = RootBox;
        
        while(pathpos.x != pointpos.x){
        int rand = UnityEngine.Random.Range(1,5);
        if(rand < 3){
    

            if(pathpos.y == lastmove){
                for(float i=0; i < RootBox; i++){
                    if(i != pathpos.y){
                        tileplace(GO,pathpos.x,i);}}}
            else if(pathpos.y > lastmove){
                for(float i=0; i < RootBox; i++){
                        if(lastmove < i || pathpos.y > i){
                            tileplace(GO,pathpos.x,i);}}}
                else{
                    for(float i=0; i < RootBox; i++){
                        if(lastmove > i || pathpos.y < i){
                            tileplace(GO,pathpos.x,i);}}}

            ymin=1; ymax=RootBox;
            pathpos.x++;
            }
        if(rand == 3){
                if(pathpos.y != ymin)
                {
                    pathpos.y--;
                    ymax = pathpos.y;
                }
            }
        if(rand == 4){
                if(pathpos.y != ymax)
                {
                    pathpos.y++;
                    ymin = pathpos.y;
                }
            }
        }
    }
}
