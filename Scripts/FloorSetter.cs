using Unity.VisualScripting;
using UnityEngine;

public class NewEmptyCSharpScript: MonoBehaviour
{
    public GameObject ob1;
    //public GameObject ob2;
    public void Start()
    {
        ob1.transform.position = new Vector3(ob1.transform.position.x, ob1.transform.localScale.y/2, ob1.transform.position.z);
        //ob2.transform.position = new Vector3(ob2.transform.position.x, ob2.transform.localScale.y/2, ob2.transform.position.z);
    }
}
