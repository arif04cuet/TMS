using System.Runtime.InteropServices;

namespace Msi.UtilityKit
{
    public static class OSUtilities
    {

#if !CLR2COMPATIBILITY
        private static bool? _isWindows;
#endif

        /// <summary>
        /// Gets a flag indicating if we are running under some version of Windows
        /// </summary>
        public static bool IsWindows
        {
#if CLR2COMPATIBILITY
            get { return true; }
#else
            get
            {
                if (_isWindows == null)
                {
                    _isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
                }
                return _isWindows.Value;
            }
#endif
        }

    }
}
