namespace YalcinHotel_BLL
{
    public static class ImageMethods
    {
        public static bool IsExternalImageUrl(string? imageUrl)
        {
            return Uri.TryCreate(imageUrl?.Trim(), UriKind.Absolute, out var uri)
                && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);
        }

        public static bool IsOptionalExternalImageUrl(string? imageUrl) =>
            string.IsNullOrWhiteSpace(imageUrl) || IsExternalImageUrl(imageUrl);

        public static string NormalizeImageUrl(string imageUrl) => imageUrl.Trim();

        public static string? NormalizeOptionalImageUrl(string? imageUrl) => // NormalizeOptionalImageUrl: Bu yöntem, isteğe bağlı bir resim URL'sini normalize eder. Eğer resim URL'si boş veya null ise null döner, aksi takdirde URL'yi kırpar ve döner.
            string.IsNullOrWhiteSpace(imageUrl) ? null : imageUrl.Trim();
    }
}
