using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateRoot : MonoBehaviour
{
    public List<MeshRenderer> growRootMeshes;
    public float timeToGrow = 5;
    public float refreshRate = 0.05f;
    [Range(0,1)]
    public float minGrow;
    [Range(0,1)]
    public float maxGrow;
    private List<Material> growRootsMaterials = new List<Material>();
    private bool fullyGrown = false;
    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i<growRootMeshes.Count; i++){
            for (int j=0; j<growRootMeshes[i].materials.Length; j++){
                if (growRootMeshes[i].materials[j].HasProperty("Grow_")){
                    growRootMeshes[i].materials[j].SetFloat("Grow_", 1);
                    growRootsMaterials.Add(growRootMeshes[i].materials[j]);
                }
            }
        }
        for (int i=0; i<growRootsMaterials.Count; i++){
            StartCoroutine(StartGrowing(growRootsMaterials[i]));
        }
        Invoke("DestroyRoot",10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartGrowing(Material mat){
        float growValue = mat.GetFloat("Grow_");
        if (!fullyGrown){
        while(growValue>0){
                growValue -= 1/(timeToGrow/refreshRate);
                mat.SetFloat("Grow_", growValue);

                yield return new WaitForSeconds(refreshRate);
            }
        }
        if (growValue<=0){
            fullyGrown = true;
        }

    }
    
    public void DestroyRoot(){
        Destroy(this.gameObject);
    }
}
