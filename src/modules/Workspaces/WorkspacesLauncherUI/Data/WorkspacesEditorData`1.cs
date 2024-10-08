﻿// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Text.Json;

using WorkspacesLauncherUI.Utils;

namespace Workspaces.Data
{
    public class WorkspacesEditorData<T>
    {
        protected JsonSerializerOptions JsonOptions
        {
            get
            {
                return new JsonSerializerOptions
                {
                    PropertyNamingPolicy = new DashCaseNamingPolicy(),
                    WriteIndented = true,
                };
            }
        }

        public T Read(string file)
        {
            IOUtils ioUtils = new IOUtils();
            string data = ioUtils.ReadFile(file);
            return JsonSerializer.Deserialize<T>(data, JsonOptions);
        }

        public string Serialize(T data)
        {
            return JsonSerializer.Serialize(data, JsonOptions);
        }
    }
}
