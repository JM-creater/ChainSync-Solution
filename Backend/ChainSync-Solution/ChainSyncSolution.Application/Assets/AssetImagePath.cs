﻿using Microsoft.Extensions.Options;

namespace ChainSyncSolution.Application.Assets;

public class AssetImagePath
{
    private readonly AssetImageOptions _assetImageOptions;

    public AssetImagePath(IOptions<AssetImageOptions> assetImageOptions)
    {
        _assetImageOptions = assetImageOptions.Value;   
    }

    public string GetMainFolderPath()
    {
        return _assetImageOptions.PathImages;
    }

    public string GetProfilePath()
    {
        return Path.Combine(_assetImageOptions.PathImages, _assetImageOptions.ProfileImage);
    }

    public string GetDocumentPath()
    {
        return Path.Combine(_assetImageOptions.PathImages, _assetImageOptions.Document);
    }

    public string GetProductImagePath()
    {
        return Path.Combine(_assetImageOptions.PathImages, _assetImageOptions.ProductImage);
    }
}
