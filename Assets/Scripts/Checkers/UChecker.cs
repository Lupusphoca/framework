namespace Core.Checkers {

  using UnityEngine;
  using UnityEngine.Events;

  [DisallowMultipleComponent]
  public abstract class UChecker<T> : MonoBehaviour, IChecker {
 
    [SerializeField] bool invertCheck;

    protected abstract UnityEvent<T> ValidObject { get; }
    protected abstract UnityEvent<T> InvalidObject { get; }

    public bool InvertCheck { get => invertCheck; set => invertCheck = value; }
    public virtual T ObjToCheck { get; set; }

    public void Check(T obj) {
      ObjToCheck = obj;
      Check();
    }

    public void Check() {
      if(InvertCheck ^ CheckObject(ObjToCheck)) {
        ValidObject.Invoke(ObjToCheck);
      } else {
        InvalidObject.Invoke(ObjToCheck);
      }
    }

    protected abstract bool CheckObject(T obj);

  }

}