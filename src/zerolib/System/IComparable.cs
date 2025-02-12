namespace System;

public interface IComparable {
    int CompareTo(object obj);
}

public interface IComparable<in T> : IComparable {
    int CompareTo(T other);
}