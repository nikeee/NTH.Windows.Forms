using System;

namespace NTH.Windows.Forms.NativeTypes
{
    [Flags]
    public enum FlashWindowFlags : uint
    {
        /// <summary>Stop flashing. The system restores the window to its original state.</summary>
        Stop = 0,
        /// <summary>Flash the window caption.</summary>
        Caption = 1,
        /// <summary>Flash the taskbar button.</summary>
        Tray = 2,
        /// <summary>
        /// Flash both the window caption and taskbar button.
        /// This is equivalent to setting the FLASHW_CAPTION | FLASHW_TRAY flags.
        /// </summary>
        All = 3,
        /// <summary>Flash continuously, until the FLASHW_STOP flag is set.</summary>
        Timer = 4,
        /// <summary>Flash continuously until the window comes to the foreground.</summary>
        TimerNoForeground = 12
    }
}
