using System.Text.RegularExpressions;

namespace eShopBE.Infrastructure
{
    public static class ConvertImage
    {
        private static readonly Regex DataUriPattern = new Regex(
            @"^data\:(?<type>image\/(png|tiff|jpg|gif|jpeg));base64,(?<data>[A-Z0-9\+\/\=]+)$",
            RegexOptions.Compiled | RegexOptions.ExplicitCapture | RegexOptions.IgnoreCase);
        public static string SaveImage(string imageData, string typeImage)
        {
            if (string.IsNullOrWhiteSpace(imageData)) return null;
            Match match = DataUriPattern.Match(imageData);
            if (!match.Success && typeImage == "updateImage") return imageData;
            if (!match.Success && typeImage == "createImage") return null;
            string type = match.Groups["type"].Value.Split('/')[1];
            string data = match.Groups["data"].Value;
            string path = Directory.GetCurrentDirectory() + "/Common/Images";
            string imageName = DateTime.Now.Ticks + "." + type;
            string imagePath = Path.Combine(path, imageName);
            byte[] imageBytes = Convert.FromBase64String(data);
            File.WriteAllBytes(imagePath, imageBytes);
            string pathToData = "Common/Images/" + imageName;
            return pathToData;

        }

    }
}
