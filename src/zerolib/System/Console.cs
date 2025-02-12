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
    public enum ConsoleColor
    {
        Black, DarkBlue, DarkGreen, DarkCyan, DarkRed, DarkMagenta, DarkYellow,
        Gray, DarkGray, Blue, Green, Cyan, Red, Magenta, Yellow, White
    }

    public enum ConsoleKey
    {
        Escape = 27,
        LeftArrow = 37,
        UpArrow = 38,
        RightArrow = 39,
        DownArrow = 40,
    }

    public readonly struct ConsoleKeyInfo
    {
        public ConsoleKeyInfo(char keyChar, ConsoleKey key, bool shift, bool alt, bool control)
        {
            Key = key;
        }

        public readonly ConsoleKey Key;
    }

    public static unsafe partial class Console
    {
        public static bool Enabled { get; set; } = true;

        public static void WriteLine(string s)
        {
            if(!Enabled) return;

            for (int i = 0; i < s.Length; i++)
                Console.Write(s[i]);

            WriteLine();
        }

        public static void WriteLine() {
            if(!Enabled) return;

#if WINDOWS || UEFI
            Console.Write('\r');
#endif
            Console.Write('\n');
        }

        public static void WriteLine(char* c) {
            if(!Enabled) return;

            Write(c);

            WriteLine();
        }

        public static void Write(char* c) {
            if(!Enabled) return;

            if(c == null)
                return;

            while(*c != 0) {
                Console.Write(*c);
                c++;
            }
        }

        public static void Write(string s) {
            if(!Enabled) return;
            
            for (int i = 0; i < s.Length; i++)
                Console.Write(s[i]);
        }

        public static void Write(int i) {
            if(!Enabled) return;

            const int BufferSize = 16;
            char* pBuffer = stackalloc char[BufferSize];
            if (i < 0)
            {
                Write('-');
            }

            char* pEnd = &pBuffer[BufferSize - 1];
            char* pCurrent = pEnd;
            do
            {
                *(pCurrent--) = (char)((i % 10) + '0');
                i /= 10;
            } while (i != 0);

            while (pCurrent <= pEnd)
                Write(*(pCurrent++));
        }

        public static void WriteLine(int i)
        {
            if(!Enabled) return;
            
            Write(i);

            WriteLine();
        }
    }
}
