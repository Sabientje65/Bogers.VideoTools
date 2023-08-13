
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text;

// extract to own class/folder
// https://learn.microsoft.com/en-us/windows/win32/winprog/windows-data-types
// Explanation behind method suffixes: https://www.reddit.com/r/csharp/comments/1448a72/win32_api_suffixes/

using HWND = System.IntPtr;
using DWORD = System.UInt32;
using LPCVOID = System.Runtime.InteropServices.HandleRef;
using LPSTR = System.Text.StringBuilder;
using LPCSTR = System.String;
using va_list = System.IntPtr;

[SupportedOSPlatform("windows")]
public class Program
{
    public static void Main()
    {
        var instance = new Program();

        Window.HideScrollbar();
        
        // Console.wid
        instance.DrawFrame();
        instance.DrawFrame();
    }

    /// <summary>
    /// Draw the given frame in the console
    ///
    /// Frames are structured as 2 dimensional arrays, the first dimension determines the vertical position
    /// the second dimension determines the horizontal position of the pixels.
    ///
    /// Pixels are a simple structure containing a renderable character and an optional color
    ///
    /// Frames are drawn as-is, any pre-processing (such as downscaling, filters etc) are expected to have taken place prior to passing the frame to the draw routing 
    /// </summary>
    public void DrawFrame()
    {
        // Clear the previous frame
        Console.Clear();
        
        // Determine our visible area
        var dimensions = Dimensions.Current;

        // move from vertical -> horizontal
        for (var vIdx = 0; vIdx < dimensions.Height; vIdx++)
        {
            for (var hIdx = 0; hIdx < dimensions.Width; hIdx++)
            {
                // TODO: Optimize by passing in a buffer per line
                Console.SetCursorPosition(hIdx, vIdx);
                Console.Write('A');
            }
        }
        
    }

    [SupportedOSPlatform("windows")]
    public class Window
    {

        public static HWND GetMainWindowHandle()
        {
            // Apparently there's no 'easy' way to obtain a handle to the current window
            // as recommended as per microsoft documentation, assign a temp name -> perform lookup by name
            // https://learn.microsoft.com/en-us/troubleshoot/windows-server/performance/obtain-console-window-handle

            var originalTitle = Console.Title;
            Console.Title = $"_window - {DateTime.UtcNow.Ticks}";
            
            // recommended to wait a few ms for windows to update the window's title
            Thread.Sleep(40);

            var handle = FindWindowA(null, Console.Title);
            Console.Title = originalTitle;

            return handle;
        }

        public static void HideScrollbar()
        {
            var hwnd = GetMainWindowHandle();
            var ok = ShowScrollBar(hwnd, (int)WhichScrollbar.SB_BOTH, false);
            if (!ok)
            {
                var errorCode = GetLastError();
                var message = GetErrorMessage(errorCode);
                if (String.IsNullOrEmpty(message)) message = $"Failed with errorCode: {errorCode}";

                throw new Exception(message)
                {
                    Data = { { "errorCode", errorCode } }
                };
            }
        }

        private static string? GetErrorMessage(DWORD errorCode)
        {
            FormatMessage(
                DWFlags.FORMAT_MESSAGE_ALLOCATE_BUFFER | DWFlags.FORMAT_MESSAGE_FROM_SYSTEM | DWFlags.FORMAT_MESSAGE_IGNORE_INSERTS,
                new HandleRef(null, IntPtr.Zero),
                errorCode,
                0,
                out var messageBuffer,
                1024,
                IntPtr.Zero
            );


            return messageBuffer?.ToString();
        }
        
        /// <summary>
        /// Show or hide the specified scrollbars for the given window
        /// </summary>
        /// <param name="hWnd">Window handle</param>
        /// <param name="wBar">Targetted scrollbars</param>
        /// <param name="bShow">Whether to show or hide</param>
        /// <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-showscrollbar"/>
        /// <returns>Whether the call succeeded, a succeeding call will yield a non-zero value</returns>
        [DllImport("user32.dll", SetLastError = true)] 
        public static extern bool ShowScrollBar( HWND hWnd, int wBar, bool bShow );

        /// <summary>
        /// Find the handle associated with the given window
        /// </summary>
        /// <param name="lpClassName">Optional, class name or class atom, has to have been registered by a call to RegisterClass or RegisterClassEx</param>
        /// <param name="lpWindowName">Optional, window title, when nothing is provided all windows will match</param>
        /// <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-findwindowa"/>
        /// <returns>Window handle, if the call fails, NULL is returned</returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern HWND FindWindowA(LPCSTR lpClassName, LPCSTR lpWindowName);
        
        /// <summary>
        /// Get the most recent errorcode set for the current thread
        ///
        /// Beware, any subsequent syscalls after the call that set the errorcode may reset it back to 0
        /// </summary>
        /// <see href="https://learn.microsoft.com/en-us/windows/win32/api/errhandlingapi/nf-errhandlingapi-getlasterror"/>
        /// <returns>Error code</returns>
        [DllImport("kernel32.dll")]
        public static extern DWORD GetLastError();

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern DWORD FormatMessage( DWORD dwFlags,  LPCVOID lpSource, DWORD dwMessageId, DWORD dwLanguageId, out LPSTR lpBuffer, DWORD nSize, va_list arguments );

        public static class DWFlags
        {
            public static DWORD FORMAT_MESSAGE_ALLOCATE_BUFFER = 0x00000100;
            public static DWORD FORMAT_MESSAGE_ARGUMENT_ARRAY = 0x00002000;
            public static DWORD FORMAT_MESSAGE_FROM_HMODULE = 0x00000800;
            public static DWORD FORMAT_MESSAGE_FROM_STRING = 0x00000400;
            public static DWORD FORMAT_MESSAGE_FROM_SYSTEM = 0x00001000;
            public static DWORD FORMAT_MESSAGE_IGNORE_INSERTS = 0x00000200;
        }
        
        // https://www.foxite.com/archives/scrollbars-on-form-disable-0000421959.htm
        public static class WhichScrollbar
        {
            /// <summary>
            /// Both standard horizontal and vertical scrollbars
            /// </summary>
            public const DWORD SB_BOTH = 3;

            /// <summary>
            /// Standard horizontal scrollbar
            /// </summary>
            public const DWORD SB_HORZ = 0;

            /// <summary>
            /// Standard vertical scrollbar
            /// </summary>
            public const DWORD SB_VERT = 1;
        }
        
    }

    private readonly struct Dimensions
    {

        public static Dimensions Current => new Dimensions(Console.WindowWidth, Console.WindowHeight);
        
        private Dimensions(int w, int h)
        {
            Width = w;
            Height = h;
        }
        
        public readonly int Width;
        public readonly int Height;


    }
}

