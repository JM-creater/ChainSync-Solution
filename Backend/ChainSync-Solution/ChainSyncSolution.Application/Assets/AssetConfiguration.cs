using ChainSyncSolution.Application.Assets.Common;
using Microsoft.AspNetCore.Http;

namespace ChainSyncSolution.Application.Assets;

public class AssetConfiguration
{
    public async Task<string> SaveProfileImages(IFormFile imageFile)
    {
        if (imageFile == null || imageFile.Length == 0)
        {
            throw new ArgumentException("Invalid image file provided.");
        }

        string mainFolder = Path.Combine(
            Directory.GetCurrentDirectory(),
            CatalogSettings.MainFolderSetting);
        string subFolder = Path.Combine(
            mainFolder,
            CatalogSettings.SubFolderSetting);

        if (!Directory.Exists(mainFolder))
        {
            Directory.CreateDirectory(mainFolder);
        }
        if (!Directory.Exists(subFolder))
        {
            Directory.CreateDirectory(subFolder);
        }

        var fileName = Path.GetFileName(imageFile.FileName);
        var filePath = Path.Combine(subFolder, fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await imageFile.CopyToAsync(stream);
        }

        return Path.Combine(
            CatalogSettings.MainFolderSetting,
            CatalogSettings.SubFolderSetting,
            fileName);
    }
}
