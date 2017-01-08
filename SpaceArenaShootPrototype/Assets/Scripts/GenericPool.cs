using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericPool <T> where T : MonoBehaviour, IPoolable {
    T prefab;
    T[] pool;

    int objPtr = 0;
    int usedObjs = 0;

    public void Setup(int poolSize, T prefab) {
        pool = new T[poolSize];
        this.prefab = prefab;

        for(int i = 0; i < poolSize; i++) {
            pool[i] = GameObject.Instantiate(prefab);
            pool[i].poolIndex = i;
        }
    }

    public T GetProjectile() {
        if(usedObjs > pool.Length) {
            ExpandPool();
        }

        var p = pool[objPtr];
        objPtr = (objPtr + 1) % pool.Length;
        usedObjs++;
        p.gameObject.SetActive(true);
        return p;
    }

    public void RecycleProjectile(T p) {
        pool[p.poolIndex].Reset();
        pool[p.poolIndex].gameObject.SetActive(false);
        int newIndex = (objPtr - usedObjs + pool.Length) % pool.Length;
        Swap(newIndex, p.poolIndex);
        usedObjs--;
    }

    void Swap(int indexA, int indexB) {
        var temp = pool[indexA];
        pool[indexA] = pool[indexB];
        pool[indexB] = pool[indexA];
    }

    void ExpandPool() {
        T[] newPool = new T[pool.Length + 1];
        pool.CopyTo(newPool, 0);
        pool = newPool;
        objPtr = newPool.Length - 1;
        newPool[objPtr] = GameObject.Instantiate(prefab);
    }
}
