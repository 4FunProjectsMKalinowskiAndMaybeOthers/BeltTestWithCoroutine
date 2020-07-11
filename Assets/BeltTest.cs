using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltTest : MonoBehaviour
{
    public static long transfers = 0;
    public int maxResourceNumber=0;
    float tmpTimeInsert = 0, tmpTimeDebug = 0;
    Belt ending, beggining;
    bool testingBelt = true;
    // Start is called before the first frame update
    void Start()
    {
        if (testingBelt == true)
        {
            testBelt();
        }
        
    }

    public void testBelt() { 
    Belt inTmp = null, outTmp;
    outTmp = ending = new Belt(null, null, maxResourceNumber++, 0.2f);
        for (int i = 0; i< 1000; i++) {
            inTmp = new Belt(null, outTmp, maxResourceNumber++, 0.25f);
            outTmp.setInput(inTmp);
            StartCoroutine(outTmp.transfer());
            outTmp = inTmp;
        }
        if (inTmp != null)
        {
            beggining = inTmp;
            StartCoroutine(inTmp.transfer());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (testingBelt == true)
        {
            tmpTimeInsert += Time.deltaTime;
            tmpTimeDebug += Time.deltaTime;
            if (tmpTimeInsert > 0.1f)
            {
                tmpTimeInsert = 0;
                beggining.setResource(maxResourceNumber++);
            }
            if (tmpTimeDebug > 0.5f) {
                tmpTimeDebug = 0;
                Debug.Log("Max resource number: " + maxResourceNumber + " \tTransfers: " + transfers);
            }
            
        }
    }
}
