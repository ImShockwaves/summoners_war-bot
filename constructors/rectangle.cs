using System.Runtime.InteropServices;
using System;

namespace sw_bot.constructors
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
    public int Left;
    public int Top;
    public int Right;
    public int Bottom;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct WINDOWINFO
    {
        public uint cbSize;
        public RECT rcWindow;
        public RECT rcClient;
        public uint dwStyle;
        public uint dwExStyle;
        public uint dwWindowStatus;
        public uint cxWindowBorders;
        public uint cyWindowBorders;
        public ushort atomWindowType;
        public ushort wCreatorVersion;
        
        public WINDOWINFO(Boolean? filler) : this() {
            cbSize = (UInt32)(Marshal.SizeOf(typeof(WINDOWINFO)));
        }   
    }
}