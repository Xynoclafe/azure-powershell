// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Extensions;

    /// <summary>Parameters to reconcile to the GitRepository source kind type.</summary>
    public partial class GitRepositoryDefinition :
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IGitRepositoryDefinition,
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IGitRepositoryDefinitionInternal
    {

        /// <summary>Backing field for <see cref="HttpsCaCert" /> property.</summary>
        private string _httpsCaCert;

        /// <summary>
        /// Base64-encoded HTTPS certificate authority contents used to access git private git repositories over HTTPS
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Owned)]
        public string HttpsCaCert { get => this._httpsCaCert; set => this._httpsCaCert = value; }

        /// <summary>Backing field for <see cref="HttpsUser" /> property.</summary>
        private string _httpsUser;

        /// <summary>Plaintext HTTPS username used to access private git repositories over HTTPS</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Owned)]
        public string HttpsUser { get => this._httpsUser; set => this._httpsUser = value; }

        /// <summary>Backing field for <see cref="LocalAuthRef" /> property.</summary>
        private string _localAuthRef;

        /// <summary>
        /// Name of a local secret on the Kubernetes cluster to use as the authentication secret rather than the managed or user-provided
        /// configuration secrets.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Owned)]
        public string LocalAuthRef { get => this._localAuthRef; set => this._localAuthRef = value; }

        /// <summary>Internal Acessors for RepositoryRef</summary>
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IRepositoryRefDefinition Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IGitRepositoryDefinitionInternal.RepositoryRef { get => (this._repositoryRef = this._repositoryRef ?? new Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.RepositoryRefDefinition()); set { {_repositoryRef = value;} } }

        /// <summary>Backing field for <see cref="RepositoryRef" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IRepositoryRefDefinition _repositoryRef;

        /// <summary>The source reference for the GitRepository object.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IRepositoryRefDefinition RepositoryRef { get => (this._repositoryRef = this._repositoryRef ?? new Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.RepositoryRefDefinition()); set => this._repositoryRef = value; }

        /// <summary>The git repository branch name to checkout.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public string RepositoryRefBranch { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IRepositoryRefDefinitionInternal)RepositoryRef).Branch; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IRepositoryRefDefinitionInternal)RepositoryRef).Branch = value ?? null; }

        /// <summary>
        /// The commit SHA to checkout. This value must be combined with the branch name to be valid. This takes precedence over semver.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public string RepositoryRefCommit { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IRepositoryRefDefinitionInternal)RepositoryRef).Commit; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IRepositoryRefDefinitionInternal)RepositoryRef).Commit = value ?? null; }

        /// <summary>
        /// The semver range used to match against git repository tags. This takes precedence over tag.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public string RepositoryRefSemver { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IRepositoryRefDefinitionInternal)RepositoryRef).Semver; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IRepositoryRefDefinitionInternal)RepositoryRef).Semver = value ?? null; }

        /// <summary>The git repository tag name to checkout. This takes precedence over branch.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public string RepositoryRefTag { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IRepositoryRefDefinitionInternal)RepositoryRef).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IRepositoryRefDefinitionInternal)RepositoryRef).Tag = value ?? null; }

        /// <summary>Backing field for <see cref="SshKnownHost" /> property.</summary>
        private string _sshKnownHost;

        /// <summary>
        /// Base64-encoded known_hosts value containing public SSH keys required to access private git repositories over SSH
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Owned)]
        public string SshKnownHost { get => this._sshKnownHost; set => this._sshKnownHost = value; }

        /// <summary>Backing field for <see cref="SyncIntervalInSecond" /> property.</summary>
        private long? _syncIntervalInSecond;

        /// <summary>
        /// The interval at which to re-reconcile the cluster git repository source with the remote.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Owned)]
        public long? SyncIntervalInSecond { get => this._syncIntervalInSecond; set => this._syncIntervalInSecond = value; }

        /// <summary>Backing field for <see cref="TimeoutInSecond" /> property.</summary>
        private long? _timeoutInSecond;

        /// <summary>
        /// The maximum time to attempt to reconcile the cluster git repository source with the remote.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Owned)]
        public long? TimeoutInSecond { get => this._timeoutInSecond; set => this._timeoutInSecond = value; }

        /// <summary>Backing field for <see cref="Url" /> property.</summary>
        private string _url;

        /// <summary>The URL to sync for the flux configuration git repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Owned)]
        public string Url { get => this._url; set => this._url = value; }

        /// <summary>Creates an new <see cref="GitRepositoryDefinition" /> instance.</summary>
        public GitRepositoryDefinition()
        {

        }
    }
    /// Parameters to reconcile to the GitRepository source kind type.
    public partial interface IGitRepositoryDefinition :
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Base64-encoded HTTPS certificate authority contents used to access git private git repositories over HTTPS
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Base64-encoded HTTPS certificate authority contents used to access git private git repositories over HTTPS",
        SerializedName = @"httpsCACert",
        PossibleTypes = new [] { typeof(string) })]
        string HttpsCaCert { get; set; }
        /// <summary>Plaintext HTTPS username used to access private git repositories over HTTPS</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Plaintext HTTPS username used to access private git repositories over HTTPS",
        SerializedName = @"httpsUser",
        PossibleTypes = new [] { typeof(string) })]
        string HttpsUser { get; set; }
        /// <summary>
        /// Name of a local secret on the Kubernetes cluster to use as the authentication secret rather than the managed or user-provided
        /// configuration secrets.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of a local secret on the Kubernetes cluster to use as the authentication secret rather than the managed or user-provided configuration secrets.",
        SerializedName = @"localAuthRef",
        PossibleTypes = new [] { typeof(string) })]
        string LocalAuthRef { get; set; }
        /// <summary>The git repository branch name to checkout.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The git repository branch name to checkout.",
        SerializedName = @"branch",
        PossibleTypes = new [] { typeof(string) })]
        string RepositoryRefBranch { get; set; }
        /// <summary>
        /// The commit SHA to checkout. This value must be combined with the branch name to be valid. This takes precedence over semver.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The commit SHA to checkout. This value must be combined with the branch name to be valid. This takes precedence over semver.",
        SerializedName = @"commit",
        PossibleTypes = new [] { typeof(string) })]
        string RepositoryRefCommit { get; set; }
        /// <summary>
        /// The semver range used to match against git repository tags. This takes precedence over tag.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The semver range used to match against git repository tags. This takes precedence over tag.",
        SerializedName = @"semver",
        PossibleTypes = new [] { typeof(string) })]
        string RepositoryRefSemver { get; set; }
        /// <summary>The git repository tag name to checkout. This takes precedence over branch.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The git repository tag name to checkout. This takes precedence over branch.",
        SerializedName = @"tag",
        PossibleTypes = new [] { typeof(string) })]
        string RepositoryRefTag { get; set; }
        /// <summary>
        /// Base64-encoded known_hosts value containing public SSH keys required to access private git repositories over SSH
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Base64-encoded known_hosts value containing public SSH keys required to access private git repositories over SSH",
        SerializedName = @"sshKnownHosts",
        PossibleTypes = new [] { typeof(string) })]
        string SshKnownHost { get; set; }
        /// <summary>
        /// The interval at which to re-reconcile the cluster git repository source with the remote.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The interval at which to re-reconcile the cluster git repository source with the remote.",
        SerializedName = @"syncIntervalInSeconds",
        PossibleTypes = new [] { typeof(long) })]
        long? SyncIntervalInSecond { get; set; }
        /// <summary>
        /// The maximum time to attempt to reconcile the cluster git repository source with the remote.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The maximum time to attempt to reconcile the cluster git repository source with the remote.",
        SerializedName = @"timeoutInSeconds",
        PossibleTypes = new [] { typeof(long) })]
        long? TimeoutInSecond { get; set; }
        /// <summary>The URL to sync for the flux configuration git repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The URL to sync for the flux configuration git repository.",
        SerializedName = @"url",
        PossibleTypes = new [] { typeof(string) })]
        string Url { get; set; }

    }
    /// Parameters to reconcile to the GitRepository source kind type.
    internal partial interface IGitRepositoryDefinitionInternal

    {
        /// <summary>
        /// Base64-encoded HTTPS certificate authority contents used to access git private git repositories over HTTPS
        /// </summary>
        string HttpsCaCert { get; set; }
        /// <summary>Plaintext HTTPS username used to access private git repositories over HTTPS</summary>
        string HttpsUser { get; set; }
        /// <summary>
        /// Name of a local secret on the Kubernetes cluster to use as the authentication secret rather than the managed or user-provided
        /// configuration secrets.
        /// </summary>
        string LocalAuthRef { get; set; }
        /// <summary>The source reference for the GitRepository object.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IRepositoryRefDefinition RepositoryRef { get; set; }
        /// <summary>The git repository branch name to checkout.</summary>
        string RepositoryRefBranch { get; set; }
        /// <summary>
        /// The commit SHA to checkout. This value must be combined with the branch name to be valid. This takes precedence over semver.
        /// </summary>
        string RepositoryRefCommit { get; set; }
        /// <summary>
        /// The semver range used to match against git repository tags. This takes precedence over tag.
        /// </summary>
        string RepositoryRefSemver { get; set; }
        /// <summary>The git repository tag name to checkout. This takes precedence over branch.</summary>
        string RepositoryRefTag { get; set; }
        /// <summary>
        /// Base64-encoded known_hosts value containing public SSH keys required to access private git repositories over SSH
        /// </summary>
        string SshKnownHost { get; set; }
        /// <summary>
        /// The interval at which to re-reconcile the cluster git repository source with the remote.
        /// </summary>
        long? SyncIntervalInSecond { get; set; }
        /// <summary>
        /// The maximum time to attempt to reconcile the cluster git repository source with the remote.
        /// </summary>
        long? TimeoutInSecond { get; set; }
        /// <summary>The URL to sync for the flux configuration git repository.</summary>
        string Url { get; set; }

    }
}