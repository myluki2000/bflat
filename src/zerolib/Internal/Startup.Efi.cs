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

using System;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Internal.Runtime.CompilerHelpers
{
    #if UEFI
    unsafe partial class StartupCodeHelpers
    {
        [RuntimeImport("*", "__managed__Main")]
        [MethodImpl(MethodImplOptions.InternalCall)]
        static extern int ManagedMain(int argc, char** argv);

        [RuntimeExport("EfiMain")]
        static long EfiMain(IntPtr imageHandle, EFI_SYSTEM_TABLE* systemTable)
        {
            SetEfiImageHandle(imageHandle);
            SetEfiSystemTable(systemTable);
            ManagedMain(0, null);

            while (true) ;
        }

        internal static unsafe void InitializeCommandLineArgsW(int argc, char** argv)
        {
            // argc and argv are garbage because EfiMain didn't pass any
        }

        internal static string[] GetMainMethodArguments()
        {
            return new string[0];
        }
    }
    #endif

    [StructLayout(LayoutKind.Sequential)]
    public struct EFI_HANDLE
    {
        private IntPtr _handle;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe readonly struct EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL
    {
        private readonly IntPtr _pad0;
        public readonly delegate* unmanaged<void*, char*, void*> OutputString;
        private readonly IntPtr _pad1;
        private readonly IntPtr _pad2;
        private readonly IntPtr _pad3;
        public readonly delegate* unmanaged<void*, uint, void> SetAttribute;
        private readonly IntPtr _pad4;
        public readonly delegate* unmanaged<void*, uint, uint, void> SetCursorPosition;
    }

    [StructLayout(LayoutKind.Sequential)]
    public readonly struct EFI_INPUT_KEY
    {
        public readonly ushort ScanCode;
        public readonly ushort UnicodeChar;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe readonly struct EFI_SIMPLE_TEXT_INPUT_PROTOCOL
    {
        private readonly IntPtr _pad0;
        public readonly delegate* unmanaged<void*, EFI_INPUT_KEY*, ulong> ReadKeyStroke;
    }

    [StructLayout(LayoutKind.Sequential)]
    public readonly struct EFI_TABLE_HEADER
    {
        public readonly ulong Signature;
        public readonly uint Revision;
        public readonly uint HeaderSize;
        public readonly uint Crc32;
        public readonly uint Reserved;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe readonly struct EFI_SYSTEM_TABLE
    {
        public readonly EFI_TABLE_HEADER Hdr;
        public readonly char* FirmwareVendor;
        public readonly uint FirmwareRevision;
        public readonly EFI_HANDLE ConsoleInHandle;
        public readonly EFI_SIMPLE_TEXT_INPUT_PROTOCOL* ConIn;
        public readonly EFI_HANDLE ConsoleOutHandle;
        public readonly EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL* ConOut;
        public readonly EFI_HANDLE StandardErrorHandle;
        public readonly EFI_SIMPLE_TEXT_OUTPUT_PROTOCOL* StdErr;
        public readonly EFI_RUNTIME_SERVICES* RuntimeServices;
        public readonly EFI_BOOT_SERVICES* BootServices;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EFI_TIME
    {
        public ushort Year;
        public byte Month;
        public byte Day;
        public byte Hour;
        public byte Minute;
        public byte Second;
        public byte Pad1;
        public uint Nanosecond;
        public short TimeZone;
        public byte Daylight;
        public byte PAD2;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EFI_TIME_CAPABILITIES
    {
        public uint Resolution;
        public uint Accuracy;
        public byte SetsToZero;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe readonly struct EFI_RUNTIME_SERVICES
    {
        public readonly EFI_TABLE_HEADER Hdr;
        public readonly delegate* unmanaged<EFI_TIME*, EFI_TIME_CAPABILITIES*, ulong> GetTime;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe readonly struct EFI_MEMORY_DESCRIPTOR {
        public readonly uint Type;
        public readonly ulong PhysicalStart; // type maybe should be IntPtr?
        public readonly ulong VirtualStart; // type maybe should be IntPtr?
        public readonly ulong NumberOfPages;
        public readonly ulong Attribute;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe readonly struct EFI_BOOT_SERVICES
    {
        readonly EFI_TABLE_HEADER Hdr;
        private readonly void* pad0;
        private readonly void* pad1;
        private readonly void* pad2;
        private readonly void* pad3;
        public readonly delegate* unmanaged<nuint*, EFI_MEMORY_DESCRIPTOR*, nuint*, nuint*, uint*, EFI_STATUS> GetMemoryMap;
        public readonly delegate* unmanaged<int, nint, void**, ulong> AllocatePool;
        public readonly delegate* unmanaged<void*, ulong> FreePool;
        private readonly void* pad7;
        private readonly void* pad8;
        private readonly void* pad9;
        private readonly void* pad10;
        private readonly void* pad11;
        private readonly void* pad12;
        private readonly void* pad13;
        private readonly void* pad14;
        private readonly void* pad15;
        private readonly void* pad16;
        private readonly void* pad17;
        private readonly void* pad18;
        private readonly void* pad19;
        private readonly void* pad20;
        private readonly void* pad21;
        private readonly void* pad22;
        private readonly void* pad23;
        private readonly void* pad24;
        private readonly void* pad26;
        public readonly delegate* unmanaged<IntPtr, nuint, EFI_STATUS> ExitBootServices;
        private readonly void* pad27;
        public readonly delegate* unmanaged<uint, ulong> Stall;
        private readonly void* pad28; // SetWatchdogTimer
        private readonly void* pad29; // ConnectController
        private readonly void* pad30; // DisconnectController
        private readonly void* pad31; // OpenProtocol
        private readonly void* pad32; // CloseProtocol
        private readonly void* pad33; // OpenProtocolInformation
        private readonly void* pad34; // ProtocolsPerHandle
        private readonly void* pad35; // LocateHandleBuffer
        public readonly delegate* unmanaged<EFI_GUID*, void*, void**, EFI_STATUS> LocateProtocol;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct EFI_GUID {
        public readonly uint Data1;
        public readonly ushort Data2;
        public readonly ushort Data3;
        public fixed byte Data4[8];

        public EFI_GUID(uint data1, ushort data2, ushort data3, byte data4_0, byte data4_1, byte data4_2, byte data4_3, byte data4_4, byte data4_5, byte data4_6, byte data4_7) {
            Data1 = data1;
            Data2 = data2;
            Data3 = data3;
            Data4[0] = data4_0;
            Data4[1] = data4_1;
            Data4[2] = data4_2;
            Data4[3] = data4_3;
            Data4[4] = data4_4;
            Data4[5] = data4_5;
            Data4[6] = data4_6;
            Data4[7] = data4_7;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe readonly struct EFI_GRAPHICS_OUTPUT_PROTOCOL {
        public readonly delegate* unmanaged<EFI_GRAPHICS_OUTPUT_PROTOCOL*, uint, nuint*, EFI_GRAPHICS_OUTPUT_MODE_INFORMATION**, EFI_STATUS> QueryMode;
        public readonly delegate* unmanaged<EFI_GRAPHICS_OUTPUT_PROTOCOL*, uint, EFI_STATUS> SetMode;
        public readonly delegate* unmanaged<EFI_GRAPHICS_OUTPUT_PROTOCOL*, EFI_GRAPHICS_OUTPUT_BLT_PIXEL*, EFI_GRAPHICS_OUTPUT_BLT_OPERATION, nuint, nuint, nuint, nuint, nuint, nuint, nuint, EFI_STATUS> Blt;
        public readonly EFI_GRAPHICS_OUTPUT_PROTOCOL_MODE* Mode;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe readonly struct EFI_GRAPHICS_OUTPUT_BLT_PIXEL {
        public readonly byte Blue;
        public readonly byte Green;
        public readonly byte Red;
        public readonly byte Reserved;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe readonly struct EFI_GRAPHICS_OUTPUT_PROTOCOL_MODE {
        public readonly uint MaxMode;
        public readonly uint Mode;
        public readonly EFI_GRAPHICS_OUTPUT_MODE_INFORMATION* Info;
        public readonly nuint SizeOfInfo;
        public readonly nuint FrameBufferBase; // is this type correct?
        public readonly nuint FrameBufferSize;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe readonly struct EFI_GRAPHICS_OUTPUT_MODE_INFORMATION {
        public readonly uint Version;
        public readonly uint HorizontalResolution;
        public readonly uint VerticalResolution;
        public readonly EFI_GRAPHICS_PIXEL_FORMAT PixelFormat;
        public readonly EFI_PIXEL_BITMASK PixelInformation;
        public readonly uint PixelsPerScanLine;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe readonly struct EFI_PIXEL_BITMASK {
        public readonly uint RedMask;
        public readonly uint GreenMask;
        public readonly uint BlueMask;
        public readonly uint ReservedMask;
    }

    public enum EFI_GRAPHICS_PIXEL_FORMAT : uint {
        PixelRedGreenBlueReserved8BitPerColor,
        PixelBlueGreenRedReserved8BitPerColor,
        PixelBitMask,
        PixelBltOnly,
        PixelFormatMax
    }

    public enum EFI_GRAPHICS_OUTPUT_BLT_OPERATION : uint {
        EfiBltVideoFill,
        EfiBltVideoToBltBuffer,
        EfiBltBufferToVideo,
        EfiBltVideoToVideo,
        EfiGRaphicsOutputBltOperationMax
    }

    public enum EFI_STATUS : ulong {
        // TODO: Shouldn't hardcode the bit width to 64 if we want to support 32-bit systems
        EFI_SUCCESS =	    	0,
        EFI_LOAD_ERROR =		0x8000000000000001,
        EFI_INVALID_PARAMETER =	0x8000000000000002,
        EFI_UNSUPPORTED	=	    0x8000000000000003,
        EFI_BAD_BUFFER_SIZE	=   0x8000000000000004,
        EFI_BUFFER_TOO_SMALL =	0x8000000000000005,
        EFI_NOT_READY =		    0x8000000000000006,
        EFI_DEVICE_ERROR =	    0x8000000000000007,
        EFI_WRITE_PROTECTED =	0x8000000000000008,
        EFI_OUT_OF_RESOURCES =	0x8000000000000009,
        EFI_NOT_FOUND = 		0x800000000000000E,
        EFI_TIMEOUT =   		0x8000000000000012,
        EFI_ABORTED =   		0x8000000000000015,
        EFI_SECURITY_VIOLATION =0x800000000000001A,
    }
}
