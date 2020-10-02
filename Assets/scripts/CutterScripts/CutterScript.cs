using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;
using UnityEngine.UI;

public class CutterScript : MonoBehaviour
{

    [SerializeField] Material material;
    [SerializeField] LayerMask layerMask;
    [SerializeField] bool collisioncontrol;
    [SerializeField] CameraShake camerashake;
    [SerializeField] GameObject woodparticle;
    [SerializeField] Transform particletransform;
    [SerializeField] GameObject retrybutton;


    public SlicedHull Cut(GameObject obj, Material material=null)
    {
        return obj.Slice(transform.position,transform.up,material);
            
    }

    private void Start()
    {
        Time.timeScale = 1;
    }
    private void Update()
    {
        if (gameObject.name == "woodparticlesys(Clone)")
        {
            Destroy(gameObject, 5);
        }
    }

    private void CutterFunc()
    {
        Collider[] cutableObj = Physics.OverlapBox(transform.position, new Vector3(0.1f, 1f, 1f), transform.rotation, layerMask);

        foreach (var item in cutableObj)
        {
            SlicedHull cutedobj = Cut(item.gameObject, material);
            GameObject Cuttedleft = cutedobj.CreateUpperHull(item.gameObject, material);
            GameObject Cuttedright = cutedobj.CreateLowerHull(item.gameObject, material);

            AddCompenent(Cuttedleft);
            AddCompenent(Cuttedright);

            Destroy(item.gameObject);

        }

    }


    private void AddCompenent(GameObject obj)
    {
        obj.AddComponent<MeshCollider>().convex = true;
        obj.GetComponent<Rigidbody>();
        obj.AddComponent<Rigidbody>().interpolation = RigidbodyInterpolation.Interpolate;
        obj.GetComponent<Rigidbody>().AddExplosionForce(100, obj.transform.position, 20);
    }


    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "wood")
        {
            CutterFunc(); 
            collisioncontrol = true;
            camerashake.Shaker(); 
        }
        else
        {
            collisioncontrol = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "wood")
        {
            Instantiate(woodparticle,particletransform);
            woodparticle.GetComponent<ParticleSystem>().Play();
            
        }

        if (other.gameObject.tag == "rock")
        {
            Time.timeScale = 0;
            retrybutton.SetActive(true);

        }

    }


   


    public bool getcollisioncontrol()
    {
        return collisioncontrol;

    }
}
