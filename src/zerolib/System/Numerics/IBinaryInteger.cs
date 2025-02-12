namespace System.Numerics;

public interface IBinaryInteger<TSelf>
    : IComparable<TSelf>, IEquatable<TSelf>
    where TSelf : struct, IBinaryInteger<TSelf> {

        public static abstract TSelf Zero { get; }
        public static abstract TSelf One { get; }

        public static virtual bool operator ==(TSelf left, TSelf right) {
            return left.Equals(right);
        }

        public static virtual bool operator !=(TSelf left, TSelf right) {
            return !left.Equals(right);
        }

        public static abstract TSelf operator +(TSelf left, TSelf right);
        public static virtual TSelf operator +(TSelf value) {
            return value;
        }
        public static abstract TSelf operator -(TSelf left, TSelf right);
        public static virtual TSelf operator -(TSelf value) {
            return TSelf.Zero - value;
        }

        public static virtual TSelf operator ++(TSelf value) {
            return value + TSelf.One;
        }
        public static virtual TSelf operator --(TSelf value) {
            return value - TSelf.One;
        }

        public static abstract TSelf operator *(TSelf left, TSelf right);
        public static abstract TSelf operator /(TSelf left, TSelf right);
        public static abstract TSelf operator %(TSelf left, TSelf right);

        public static virtual unsafe TSelf Create<TOther>(TOther value) where TOther : struct, IBinaryInteger<TOther> {
            TOther* otherPtr = &value;
            TSelf* selfPtr = (TSelf*)otherPtr;
            TSelf selfValue = *selfPtr;
            return selfValue;
        }
}