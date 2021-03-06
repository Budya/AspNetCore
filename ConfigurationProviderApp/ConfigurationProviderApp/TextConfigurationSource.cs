﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ConfigurationProviderApp
{
    public class TextConfigurationSource : IConfigurationSource
    {
        public string FilePath { get; private set; }

        public TextConfigurationSource(string filename)
        {
            FilePath = filename;
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            // geting full path for file
            string filePath = builder.GetFileProvider().GetFileInfo(FilePath)
                .PhysicalPath;
            return new TextConfigurationProvider(filePath);
        }
    }
}
