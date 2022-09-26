// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Extensions;

    /// <summary>The Flux Configuration Patch Request object.</summary>
    public partial class FluxConfigurationPatch :
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatch,
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchInternal
    {

        /// <summary>Plaintext access key used to securely access the S3 bucket</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public System.Security.SecureString BucketAccessKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchPropertiesInternal)Property).BucketAccessKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchPropertiesInternal)Property).BucketAccessKey = value ?? null; }

        /// <summary>
        /// Specify whether to use insecure communication when puling data from the S3 bucket.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public bool? BucketInsecure { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchPropertiesInternal)Property).BucketInsecure; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchPropertiesInternal)Property).BucketInsecure = value ?? default(bool); }

        /// <summary>
        /// Name of a local secret on the Kubernetes cluster to use as the authentication secret rather than the managed or user-provided
        /// configuration secrets.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public string BucketLocalAuthRef { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchPropertiesInternal)Property).BucketLocalAuthRef; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchPropertiesInternal)Property).BucketLocalAuthRef = value ?? null; }

        /// <summary>The bucket name to sync from the url endpoint for the flux configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public string BucketName { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchPropertiesInternal)Property).BucketName; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchPropertiesInternal)Property).BucketName = value ?? null; }

        /// <summary>
        /// The interval at which to re-reconcile the cluster git repository source with the remote.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public long? BucketSyncIntervalInSecond { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchPropertiesInternal)Property).BucketSyncIntervalInSecond; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchPropertiesInternal)Property).BucketSyncIntervalInSecond = value ?? default(long); }

        /// <summary>
        /// The maximum time to attempt to reconcile the cluster git repository source with the remote.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public long? BucketTimeoutInSecond { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchPropertiesInternal)Property).BucketTimeoutInSecond; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchPropertiesInternal)Property).BucketTimeoutInSecond = value ?? default(long); }

        /// <summary>The URL to sync for the flux configuration S3 bucket.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public string BucketUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchPropertiesInternal)Property).BucketUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchPropertiesInternal)Property).BucketUrl = value ?? null; }

        /// <summary>Key-value pairs of protected configuration settings for the configuration</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchPropertiesConfigurationProtectedSettings ConfigurationProtectedSetting { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchPropertiesInternal)Property).ConfigurationProtectedSetting; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchPropertiesInternal)Property).ConfigurationProtectedSetting = value ?? null /* model class */; }

        /// <summary>
        /// Base64-encoded HTTPS certificate authority contents used to access git private git repositories over HTTPS
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public string GitRepositoryHttpsCaCert { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchPropertiesInternal)Property).GitRepositoryHttpsCaCert; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchPropertiesInternal)Property).GitRepositoryHttpsCaCert = value ?? null; }

        /// <summary>Plaintext HTTPS username used to access private git repositories over HTTPS</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public string GitRepositoryHttpsUser { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchPropertiesInternal)Property).GitRepositoryHttpsUser; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchPropertiesInternal)Property).GitRepositoryHttpsUser = value ?? null; }

        /// <summary>
        /// Name of a local secret on the Kubernetes cluster to use as the authentication secret rather than the managed or user-provided
        /// configuration secrets.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public string GitRepositoryLocalAuthRef { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchPropertiesInternal)Property).GitRepositoryLocalAuthRef; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchPropertiesInternal)Property).GitRepositoryLocalAuthRef = value ?? null; }

        /// <summary>
        /// Base64-encoded known_hosts value containing public SSH keys required to access private git repositories over SSH
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public string GitRepositorySshKnownHost { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchPropertiesInternal)Property).GitRepositorySshKnownHost; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchPropertiesInternal)Property).GitRepositorySshKnownHost = value ?? null; }

        /// <summary>
        /// The interval at which to re-reconcile the cluster git repository source with the remote.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public long? GitRepositorySyncIntervalInSecond { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchPropertiesInternal)Property).GitRepositorySyncIntervalInSecond; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchPropertiesInternal)Property).GitRepositorySyncIntervalInSecond = value ?? default(long); }

        /// <summary>
        /// The maximum time to attempt to reconcile the cluster git repository source with the remote.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public long? GitRepositoryTimeoutInSecond { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchPropertiesInternal)Property).GitRepositoryTimeoutInSecond; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchPropertiesInternal)Property).GitRepositoryTimeoutInSecond = value ?? default(long); }

        /// <summary>The URL to sync for the flux configuration git repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public string GitRepositoryUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchPropertiesInternal)Property).GitRepositoryUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchPropertiesInternal)Property).GitRepositoryUrl = value ?? null; }

        /// <summary>
        /// Array of kustomizations used to reconcile the artifact pulled by the source type on the cluster.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchPropertiesKustomizations Kustomization { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchPropertiesInternal)Property).Kustomization; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchPropertiesInternal)Property).Kustomization = value ?? null /* model class */; }

        /// <summary>Internal Acessors for Bucket</summary>
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IBucketPatchDefinition Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchInternal.Bucket { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchPropertiesInternal)Property).Bucket; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchPropertiesInternal)Property).Bucket = value; }

        /// <summary>Internal Acessors for GitRepository</summary>
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IGitRepositoryPatchDefinition Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchInternal.GitRepository { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchPropertiesInternal)Property).GitRepository; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchPropertiesInternal)Property).GitRepository = value; }

        /// <summary>Internal Acessors for GitRepositoryRef</summary>
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IRepositoryRefDefinition Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchInternal.GitRepositoryRef { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchPropertiesInternal)Property).GitRepositoryRef; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchPropertiesInternal)Property).GitRepositoryRef = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchProperties Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.FluxConfigurationPatchProperties()); set { {_property = value;} } }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchProperties _property;

        /// <summary>Updatable properties of an Flux Configuration Patch Request</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.FluxConfigurationPatchProperties()); set => this._property = value; }

        /// <summary>The git repository branch name to checkout.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public string RepositoryRefBranch { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchPropertiesInternal)Property).RepositoryRefBranch; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchPropertiesInternal)Property).RepositoryRefBranch = value ?? null; }

        /// <summary>
        /// The commit SHA to checkout. This value must be combined with the branch name to be valid. This takes precedence over semver.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public string RepositoryRefCommit { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchPropertiesInternal)Property).RepositoryRefCommit; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchPropertiesInternal)Property).RepositoryRefCommit = value ?? null; }

        /// <summary>
        /// The semver range used to match against git repository tags. This takes precedence over tag.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public string RepositoryRefSemver { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchPropertiesInternal)Property).RepositoryRefSemver; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchPropertiesInternal)Property).RepositoryRefSemver = value ?? null; }

        /// <summary>The git repository tag name to checkout. This takes precedence over branch.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public string RepositoryRefTag { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchPropertiesInternal)Property).RepositoryRefTag; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchPropertiesInternal)Property).RepositoryRefTag = value ?? null; }

        /// <summary>Source Kind to pull the configuration data from.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.SourceKindType? SourceKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchPropertiesInternal)Property).SourceKind; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchPropertiesInternal)Property).SourceKind = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.SourceKindType)""); }

        /// <summary>
        /// Whether this configuration should suspend its reconciliation of its kustomizations and sources.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public bool? Suspend { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchPropertiesInternal)Property).Suspend; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchPropertiesInternal)Property).Suspend = value ?? default(bool); }

        /// <summary>Creates an new <see cref="FluxConfigurationPatch" /> instance.</summary>
        public FluxConfigurationPatch()
        {

        }
    }
    /// The Flux Configuration Patch Request object.
    public partial interface IFluxConfigurationPatch :
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.IJsonSerializable
    {
        /// <summary>Plaintext access key used to securely access the S3 bucket</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Plaintext access key used to securely access the S3 bucket",
        SerializedName = @"accessKey",
        PossibleTypes = new [] { typeof(System.Security.SecureString) })]
        System.Security.SecureString BucketAccessKey { get; set; }
        /// <summary>
        /// Specify whether to use insecure communication when puling data from the S3 bucket.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specify whether to use insecure communication when puling data from the S3 bucket.",
        SerializedName = @"insecure",
        PossibleTypes = new [] { typeof(bool) })]
        bool? BucketInsecure { get; set; }
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
        string BucketLocalAuthRef { get; set; }
        /// <summary>The bucket name to sync from the url endpoint for the flux configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The bucket name to sync from the url endpoint for the flux configuration.",
        SerializedName = @"bucketName",
        PossibleTypes = new [] { typeof(string) })]
        string BucketName { get; set; }
        /// <summary>
        /// The interval at which to re-reconcile the cluster git repository source with the remote.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The interval at which to re-reconcile the cluster git repository source with the remote.",
        SerializedName = @"syncIntervalInSeconds",
        PossibleTypes = new [] { typeof(long) })]
        long? BucketSyncIntervalInSecond { get; set; }
        /// <summary>
        /// The maximum time to attempt to reconcile the cluster git repository source with the remote.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The maximum time to attempt to reconcile the cluster git repository source with the remote.",
        SerializedName = @"timeoutInSeconds",
        PossibleTypes = new [] { typeof(long) })]
        long? BucketTimeoutInSecond { get; set; }
        /// <summary>The URL to sync for the flux configuration S3 bucket.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The URL to sync for the flux configuration S3 bucket.",
        SerializedName = @"url",
        PossibleTypes = new [] { typeof(string) })]
        string BucketUrl { get; set; }
        /// <summary>Key-value pairs of protected configuration settings for the configuration</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Key-value pairs of protected configuration settings for the configuration",
        SerializedName = @"configurationProtectedSettings",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchPropertiesConfigurationProtectedSettings) })]
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchPropertiesConfigurationProtectedSettings ConfigurationProtectedSetting { get; set; }
        /// <summary>
        /// Base64-encoded HTTPS certificate authority contents used to access git private git repositories over HTTPS
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Base64-encoded HTTPS certificate authority contents used to access git private git repositories over HTTPS",
        SerializedName = @"httpsCACert",
        PossibleTypes = new [] { typeof(string) })]
        string GitRepositoryHttpsCaCert { get; set; }
        /// <summary>Plaintext HTTPS username used to access private git repositories over HTTPS</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Plaintext HTTPS username used to access private git repositories over HTTPS",
        SerializedName = @"httpsUser",
        PossibleTypes = new [] { typeof(string) })]
        string GitRepositoryHttpsUser { get; set; }
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
        string GitRepositoryLocalAuthRef { get; set; }
        /// <summary>
        /// Base64-encoded known_hosts value containing public SSH keys required to access private git repositories over SSH
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Base64-encoded known_hosts value containing public SSH keys required to access private git repositories over SSH",
        SerializedName = @"sshKnownHosts",
        PossibleTypes = new [] { typeof(string) })]
        string GitRepositorySshKnownHost { get; set; }
        /// <summary>
        /// The interval at which to re-reconcile the cluster git repository source with the remote.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The interval at which to re-reconcile the cluster git repository source with the remote.",
        SerializedName = @"syncIntervalInSeconds",
        PossibleTypes = new [] { typeof(long) })]
        long? GitRepositorySyncIntervalInSecond { get; set; }
        /// <summary>
        /// The maximum time to attempt to reconcile the cluster git repository source with the remote.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The maximum time to attempt to reconcile the cluster git repository source with the remote.",
        SerializedName = @"timeoutInSeconds",
        PossibleTypes = new [] { typeof(long) })]
        long? GitRepositoryTimeoutInSecond { get; set; }
        /// <summary>The URL to sync for the flux configuration git repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The URL to sync for the flux configuration git repository.",
        SerializedName = @"url",
        PossibleTypes = new [] { typeof(string) })]
        string GitRepositoryUrl { get; set; }
        /// <summary>
        /// Array of kustomizations used to reconcile the artifact pulled by the source type on the cluster.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Array of kustomizations used to reconcile the artifact pulled by the source type on the cluster.",
        SerializedName = @"kustomizations",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchPropertiesKustomizations) })]
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchPropertiesKustomizations Kustomization { get; set; }
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
        /// <summary>Source Kind to pull the configuration data from.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Source Kind to pull the configuration data from.",
        SerializedName = @"sourceKind",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.SourceKindType) })]
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.SourceKindType? SourceKind { get; set; }
        /// <summary>
        /// Whether this configuration should suspend its reconciliation of its kustomizations and sources.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether this configuration should suspend its reconciliation of its kustomizations and sources.",
        SerializedName = @"suspend",
        PossibleTypes = new [] { typeof(bool) })]
        bool? Suspend { get; set; }

    }
    /// The Flux Configuration Patch Request object.
    internal partial interface IFluxConfigurationPatchInternal

    {
        /// <summary>Parameters to reconcile to the Bucket source kind type.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IBucketPatchDefinition Bucket { get; set; }
        /// <summary>Plaintext access key used to securely access the S3 bucket</summary>
        System.Security.SecureString BucketAccessKey { get; set; }
        /// <summary>
        /// Specify whether to use insecure communication when puling data from the S3 bucket.
        /// </summary>
        bool? BucketInsecure { get; set; }
        /// <summary>
        /// Name of a local secret on the Kubernetes cluster to use as the authentication secret rather than the managed or user-provided
        /// configuration secrets.
        /// </summary>
        string BucketLocalAuthRef { get; set; }
        /// <summary>The bucket name to sync from the url endpoint for the flux configuration.</summary>
        string BucketName { get; set; }
        /// <summary>
        /// The interval at which to re-reconcile the cluster git repository source with the remote.
        /// </summary>
        long? BucketSyncIntervalInSecond { get; set; }
        /// <summary>
        /// The maximum time to attempt to reconcile the cluster git repository source with the remote.
        /// </summary>
        long? BucketTimeoutInSecond { get; set; }
        /// <summary>The URL to sync for the flux configuration S3 bucket.</summary>
        string BucketUrl { get; set; }
        /// <summary>Key-value pairs of protected configuration settings for the configuration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchPropertiesConfigurationProtectedSettings ConfigurationProtectedSetting { get; set; }
        /// <summary>Parameters to reconcile to the GitRepository source kind type.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IGitRepositoryPatchDefinition GitRepository { get; set; }
        /// <summary>
        /// Base64-encoded HTTPS certificate authority contents used to access git private git repositories over HTTPS
        /// </summary>
        string GitRepositoryHttpsCaCert { get; set; }
        /// <summary>Plaintext HTTPS username used to access private git repositories over HTTPS</summary>
        string GitRepositoryHttpsUser { get; set; }
        /// <summary>
        /// Name of a local secret on the Kubernetes cluster to use as the authentication secret rather than the managed or user-provided
        /// configuration secrets.
        /// </summary>
        string GitRepositoryLocalAuthRef { get; set; }
        /// <summary>The source reference for the GitRepository object.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IRepositoryRefDefinition GitRepositoryRef { get; set; }
        /// <summary>
        /// Base64-encoded known_hosts value containing public SSH keys required to access private git repositories over SSH
        /// </summary>
        string GitRepositorySshKnownHost { get; set; }
        /// <summary>
        /// The interval at which to re-reconcile the cluster git repository source with the remote.
        /// </summary>
        long? GitRepositorySyncIntervalInSecond { get; set; }
        /// <summary>
        /// The maximum time to attempt to reconcile the cluster git repository source with the remote.
        /// </summary>
        long? GitRepositoryTimeoutInSecond { get; set; }
        /// <summary>The URL to sync for the flux configuration git repository.</summary>
        string GitRepositoryUrl { get; set; }
        /// <summary>
        /// Array of kustomizations used to reconcile the artifact pulled by the source type on the cluster.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchPropertiesKustomizations Kustomization { get; set; }
        /// <summary>Updatable properties of an Flux Configuration Patch Request</summary>
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20220301.IFluxConfigurationPatchProperties Property { get; set; }
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
        /// <summary>Source Kind to pull the configuration data from.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Support.SourceKindType? SourceKind { get; set; }
        /// <summary>
        /// Whether this configuration should suspend its reconciliation of its kustomizations and sources.
        /// </summary>
        bool? Suspend { get; set; }

    }
}