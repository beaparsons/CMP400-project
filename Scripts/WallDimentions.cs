using UnityEngine;

public class WallDimentions : MonoBehaviour {

    public Transform wall1;
    public Transform wall2;

    public float Wall_1X;
    public float Wall_1Y;
    public float Wall_1Z;

    public float Wall_2X;
    public float Wall_2Y;
    public float Wall_2Z;

    public void Start() {
    Vector3 Scale1 = new Vector3(Wall_1X,Wall_1Y,Wall_1Z);
    wall1.transform.localScale = Scale1;

    Vector3 Scale2 = new Vector3(Wall_2X,Wall_2Y,Wall_2Z);
    wall2.transform.localScale = Scale2;

    wall1.transform.position = wall1.position + new Vector3(Wall_1X/2, Wall_1Y/2, Wall_1Z/2);
    wall2.transform.position = wall2.position + new Vector3(Wall_2X/2, Wall_2Y/2, Wall_2Z/2);
}
}
