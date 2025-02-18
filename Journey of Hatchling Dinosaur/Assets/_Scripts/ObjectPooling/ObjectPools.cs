using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class ObjectPools<T> : MonoBehaviour where T : class {

    protected Queue<T> pool;
    protected int poolSize;

    protected void InitializePool(int size) {
        poolSize = size;
        pool = new Queue<T>(size);
    }

    protected T GetObject() {
        if (pool.Count > 0) {
            T obj = pool.Dequeue();
            BorrowObject(obj);
            return obj;
        }
        else {
            return null;
        }
    }

    protected void ReturnObject(T obj) {
        RestoreObject(obj);
        pool.Enqueue(obj);
    }

    protected abstract T CreateNewObject();

    protected abstract void RestoreObject(T obj);

    protected abstract void BorrowObject(T obj);

    protected abstract void DestroyObject(T obj);
}
