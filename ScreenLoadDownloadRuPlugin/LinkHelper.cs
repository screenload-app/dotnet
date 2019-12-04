using System;

namespace ScreenLoadDownloadRuPlugin
{
    internal static class LinkHelper
    {
        public static string BuildDirectLink(FileEntry fileEntry)
        {
            if (null == fileEntry)
                throw new ArgumentNullException(nameof(fileEntry));

            return $"https://download.ru{fileEntry.Preview.UrlsEntry.Large}";
        }

        public static string BuildPageLink(FileEntry fileEntry)
        {
            if (null == fileEntry)
                throw new ArgumentNullException(nameof(fileEntry));

            return $"https://download.ru/f/{fileEntry.Id}";
        }
    }
}
