using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Belt
{
    Belt input, output;
    int? resource;
    float speed;
    float lastTransferTime;
    bool working = true;

    public Belt(Belt cInput, Belt cOutput, int? cResource, float cSpeed) {
        input = cInput;
        output = cOutput;
        resource = cResource;
        speed = cSpeed;
    }

    public IEnumerator transfer() {
        while (working)
        {
            if (input != null) 
            {
                resource = (int?)this.transfer().Current;
                    BeltTest.transfers++;
            }

            yield return resource;
        }
    }

    public void setInput(Belt mInput) {
        input = mInput;
    }

    public void setOutput(Belt mOutput)
    {
        output = mOutput;
    }

    public void setResource(int? mResource) {
        resource = mResource;
    }
}
