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

        public static string? NormalizeOptionalImageUrl(string? imageUrl) =>
            string.IsNullOrWhiteSpace(imageUrl) ? null : imageUrl.Trim();
    }
}
