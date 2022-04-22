using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFactoryWave {
    GameObject FactoryMethod(int tag, int spawn, int mode);
}
