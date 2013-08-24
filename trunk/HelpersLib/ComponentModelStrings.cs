using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelpersLib
{
    public static class ComponentModelStrings
    {
        public const string AfterCaptureClipboard = "After capture / clipboard";
        public const string AfterCaptureClipboard_ClipboardContentFormat = "Clipboard content format after uploading. Supported variables: $url, $shorturl, $thumbnailurl, $deletionurl, $folderpath, $foldername, $filepath, $filename and other variables such as %y-%m-%d etc.";
        public const string Interaction = "Interaction";
        public const string Interaction_DisableNotifications = "Disable notifications";
        public const string UploadText = "Upload text";
        public const string UploadText_TextFileExtension = "File extension when saving text to the local hard disk.";
        public const string UploadText_TextFormat = "Text format e.g. csharp, cpp, etc.";
    }
}