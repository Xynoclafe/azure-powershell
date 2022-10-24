using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Management.ResourceManager.Models;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels
{
    public enum PSDenySettingsMode
    {
        None = 0,
        DenyDelete,
        DenyWriteAndDelete
    }
}
