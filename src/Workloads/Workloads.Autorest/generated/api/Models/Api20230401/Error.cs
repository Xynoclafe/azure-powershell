// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api20230401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Workloads.Runtime.Extensions;

    /// <summary>Standard error object.</summary>
    public partial class Error :
        Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api20230401.IError,
        Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api20230401.IErrorInternal
    {

        /// <summary>Backing field for <see cref="Code" /> property.</summary>
        private string _code;

        /// <summary>Server-defined set of error codes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Workloads.Origin(Microsoft.Azure.PowerShell.Cmdlets.Workloads.PropertyOrigin.Owned)]
        public string Code { get => this._code; }

        /// <summary>Backing field for <see cref="Detail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api20230401.IError[] _detail;

        /// <summary>Array of details about specific errors that led to this reported error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Workloads.Origin(Microsoft.Azure.PowerShell.Cmdlets.Workloads.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api20230401.IError[] Detail { get => this._detail; }

        /// <summary>Backing field for <see cref="InnerError" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api20230401.IErrorInnerError _innerError;

        /// <summary>
        /// Object containing more specific information than the current object about the error.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Workloads.Origin(Microsoft.Azure.PowerShell.Cmdlets.Workloads.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api20230401.IErrorInnerError InnerError { get => (this._innerError = this._innerError ?? new Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api20230401.ErrorInnerError()); }

        /// <summary>Backing field for <see cref="Message" /> property.</summary>
        private string _message;

        /// <summary>Human-readable representation of the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Workloads.Origin(Microsoft.Azure.PowerShell.Cmdlets.Workloads.PropertyOrigin.Owned)]
        public string Message { get => this._message; }

        /// <summary>Internal Acessors for Code</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api20230401.IErrorInternal.Code { get => this._code; set { {_code = value;} } }

        /// <summary>Internal Acessors for Detail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api20230401.IError[] Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api20230401.IErrorInternal.Detail { get => this._detail; set { {_detail = value;} } }

        /// <summary>Internal Acessors for InnerError</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api20230401.IErrorInnerError Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api20230401.IErrorInternal.InnerError { get => (this._innerError = this._innerError ?? new Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api20230401.ErrorInnerError()); set { {_innerError = value;} } }

        /// <summary>Internal Acessors for Message</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api20230401.IErrorInternal.Message { get => this._message; set { {_message = value;} } }

        /// <summary>Internal Acessors for Target</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api20230401.IErrorInternal.Target { get => this._target; set { {_target = value;} } }

        /// <summary>Backing field for <see cref="Target" /> property.</summary>
        private string _target;

        /// <summary>Target of the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Workloads.Origin(Microsoft.Azure.PowerShell.Cmdlets.Workloads.PropertyOrigin.Owned)]
        public string Target { get => this._target; }

        /// <summary>Creates an new <see cref="Error" /> instance.</summary>
        public Error()
        {

        }
    }
    /// Standard error object.
    public partial interface IError :
        Microsoft.Azure.PowerShell.Cmdlets.Workloads.Runtime.IJsonSerializable
    {
        /// <summary>Server-defined set of error codes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Workloads.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Server-defined set of error codes.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string Code { get;  }
        /// <summary>Array of details about specific errors that led to this reported error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Workloads.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Array of details about specific errors that led to this reported error.",
        SerializedName = @"details",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api20230401.IError) })]
        Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api20230401.IError[] Detail { get;  }
        /// <summary>
        /// Object containing more specific information than the current object about the error.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Workloads.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Object containing more specific information than  the current object about the error.",
        SerializedName = @"innerError",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api20230401.IErrorInnerError) })]
        Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api20230401.IErrorInnerError InnerError { get;  }
        /// <summary>Human-readable representation of the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Workloads.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Human-readable representation of the error.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get;  }
        /// <summary>Target of the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Workloads.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Target of the error.",
        SerializedName = @"target",
        PossibleTypes = new [] { typeof(string) })]
        string Target { get;  }

    }
    /// Standard error object.
    internal partial interface IErrorInternal

    {
        /// <summary>Server-defined set of error codes.</summary>
        string Code { get; set; }
        /// <summary>Array of details about specific errors that led to this reported error.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api20230401.IError[] Detail { get; set; }
        /// <summary>
        /// Object containing more specific information than the current object about the error.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api20230401.IErrorInnerError InnerError { get; set; }
        /// <summary>Human-readable representation of the error.</summary>
        string Message { get; set; }
        /// <summary>Target of the error.</summary>
        string Target { get; set; }

    }
}