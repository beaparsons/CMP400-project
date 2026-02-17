using System.Numerics;
using System.Reflection.Metadata;
using Unity.Mathematics;
using UnityEngine;


public class GameObjectPlacer : MonoBehaviour
{
    public GameObject CornerW;
    public GameObject StraightW;
    public GameObject SmallBox;
    public GameObject MediumBox;
    public GameObject LargeBox;
    public int offset =10;
    public GameObject Floor;
    //cut
    private Vector2 MINSpace;
    //cut
    private Vector2 MAXSpace;
    //cut
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
        string path = Pathgen();
        
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

    private string Pathgen()
    {
        string path;
        path+= "8"
        Vector2 pos = new Vector2(0,0);
        //start at 0,0 and move until reaching 10,0
        float min =-5;
        float max =5;
        Vector2 end = new Vector2(offset,0);
        while(pos.X < end.X){
        int rand = UnityEngine.Random.Range(1,5);
        
        if(rand < 3){
            
            pos.X ++;
            path += "0";
        }
        else if(rand = 3){
            if(pos.Y < max){
            pos.Y ++;
            path += "1";}
        }
        else{
            if(pos.Y > min){
            pos.Y --;
            path += "2";}
        }}

        while(pos.Y != end.Y)
        {
            if(pos.Y > end.Y)
            {
                pos.Y--;
                path +="2";}
            else 
            {
                pos.Y++;
                path +="1";}
        }
        path+= "9";
        return path;
    }

    private void placement(string path)
    {
        float pathFloat = path;
        int temp;
        Vector2 placepos = new Vector2(0,0);
        bool end=false
        while(pathFloat >1){
            pathFloat/10;}
        while(end){
            pathFloat *=10;
            temp =pathFloat;
            switch(temp){
                case 0:
                    placepos.X++;
                    //place object
                    break;
                case 1:
                    placepos.Y++;
                    //place object
                    break;
                case 2:
                    placepos.Y--;
                    //place object
                    break;
                case 9:
                    end =true;
                    break;
                default:
                    break;
            }
        }
    }
}
