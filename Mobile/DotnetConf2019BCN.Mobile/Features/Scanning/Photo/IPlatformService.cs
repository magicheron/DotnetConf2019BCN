﻿namespace DotnetConf2019BCN.Mobile.Features.Scanning.Photo
{
    public interface IPlatformService
    {
        void KeyboardClick();

        bool ResizeImage(string filePath, PhotoSize photoSize, int quality);
    }
}
