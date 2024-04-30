using Microsoft.AspNetCore.Http;

namespace ChainSyncSolution.Application.Assets;

public class AssetConfiguration
{
    public async Task<string?> SaveProfileImages(IFormFile? imageFile)
    {
        if (imageFile == null || imageFile.Length == 0)
            return null;

        string mainFolder = Path.Combine(Directory.GetCurrentDirectory(), "PathImages");
        string subFolder = Path.Combine(mainFolder, "ProfileImage");

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

        return Path.Combine("PathImages", "ProfileImage", fileName);
    }
}
