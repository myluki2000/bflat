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

using System.Runtime;
using System.Runtime.InteropServices;
using Internal.Runtime.CompilerHelpers;

namespace System
{
    public partial class Object
    {
#pragma warning disable 169
        // The layout of object is a contract with the compiler.
        internal unsafe MethodTable* m_pMethodTable;
#pragma warning restore 169

        public static unsafe void Free(Object obj) {
            fixed(MethodTable** mt = &obj.m_pMethodTable) {
                StartupCodeHelpers.FreeObject(mt);
            }
        }
    }
}
