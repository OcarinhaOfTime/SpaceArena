﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolable {
    int poolIndex { get; set; }
    void Reset();
}
