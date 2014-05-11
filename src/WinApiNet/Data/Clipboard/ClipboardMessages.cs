namespace WinApiNet.Data.Clipboard
{
    /// <summary>
    /// Defines clipboard-related window messages.
    /// </summary>
    public static class ClipboardMessages
    {
        /// <summary>
        /// Sent to the clipboard owner by a clipboard viewer window to request the name of a <c>CF_OWNERDISPLAY</c>
        /// clipboard format.
        /// </summary>
        public const uint WM_ASKCBFORMATNAME = 0x030C;

        /// <summary>
        /// Sent to the first window in the clipboard viewer chain when a window is being removed from the chain.
        /// </summary>
        public const uint WM_CHANGECBCHAIN = 0x030D;

        /// <summary>
        /// Sent when the contents of the clipboard have changed.
        /// </summary>
        public const uint WM_CLIPBOARDUPDATE = 0x031D;

        /// <summary>
        /// Sent to the clipboard owner when a call to the <see cref="WinClipboard.EmptyClipboard"/> function empties
        /// the clipboard.
        /// </summary>
        public const uint WM_DESTROYCLIPBOARD = 0x0307;

        /// <summary>
        /// Sent to the first window in the clipboard viewer chain when the content of the clipboard changes. This
        /// enables a clipboard viewer window to display the new content of the clipboard.
        /// </summary>
        public const uint WM_DRAWCLIPBOARD = 0x0308;

        /// <summary>
        /// Sent to the clipboard owner by a clipboard viewer window. This occurs when the clipboard contains data in
        /// the <c>CF_OWNERDISPLAY</c> format and an event occurs in the clipboard viewer's horizontal scroll bar. The
        /// owner should scroll the clipboard image and update the scroll bar values.
        /// </summary>
        public const uint WM_HSCROLLCLIPBOARD = 0x030E;

        /// <summary>
        /// Sent to the clipboard owner by a clipboard viewer window when the clipboard contains data in the
        /// <c>CF_OWNERDISPLAY</c> format and the clipboard viewer's client area needs repainting.
        /// </summary>
        public const uint WM_PAINTCLIPBOARD = 0x0309;

        /// <summary>
        /// Sent to the clipboard owner before it is destroyed, if the clipboard owner has delayed rendering one or
        /// more clipboard formats. For the content of the clipboard to remain available to other applications, the
        /// clipboard owner must render data in all the formats it is capable of generating, and place the data on the
        /// clipboard by calling the <see cref="WinClipboard.SetClipboardData"/> function.
        /// </summary>
        public const uint WM_RENDERALLFORMATS = 0x0306;

        /// <summary>
        /// Sent to the clipboard owner if it has delayed rendering a specific clipboard format and if an application
        /// has requested data in that format. The clipboard owner must render data in the specified format and place
        /// it on the clipboard by calling the <see cref="WinClipboard.SetClipboardData"/> function.
        /// </summary>
        public const uint WM_RENDERFORMAT = 0x0305;

        /// <summary>
        /// Sent to the clipboard owner by a clipboard viewer window when the clipboard contains data in the
        /// <c>CF_OWNERDISPLAY</c> format and the clipboard viewer's client area has changed size.
        /// </summary>
        public const uint WM_SIZECLIPBOARD = 0x030B;

        /// <summary>
        /// Sent to the clipboard owner by a clipboard viewer window when the clipboard contains data in the
        /// <c>CF_OWNERDISPLAY</c> format and an event occurs in the clipboard viewer's vertical scroll bar. The owner
        /// should scroll the clipboard image and update the scroll bar values.
        /// </summary>
        public const uint WM_VSCROLLCLIPBOARD = 0x030A;
    }
}