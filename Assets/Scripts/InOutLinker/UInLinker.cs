namespace Core.InOutLinker
{
    using UnityEngine;

    public abstract class UInLinker<T, U, V>
    {
        public abstract UOutLinker<T> OutLinker { get; set; }

        public abstract T Data { get; set; }

        public abstract GameObject GetGameObjectOfComponent(U component);

        private void GetOutLinker(U component, T data)
        {
            var gameObject = GetGameObjectOfComponent(component);
            OutLinker = gameObject.GetComponent<V>() as UOutLinker<T>;
            Link(data);
        }

        private void Link(T data)
        {
            Data = data;
            OutLinker.Continue(Data);
        }
    }
} //TODO : Implement LINK interface in UOutLinker and use this interface to GetComponent. This will allow to link with anything that implement class, not only OutLinker