﻿using System;
using AVFoundation;
using CoreGraphics;
using CoreImage;
using CoreMedia;
using CoreVideo;
using DotnetConf2019BCN.Mobile.Helpers;
using UIKit;

namespace DotnetConf2019BCN.Mobile.IOS.ThirdParties.Camera
{
    public class VideoCaptureDelegate : AVCaptureVideoDataOutputSampleBufferDelegate
    {
        public event EventHandler<EventArgsT<UIImage>> FrameCaptured = (sender, e) => { };

        public VideoCaptureDelegate(EventHandler<EventArgsT<UIImage>> callback)
        {
            this.FrameCaptured = callback;
        }

        public override void DidOutputSampleBuffer(
            AVCaptureOutput captureOutput, 
            CMSampleBuffer sampleBuffer, 
            AVCaptureConnection connection)
        {
            try
            {
                using (var uiImage = GetUIImage(sampleBuffer))
                {
                    if (uiImage == null)
                    {
                        return;
                    }

                    FrameCaptured(this, new EventArgsT<UIImage>(uiImage));
                }
            }
            finally
            {
                sampleBuffer.Dispose();
            }
        }

        private UIImage GetUIImage(CMSampleBuffer sampleBuffer)
        {
            using (var imageBuffer = sampleBuffer.GetImageBuffer())
            using (var ciImage = new CIImage(imageBuffer))
            using (var ciContext = CIContext.FromOptions(null))
            using (var cgImage = ciContext.CreateCGImage(ciImage, ciImage.Extent))
            {
                var uiImage = new UIImage(cgImage);

                return uiImage;
            }
        }
    }
}