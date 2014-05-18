#include <windows.h>
#include <Pathcch.h>
#include <vcclr.h>
#include <msclr\marshal.h>

using namespace System;
using namespace System::ComponentModel;
using namespace System::Runtime::InteropServices;
using namespace msclr::interop;

namespace WinApiNet
{
	namespace Native
	{
		public ref class WinPathcch 
		{
		public:

			/// <summary>
			/// Converts a path string into a canonical form.
			/// </summary>
			static String^ PathAllocCanonicalize(String^ pathIn, UInt32 dwFlags)
			{
				PWSTR ppszPathOut;
				pin_ptr<const wchar_t> pszPathIn = PtrToStringChars(pathIn);
				HRESULT result = ::PathAllocCanonicalize(pszPathIn, dwFlags, &ppszPathOut);
				if (result != S_OK)
				{
					throw gcnew Win32Exception(result);
				}
				
				String^ pathOut = gcnew String(ppszPathOut);
				LocalFree(ppszPathOut);

				return pathOut;
			}

			/// <summary>
			/// Concatenates two path fragments into a single path. This function also canonicalizes any relative path
			/// elements, replacing path elements such as "." and "..".
			/// </summary>
			static String^ PathAllocCombine(String^ pathIn, String^ more, UInt32 dwFlags) 
			{
				PWSTR ppszPathOut;
				pin_ptr<const wchar_t> pszPathIn = PtrToStringChars(pathIn);
				pin_ptr<const wchar_t> pszMore = PtrToStringChars(more);
				HRESULT result = ::PathAllocCombine(pszPathIn, pszMore, dwFlags, &ppszPathOut);
				if (result != S_OK)
				{
					throw gcnew Win32Exception(result);
				}
				
				String^ pathOut = gcnew String(ppszPathOut);
				LocalFree(ppszPathOut);

				return pathOut;
			}

			/// <summary>
			/// Adds a backslash to the end of a string to create the correct syntax for a path. If the source path
			/// already has a trailing backslash, no backslash will be added.
			/// </summary>
			static String^ PathCchAddBackslash(String^ path) 
			{
				pin_ptr<const wchar_t> pszPath = PtrToStringChars(path);
				const int buflen = path->Length + 2;
				wchar_t *buf = new wchar_t[buflen];
				wmemcpy_s(buf, buflen, pszPath, path->Length + 1);
				
				HRESULT result = ::PathCchAddBackslash(buf, buflen);
				return HandleHResult(result, buf, path);
			}

			/// <summary>
			/// Adds a file name extension to a path string.
			/// </summary>
			static String^ PathCchAddExtension(String^ path, String^ ext)
			{
				pin_ptr<const wchar_t> pszPath = PtrToStringChars(path);
				pin_ptr<const wchar_t> pszExt = PtrToStringChars(ext);
				const int buflen = path->Length + ext->Length + 2;
				wchar_t *buf = new wchar_t[buflen];
				wmemcpy_s(buf, buflen, pszPath, path->Length + 1);
				
				HRESULT result = ::PathCchAddExtension(buf, buflen, pszExt);
				return HandleHResult(result, buf, path);
			}

			/// <summary>
			/// Appends one path to the end of another.
			/// </summary>
			static String^ PathCchAppend(String^ path, String^ more)
			{
				pin_ptr<const wchar_t> pszPath = PtrToStringChars(path);
				pin_ptr<const wchar_t> pszMore = PtrToStringChars(more);
				const int buflen = path->Length + (more != nullptr ? more->Length : 0) + 2;
				wchar_t *buf = new wchar_t[buflen];
				wmemcpy_s(buf, buflen, pszPath, path->Length + 1);

				HRESULT result = ::PathCchAppend(buf, buflen, pszMore);
				return HandleHResult(result, buf);
			}

			/// <summary>
			/// Appends one path to the end of another.
			/// </summary>
			static String^ PathCchAppendEx(String^ path, String^ more, UInt32 flags)
			{
				pin_ptr<const wchar_t> pszPath = PtrToStringChars(path);
				pin_ptr<const wchar_t> pszMore = PtrToStringChars(more);
				const int buflen = path->Length + (more != nullptr ? more->Length : 0) + 2;
				wchar_t *buf = new wchar_t[buflen];
				wmemcpy_s(buf, buflen, pszPath, path->Length + 1);

				HRESULT result = ::PathCchAppendEx(buf, buflen, pszMore, flags);
				return HandleHResult(result, buf);
			}

			/// <summary>
			/// Converts a path string into a canonical form.
			/// </summary>
			static String^ PathCchCanonicalize(String^ pathIn)
			{
				pin_ptr<const wchar_t> pszPathIn = PtrToStringChars(pathIn);
				const int buflen = MAX_PATH + 1;
				wchar_t *buf = new wchar_t[buflen];
				
				HRESULT result = ::PathCchCanonicalize(buf, buflen, pszPathIn);
				return HandleHResult(result, buf);
			}

			/// <summary>
			/// Converts a path string into a canonical form.
			/// </summary>
			static String^ PathCchCanonicalizeEx(String^ pathIn, UInt32 flags)
			{
				pin_ptr<const wchar_t> pszPathIn = PtrToStringChars(pathIn);
				int buflen = pathIn->Length + 1;
				wchar_t *buf = new wchar_t[buflen];

				HRESULT result = ::PathCchCanonicalizeEx(buf, buflen, pszPathIn, flags);
				return HandleHResult(result, buf);
			}

			/// <summary>
			/// Combines two path fragments into a single path. This function also canonicalizes any relative path elements,
			/// removing "." and ".." elements to simplify the final path.
			/// </summary>
			static String^ PathCchCombine(String^ pathIn, String^ more)
			{
				pin_ptr<const wchar_t> pszPathIn = PtrToStringChars(pathIn);
				pin_ptr<const wchar_t> pszMore = PtrToStringChars(more);
				const int buflen = MAX_PATH + 1;
				wchar_t *buf = new wchar_t[buflen];
				
				HRESULT result = ::PathCchCombine(buf, buflen, pszPathIn, pszMore);
				return HandleHResult(result, buf);
			}

			/// <summary>
			/// Combines two path fragments into a single path. This function also canonicalizes any relative path elements,
			/// removing "." and ".." elements to simplify the final path.
			/// </summary>
			static String^ PathCchCombineEx(String^ pathIn, String^ more, UInt32 flags)
			{
				pin_ptr<const wchar_t> pszPathIn = PtrToStringChars(pathIn);
				pin_ptr<const wchar_t> pszMore = PtrToStringChars(more);
				const int buflen = (pathIn != nullptr ? pathIn->Length : 0) + (more != nullptr ? more->Length : 0) + 3;
				wchar_t *buf = new wchar_t[buflen];
				
				HRESULT result = ::PathCchCombineEx(buf, buflen, pszPathIn, pszMore, flags);
				return HandleHResult(result, buf);
			}

			/// <summary>
			/// Searches a path to find its file name extension, such as ".exe" or ".ini".This function does not search for a
			/// specific extension; it searches for the presence of any extension.
			// </summary>
			static String^ PathCchFindExtension(String^ path)
			{
				pin_ptr<const wchar_t> pszPath = PtrToStringChars(path);

				wchar_t *ext;
				HRESULT result = ::PathCchFindExtension((PWSTR)pszPath, path->Length + 1, &ext);
				if (result != S_OK)
				{
					throw gcnew Win32Exception(result);
				}
				
				if (*ext != '\0') 
				{
					return gcnew String(ext);
				}
				
				return nullptr;
			}

			/// <summary>
			/// Determines whether a path string refers to the root of a volume.
			/// </summary>
			static bool PathCchIsRoot(String^ path)
			{
				pin_ptr<const wchar_t> pszPath = PtrToStringChars(path);
				BOOL result = ::PathCchIsRoot(pszPath);
				
				return result != 0;
			}

			/// <summary>
			/// Removes the trailing backslash from the end of a path string.
			/// </summary>
			static String^ PathCchRemoveBackslash(String^ path)
			{
				pin_ptr<const wchar_t> pszPath = PtrToStringChars(path);
				const int buflen = path->Length + 1;
				wchar_t *buf = new wchar_t[buflen];
				wmemcpy_s(buf, buflen, pszPath, path->Length + 1);
				
				HRESULT result = ::PathCchRemoveBackslash(buf, buflen);
				return HandleHResult(result, buf, path);
			}

			/// <summary>
			/// Removes the file name extension from a path, if one is present.
			/// </summary>
			static String^ PathCchRemoveExtension(String^ path)
			{
				pin_ptr<const wchar_t> pszPath = PtrToStringChars(path);
				const int buflen = path->Length + 1;
				wchar_t *buf = new wchar_t[buflen];
				wmemcpy_s(buf, buflen, pszPath, path->Length + 1);

				HRESULT result = ::PathCchRemoveExtension(buf, buflen);
				return HandleHResult(result, buf, path);
			}

			/// <summary>
			/// Removes the last element in a path string, whether that element is a file name or a directory name. The
			/// element's leading backslash is also removed.
			/// </summary>
			static String^ PathCchRemoveFileSpec(String^ path)
			{
				pin_ptr<const wchar_t> pszPath = PtrToStringChars(path);
				const int buflen = path->Length + 1;
				wchar_t *buf = new wchar_t[buflen];
				wmemcpy_s(buf, buflen, pszPath, path->Length + 1);

				HRESULT result = ::PathCchRemoveFileSpec(buf, buflen);
				return HandleHResult(result, buf, path);
			}

			/// <summary>
			/// Replaces a file name's extension at the end of a path string with a new extension. If the path string does not
			/// end with an extension, the new extension is added.
			/// </summary>
			static String^ PathCchRenameExtension(String^ path, String^ ext)
			{
				pin_ptr<const wchar_t> pszPath = PtrToStringChars(path);
				pin_ptr<const wchar_t> pszExt = PtrToStringChars(ext);
				const int buflen = path->Length + ext->Length + 2;
				wchar_t *buf = new wchar_t[buflen];
				wmemcpy_s(buf, buflen, pszPath, path->Length + 1);

				HRESULT result = ::PathCchRenameExtension(buf, buflen, pszExt);
				return HandleHResult(result, buf);
			}

			/// <summary>
			/// Retrieves a pointer to the first character in a path following the drive letter or Universal Naming Convention
			/// (UNC) server/share path elements.
			/// </summary>
			static String^ PathCchSkipRoot(String^ path)
			{
				pin_ptr<const wchar_t> pszPath = PtrToStringChars(path);

				wchar_t *ppszRootEnd;
				HRESULT result = ::PathCchSkipRoot((PWSTR)pszPath, &ppszRootEnd);
				HandleHResult(result);

				return gcnew String(ppszRootEnd);
			}

			/// <summary>
			/// Removes the "\\?\" prefix, if present, from a file path.
			/// </summary>
			static String^ PathCchStripPrefix(String^ path)
			{
				pin_ptr<const wchar_t> pszPath = PtrToStringChars(path);
				const int buflen = path->Length + 1;
				wchar_t *buf = new wchar_t[buflen];
				wmemcpy_s(buf, buflen, pszPath, path->Length + 1);

				HRESULT result = ::PathCchStripPrefix(buf, buflen);
				return HandleHResult(result, buf, path);
			}

			/// <summary>
			/// Removes all file and directory elements in a path except for the root information.
			/// </summary>
			static String^ PathCchStripToRoot(String^ path)
			{
				pin_ptr<const wchar_t> pszPath = PtrToStringChars(path);
				const int buflen = path->Length + 1;
				wchar_t *buf = new wchar_t[buflen];
				wmemcpy_s(buf, buflen, pszPath, path->Length + 1);

				HRESULT result = ::PathCchStripToRoot(buf, buflen);
				return HandleHResult(result, buf, path);
			}

			/// <summary>
			/// Determines if a path string is a valid Universal Naming Convention (UNC) path, as opposed to a path based on a
			/// drive letter.
			/// </summary>
			static bool PathIsUNCEx(String^ path, [Out] String^% server)
			{
				wchar_t *ppszServer;
				pin_ptr<const wchar_t> pszPath = PtrToStringChars(path);
				BOOL result = ::PathIsUNCEx((PWSTR)pszPath, &ppszServer);
				if (result != 0) 
				{
					server = gcnew String(ppszServer);
					return true;
				}
				else
				{
					server = nullptr;
					return false;
				}
			}

		private:

			static String^ HandleHResult(HRESULT result, wchar_t *buf, String^ path)
			{
				if (result == S_OK)
				{
					String^ pathOut = gcnew String(buf);
					delete buf;
					return pathOut;
				}
				else if (result == S_FALSE)
				{
					delete buf;
					return path;
				}
				else
				{
					delete buf;
					throw gcnew Win32Exception(result);
				}
			}

			static String^ HandleHResult(HRESULT result, wchar_t *buf)
			{
				if (result == S_OK)
				{
					String^ pathOut = gcnew String(buf);
					delete buf;
					return pathOut;
				}
				else
				{
					delete buf;
					throw gcnew Win32Exception(result);
				}
			}

			static void HandleHResult(HRESULT result)
			{
				if (result != S_OK)
				{
					throw gcnew Win32Exception(result);
				}
			}
		};
	}
}