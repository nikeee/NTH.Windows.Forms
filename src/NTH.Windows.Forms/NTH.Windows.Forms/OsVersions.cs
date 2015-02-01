using System;

namespace NTH.Windows.Forms
{
    internal static class OsVersions
    {
        public static Version TwoThousand { get { return new Version(5, 0); } }
        public static Version XP { get { return new Version(5, 1); } }
        public static Version Vista { get { return new Version(6, 0); } }
        public static Version Seven { get { return new Version(6, 1); } }
        public static Version Eight { get { return new Version(6, 2); } }
        public static Version EightPointOne { get { return new Version(6, 3); } }
        public static Version Ten { get { throw new NotImplementedException(); } }
    }
}
