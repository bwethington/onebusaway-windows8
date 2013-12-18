﻿/* Copyright 2013 Michael Braude and individual contributors.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using OneBusAway.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace OneBusAway.Platforms.Windows8
{
    public class FileService : IFileService
    {
        public async Task<DateTimeOffset> GetFileCreatedTimeAsync(string relativePath)
        {
            var file = await ApplicationData.Current.LocalFolder.GetFileAsync(relativePath);
            return file.DateCreated;
        }

        public async Task<DateTimeOffset> GetFileModifiedTimeAsync(string relativePath)
        {
            var file = await ApplicationData.Current.LocalFolder.GetFileAsync(relativePath);
            var properties = await file.GetBasicPropertiesAsync();
            return properties.DateModified;
        }

        public async Task<string> ReadFileAsStringAsync(string relativePath)
        {
            var file = await ApplicationData.Current.LocalFolder.GetFileAsync(relativePath);
            return await FileIO.ReadTextAsync(file);
        }

        public async Task<Stream> ReadFileAsStreamAsync(string relativePath)
        {
            var file = await ApplicationData.Current.LocalFolder.GetFileAsync(relativePath);
            var fileAccess = await file.OpenReadAsync();
            return fileAccess.AsStream();
        }

        public async Task WriteFileAsync(string relativePath, Stream stream)
        {
            StorageFile file = null;
            
            var storageItem = await ApplicationData.Current.LocalFolder.TryGetItemAsync(relativePath);
            if (storageItem == null)
            {
                file = await ApplicationData.Current.LocalFolder.CreateFileAsync(relativePath, CreationCollisionOption.ReplaceExisting);
            }
            else
            {
                file = await ApplicationData.Current.LocalFolder.GetFileAsync(relativePath);
            }

            using (var fileStream = await file.OpenAsync(FileAccessMode.ReadWrite))
            {
                await stream.CopyToAsync(fileStream.AsStream(), (int)stream.Length);
            }
        }
    }
}