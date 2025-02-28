using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : Collectable
{
    public override void Collect() {
        FindObjectOfType<AcidOrbs>().AddOrbs(1);
    }
}
