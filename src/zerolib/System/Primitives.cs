using System;
using System.Numerics;

// bflat minimal runtime library
// Copyright (C) 2021-2022 Michal Strehovsky
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as published
// by the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.
//
// You should have received a copy of the GNU Affero General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.

namespace System
{
    public struct Void { }

    // The layout of primitive types is special cased because it would be recursive.
    // These really don't need any fields to work.
    public struct Boolean { }
    public struct Char : IBinaryInteger<Char> {
        static Char IBinaryInteger<Char>.Zero => (Char)0;
        static Char IBinaryInteger<Char>.One => (Char)1;

        public static Char operator +(Char left, Char right) {
            return (Char)(left + right);
        }

        public static Char operator -(Char left, Char right) {
            return (Char)(left - right);
        }

        public static Char operator *(Char left, Char right) {
            return (Char)(left * right);
        }
        public static Char operator /(Char left, Char right) {
            return (Char)(left / right);
        }
        public static Char operator %(Char left, Char right) {
            return (Char)(left % right);
        }

        public int CompareTo(Char other) {
            if (this < other)
                return -1;
            if (this > other)
                return 1;
            return 0;
        }

        public int CompareTo(object obj) {
            if(obj == null) {
                return 1;
            }

            if(obj is Char) {
                return CompareTo((Char)obj);
            }

            return -1;
        }

        public bool Equals(Char other) {
            return this == other;
        }
    }

    public struct SByte : IBinaryInteger<SByte> {
        static SByte IBinaryInteger<SByte>.Zero => (SByte)0;
        static SByte IBinaryInteger<SByte>.One => (SByte)1;

        public static SByte operator +(SByte left, SByte right) {
            return (SByte)(left + right);
        }

        public static SByte operator -(SByte left, SByte right) {
            return (SByte)(left - right);
        }

        public static SByte operator *(SByte left, SByte right) {
            return (SByte)(left * right);
        }
        public static SByte operator /(SByte left, SByte right) {
            return (SByte)(left / right);
        }
        public static SByte operator %(SByte left, SByte right) {
            return (SByte)(left % right);
        }

        public int CompareTo(SByte other) {
            if (this < other)
                return -1;
            if (this > other)
                return 1;
            return 0;
        }

        public int CompareTo(object obj) {
            if(obj == null) {
                return 1;
            }

            if(obj is SByte) {
                return CompareTo((SByte)obj);
            }

            return -1;
        }

        public bool Equals(SByte other) {
            return this == other;
        }
    }

    public struct Byte : IBinaryInteger<Byte> { 
        static Byte IBinaryInteger<Byte>.Zero => (Byte)0;
        static Byte IBinaryInteger<Byte>.One => (Byte)1;

        public static Byte operator +(Byte left, Byte right) {
            return (Byte)(left + right);
        }

        public static Byte operator -(Byte left, Byte right) {
            return (Byte)(left - right);
        }

        public static Byte operator *(Byte left, Byte right) {
            return (Byte)(left * right);
        }
        public static Byte operator /(Byte left, Byte right) {
            return (Byte)(left / right);
        }
        public static Byte operator %(Byte left, Byte right) {
            return (Byte)(left % right);
        }

        public int CompareTo(Byte other) {
            if (this < other)
                return -1;
            if (this > other)
                return 1;
            return 0;
        }

        public int CompareTo(object obj) {
            if(obj == null) {
                return 1;
            }

            if(obj is Byte) {
                return CompareTo((Byte)obj);
            }

            return -1;
        }

        public bool Equals(Byte other) {
            return this == other;
        }
    }

    public struct Int16 : IBinaryInteger<Int16> { 
        static Int16 IBinaryInteger<Int16>.Zero => (Int16)0;
        static Int16 IBinaryInteger<Int16>.One => (Int16)1;

        public static Int16 operator +(Int16 left, Int16 right) {
            return (Int16)(left + right);
        }

        public static Int16 operator -(Int16 left, Int16 right) {
            return (Int16)(left - right);
        }

        public static Int16 operator *(Int16 left, Int16 right) {
            return (Int16)(left * right);
        }
        public static Int16 operator /(Int16 left, Int16 right) {
            return (Int16)(left / right);
        }
        public static Int16 operator %(Int16 left, Int16 right) {
            return (Int16)(left % right);
        }

        public int CompareTo(Int16 other) {
            if (this < other)
                return -1;
            if (this > other)
                return 1;
            return 0;
        }

        public int CompareTo(object obj) {
            if(obj == null) {
                return 1;
            }

            if(obj is Int16) {
                return CompareTo((Int16)obj);
            }

            return -1;
        }

        public bool Equals(Int16 other) {
            return this == other;
        }
    }

    public struct UInt16 : IBinaryInteger<UInt16> { 
        static UInt16 IBinaryInteger<UInt16>.Zero => (UInt16)0;
        static UInt16 IBinaryInteger<UInt16>.One => (UInt16)1;

        public static UInt16 operator +(UInt16 left, UInt16 right) {
            return (UInt16)(left + right);
        }

        public static UInt16 operator -(UInt16 left, UInt16 right) {
            return (UInt16)(left - right);
        }

        public static UInt16 operator *(UInt16 left, UInt16 right) {
            return (UInt16)(left * right);
        }
        public static UInt16 operator /(UInt16 left, UInt16 right) {
            return (UInt16)(left / right);
        }
        public static UInt16 operator %(UInt16 left, UInt16 right) {
            return (UInt16)(left % right);
        }

        public int CompareTo(UInt16 other) {
            if (this < other)
                return -1;
            if (this > other)
                return 1;
            return 0;
        }

        public int CompareTo(object obj) {
            if(obj == null) {
                return 1;
            }

            if(obj is UInt16) {
                return CompareTo((UInt16)obj);
            }

            return -1;
        }

        public bool Equals(UInt16 other) {
            return this == other;
        }
    }

    public struct Int32 : IBinaryInteger<Int32> { 
        static Int32 IBinaryInteger<Int32>.Zero => (Int32)0;
        static Int32 IBinaryInteger<Int32>.One => (Int32)1;

        public static Int32 operator +(Int32 left, Int32 right) {
            return (Int32)(left + right);
        }

        public static Int32 operator -(Int32 left, Int32 right) {
            return (Int32)(left - right);
        }

        public static Int32 operator *(Int32 left, Int32 right) {
            return (Int32)(left * right);
        }
        public static Int32 operator /(Int32 left, Int32 right) {
            return (Int32)(left / right);
        }
        public static Int32 operator %(Int32 left, Int32 right) {
            return (Int32)(left % right);
        }

        public int CompareTo(Int32 other) {
            if (this < other)
                return -1;
            if (this > other)
                return 1;
            return 0;
        }

        public int CompareTo(object obj) {
            if(obj == null) {
                return 1;
            }

            if(obj is Int32) {
                return CompareTo((Int32)obj);
            }

            return -1;
        }

        public bool Equals(Int32 other) {
            return this == other;
        }
    }

    public struct UInt32 : IBinaryInteger<UInt32> { 
        static UInt32 IBinaryInteger<UInt32>.Zero => (UInt32)0;
        static UInt32 IBinaryInteger<UInt32>.One => (UInt32)1;

        public static UInt32 operator +(UInt32 left, UInt32 right) {
            return (UInt32)(left + right);
        }

        public static UInt32 operator -(UInt32 left, UInt32 right) {
            return (UInt32)(left - right);
        }

        public static UInt32 operator *(UInt32 left, UInt32 right) {
            return (UInt32)(left * right);
        }
        public static UInt32 operator /(UInt32 left, UInt32 right) {
            return (UInt32)(left / right);
        }
        public static UInt32 operator %(UInt32 left, UInt32 right) {
            return (UInt32)(left % right);
        }

        public int CompareTo(UInt32 other) {
            if (this < other)
                return -1;
            if (this > other)
                return 1;
            return 0;
        }

        public int CompareTo(object obj) {
            if(obj == null) {
                return 1;
            }

            if(obj is UInt32) {
                return CompareTo((UInt32)obj);
            }

            return -1;
        }

        public bool Equals(UInt32 other) {
            return this == other;
        }
    }

    public struct Int64 : IBinaryInteger<Int64> { 
        static Int64 IBinaryInteger<Int64>.Zero => (Int64)0;
        static Int64 IBinaryInteger<Int64>.One => (Int64)1;

        public static Int64 operator +(Int64 left, Int64 right) {
            return (Int64)(left + right);
        }

        public static Int64 operator -(Int64 left, Int64 right) {
            return (Int64)(left - right);
        }

        public static Int64 operator *(Int64 left, Int64 right) {
            return (Int64)(left * right);
        }
        public static Int64 operator /(Int64 left, Int64 right) {
            return (Int64)(left / right);
        }
        public static Int64 operator %(Int64 left, Int64 right) {
            return (Int64)(left % right);
        }

        public int CompareTo(Int64 other) {
            if (this < other)
                return -1;
            if (this > other)
                return 1;
            return 0;
        }

        public int CompareTo(object obj) {
            if(obj == null) {
                return 1;
            }

            if(obj is Int64) {
                return CompareTo((Int64)obj);
            }

            return -1;
        }

        public bool Equals(Int64 other) {
            return this == other;
        }
    }

    public struct UInt64 : IBinaryInteger<UInt64> { 
        static UInt64 IBinaryInteger<UInt64>.Zero => (UInt64)0;
        static UInt64 IBinaryInteger<UInt64>.One => (UInt64)1;

        public static UInt64 operator +(UInt64 left, UInt64 right) {
            return (UInt64)(left + right);
        }

        public static UInt64 operator -(UInt64 left, UInt64 right) {
            return (UInt64)(left - right);
        }

        public static UInt64 operator *(UInt64 left, UInt64 right) {
            return (UInt64)(left * right);
        }
        public static UInt64 operator /(UInt64 left, UInt64 right) {
            return (UInt64)(left / right);
        }
        public static UInt64 operator %(UInt64 left, UInt64 right) {
            return (UInt64)(left % right);
        }

        public int CompareTo(UInt64 other) {
            if (this < other)
                return -1;
            if (this > other)
                return 1;
            return 0;
        }

        public int CompareTo(object obj) {
            if(obj == null) {
                return 1;
            }

            if(obj is UInt64) {
                return CompareTo((UInt64)obj);
            }

            return -1;
        }

        public bool Equals(UInt64 other) {
            return this == other;
        }
    }

    public struct IntPtr : IBinaryInteger<IntPtr> { 
        static IntPtr IBinaryInteger<IntPtr>.Zero => (IntPtr)0;
        static IntPtr IBinaryInteger<IntPtr>.One => (IntPtr)1;

        public static IntPtr operator +(IntPtr left, IntPtr right) {
            return (IntPtr)(left + right);
        }

        public static IntPtr operator -(IntPtr left, IntPtr right) {
            return (IntPtr)(left - right);
        }

        public static IntPtr operator *(IntPtr left, IntPtr right) {
            return (IntPtr)(left * right);
        }
        public static IntPtr operator /(IntPtr left, IntPtr right) {
            return (IntPtr)(left / right);
        }
        public static IntPtr operator %(IntPtr left, IntPtr right) {
            return (IntPtr)(left % right);
        }

        public int CompareTo(IntPtr other) {
            if (this < other)
                return -1;
            if (this > other)
                return 1;
            return 0;
        }

        public int CompareTo(object obj) {
            if(obj == null) {
                return 1;
            }

            if(obj is IntPtr) {
                return CompareTo((IntPtr)obj);
            }

            return -1;
        }

        public bool Equals(IntPtr other) {
            return this == other;
        }
    }

    public struct UIntPtr : IBinaryInteger<UIntPtr> { 
        static UIntPtr IBinaryInteger<UIntPtr>.Zero => (UIntPtr)0;
        static UIntPtr IBinaryInteger<UIntPtr>.One => (UIntPtr)1;

        public static UIntPtr operator +(UIntPtr left, UIntPtr right) {
            return (UIntPtr)(left + right);
        }

        public static UIntPtr operator -(UIntPtr left, UIntPtr right) {
            return (UIntPtr)(left - right);
        }

        public static UIntPtr operator *(UIntPtr left, UIntPtr right) {
            return (UIntPtr)(left * right);
        }
        public static UIntPtr operator /(UIntPtr left, UIntPtr right) {
            return (UIntPtr)(left / right);
        }
        public static UIntPtr operator %(UIntPtr left, UIntPtr right) {
            return (UIntPtr)(left % right);
        }

        public int CompareTo(UIntPtr other) {
            if (this < other)
                return -1;
            if (this > other)
                return 1;
            return 0;
        }

        public int CompareTo(object obj) {
            if(obj == null) {
                return 1;
            }

            if(obj is UIntPtr) {
                return CompareTo((UIntPtr)obj);
            }

            return -1;
        }

        public bool Equals(UIntPtr other) {
            return this == other;
        }
    }

    public struct Single { }

    public struct Double { }
}
