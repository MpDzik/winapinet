namespace WinApiNet.IO
{
    using System.Threading;

    /// <summary>
    /// An application-defined callback function used with the <c>ReadFileEx</c> and <c>WriteFileEx</c> functions.
    /// It is called when the asynchronous input and output (I/O) operation is completed or canceled and the calling
    /// thread is in an alertable state (by using the <c>SleepEx</c>, <c>MsgWaitForMultipleObjectsEx</c>,
    /// <c>WaitForSingleObjectEx</c>, or <c>WaitForMultipleObjectsEx</c> function with the <c>fAlertable</c> parameter
    /// set to <c>true</c>).
    /// </summary>
    /// <param name="dwErrorCode">
    /// [in] The I/O completion status. This parameter can be one of the system error codes.
    /// </param>
    /// <param name="dwNumberOfBytesTransfered">
    /// [in] The number of bytes transferred. If an error occurs, this parameter is zero.
    /// </param>
    /// <param name="overlapped">
    /// [in, out] A pointer to the <see cref="NativeOverlapped"/> structure specified by the asynchronous I/O
    /// function. The system does not use the <see cref="NativeOverlapped"/> structure after the completion routine
    /// is called, so the completion routine can deallocate the memory used by the overlapped structure.
    /// </param>
    public unsafe delegate void FileIoCompletionRoutine(
        uint dwErrorCode,
        uint dwNumberOfBytesTransfered,
        NativeOverlapped* overlapped);
}