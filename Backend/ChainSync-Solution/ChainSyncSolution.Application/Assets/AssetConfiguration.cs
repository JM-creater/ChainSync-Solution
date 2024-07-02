using ChainSyncSolution.Application.Assets.Common;
using ChainSyncSolution.Application.Common.Exceptions;
using Microsoft.AspNetCore.Http;

namespace ChainSyncSolution.Application.Assets;

public class AssetConfiguration
{
    public async Task<string> SaveProfileImages(IFormFile imageFile)
    {
        if (imageFile == null || imageFile.Length == 0)
        {
            throw new InvalidImageProvideException(imageFile);
        }

        string mainFolder = Path.Combine(
            Directory.GetCurrentDirectory(),
            ProfileSettings.MainFolderProfile);
        string subFolder = Path.Combine(
            mainFolder,
            ProfileSettings.SubFolderProfile);

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
            ProfileSettings.MainFolderProfile,
            ProfileSettings.SubFolderProfile,
            fileName);
    }

    public async Task<string> SaveDocumentsImages(IFormFile imageFile)
    {
        if (imageFile == null || imageFile.Length == 0)
        {
            throw new InvalidImageProvideException(imageFile);
        }

        string mainFolder = Path.Combine(
            Directory.GetCurrentDirectory(),
            DocumentsSettings.MainFolderDocument);
        string subFolder = Path.Combine(
            mainFolder,
            DocumentsSettings.SubFolderDocument);

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
            DocumentsSettings.MainFolderDocument,
            DocumentsSettings.SubFolderDocument,
            fileName);
    }

    public async Task<string> SaveProductImages(IFormFile imageFile)
    {
        if (imageFile == null || imageFile.Length == 0)
        {
            throw new InvalidImageProvideException(imageFile);
        }

        string mainFolder = Path.Combine(
            Directory.GetCurrentDirectory(),
            ProductsImageSettings.MainFolderDocument);
        string subFolder = Path.Combine(
            mainFolder,
            ProductsImageSettings.SubFolderProductImage);

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
            ProductsImageSettings.MainFolderDocument,
            ProductsImageSettings.SubFolderProductImage,
            fileName);
    }
}
