﻿//===============================================================================
// Microsoft patterns & practices Enterprise Library
// Caching Application Block
//===============================================================================
// Copyright © Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Generic.Caching.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Microsoft.Practices.EnterpriseLibrary.Caching.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Internal ProducerConsumerQueue thread failed..
        /// </summary>
        internal static string BackgroundSchedulerProducerConsumerQueueFailure {
            get {
                return ResourceManager.GetString("BackgroundSchedulerProducerConsumerQueueFailure", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Enterprise Library Caching Application Block.
        /// </summary>
        internal static string BlockName {
            get {
                return ResourceManager.GetString("BlockName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Total # of Cache Access Attempts is the number of reads from the cache..
        /// </summary>
        internal static string CacheAccessAttemptsCounterHelpResource {
            get {
                return ResourceManager.GetString("CacheAccessAttemptsCounterHelpResource", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cache Accessed Expired Items Ratio Base is the total number of items expired from the cache..
        /// </summary>
        internal static string CacheAccessedExpiredItemsRatioBaseCounterHelpResource {
            get {
                return ResourceManager.GetString("CacheAccessedExpiredItemsRatioBaseCounterHelpResource", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cache Accessed Expired Items Ratio is the ratio between expired items accessed by the user and total items expired from the cache..
        /// </summary>
        internal static string CacheAccessedExpiredItemsRatioCounterHelpResource {
            get {
                return ResourceManager.GetString("CacheAccessedExpiredItemsRatioCounterHelpResource", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cache Accessed Scavenged Items Ratio Base is the total number of items scavenged from the cache..
        /// </summary>
        internal static string CacheAccessedScavengedItemsRatioBaseCounterHelpResource {
            get {
                return ResourceManager.GetString("CacheAccessedScavengedItemsRatioBaseCounterHelpResource", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cache Accessed Scavenged Items Ratio is the ratio between scavenged items accessed by the user and total items scavenged from the cache..
        /// </summary>
        internal static string CacheAccessedScavengedItemsRatioCounterHelpResource {
            get {
                return ResourceManager.GetString("CacheAccessedScavengedItemsRatioCounterHelpResource", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cache Expiries/sec is the rate at which items were expired from the cache..
        /// </summary>
        internal static string CacheExpiriesPerSecCounterHelpResource {
            get {
                return ResourceManager.GetString("CacheExpiriesPerSecCounterHelpResource", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cache Hit Ratio is the ratio between hits and reads from the cache..
        /// </summary>
        internal static string CacheHitRatioCounterHelpResource {
            get {
                return ResourceManager.GetString("CacheHitRatioCounterHelpResource", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cache Hits/sec is the rate at which requests for existing items were received by the cache..
        /// </summary>
        internal static string CacheHitsPerSecCounterHelpResource {
            get {
                return ResourceManager.GetString("CacheHitsPerSecCounterHelpResource", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cache Misses/sec is the rate at which requests for non existing items were received by the cache..
        /// </summary>
        internal static string CacheMissesPerSecCounterHelpResource {
            get {
                return ResourceManager.GetString("CacheMissesPerSecCounterHelpResource", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Add called without setting BackgroundScheduler..
        /// </summary>
        internal static string CacheNotInitializedException {
            get {
                return ResourceManager.GetString("CacheNotInitializedException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cache Scavenged Items/sec is the rate at which items were scavenged from the cache..
        /// </summary>
        internal static string CacheScavengedItemsPerSecCounterHelpResource {
            get {
                return ResourceManager.GetString("CacheScavengedItemsPerSecCounterHelpResource", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Total Cache Entries is the total number of entries in the cache..
        /// </summary>
        internal static string CacheTotalEntriesCounterHelpResource {
            get {
                return ResourceManager.GetString("CacheTotalEntriesCounterHelpResource", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Updated Entries/sec is the rate at which items were updated in the cache. An update can be either an &quot;add&quot; or a &quot;remove&quot;..
        /// </summary>
        internal static string CacheUpdatedEntriesPerSecHelpResource {
            get {
                return ResourceManager.GetString("CacheUpdatedEntriesPerSecHelpResource", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Parameter name cannot be null or an empty string..
        /// </summary>
        internal static string EmptyParameterName {
            get {
                return ResourceManager.GetString("EmptyParameterName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The error occurred executing the removal callback for key &quot;{1}&quot; in the the &quot;{0}&quot; instance..
        /// </summary>
        internal static string ErrorCacheCallbackFailedMessage {
            get {
                return ResourceManager.GetString("ErrorCacheCallbackFailedMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The error occurred retrieving the configuration for instance &quot;{0}&quot;..
        /// </summary>
        internal static string ErrorCacheConfigurationFailedMessage {
            get {
                return ResourceManager.GetString("ErrorCacheConfigurationFailedMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The error occurred using the &quot;{0}&quot; instance..
        /// </summary>
        internal static string ErrorCacheOperationFailedMessage {
            get {
                return ResourceManager.GetString("ErrorCacheOperationFailedMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Backing Stores with non-default constructors should override GetRegistrations()..
        /// </summary>
        internal static string ExceptionBackingStoresWithNonDefaultConstructorsShouldOverrideGetRegistrations {
            get {
                return ResourceManager.GetString("ExceptionBackingStoresWithNonDefaultConstructorsShouldOverrideGetRegistrations", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The format length is invalid..
        /// </summary>
        internal static string ExceptionInvalidExtendedFormatArguments {
            get {
                return ResourceManager.GetString("ExceptionInvalidExtendedFormatArguments", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The file does not exist..
        /// </summary>
        internal static string ExceptionInvalidFileName {
            get {
                return ResourceManager.GetString("ExceptionInvalidFileName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Must be implemented by subclasses..
        /// </summary>
        internal static string ExceptionMethodMustBeImplementedBySubclasses {
            get {
                return ResourceManager.GetString("ExceptionMethodMustBeImplementedBySubclasses", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The file name cannot be null..
        /// </summary>
        internal static string ExceptionNullFileName {
            get {
                return ResourceManager.GetString("ExceptionNullFileName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Time format cannot be null..
        /// </summary>
        internal static string ExceptionNullTimeFormat {
            get {
                return ResourceManager.GetString("ExceptionNullTimeFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Parameter must implement type &apos;{0}&apos;..
        /// </summary>
        internal static string ExceptionParameterMustImplement {
            get {
                return ResourceManager.GetString("ExceptionParameterMustImplement", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Absolute time cannot be less than current time..
        /// </summary>
        internal static string ExceptionRangeAbsoluteTime {
            get {
                return ResourceManager.GetString("ExceptionRangeAbsoluteTime", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Day of Week in Extended Format out of range..
        /// </summary>
        internal static string ExceptionRangeDay {
            get {
                return ResourceManager.GetString("ExceptionRangeDay", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Hour in Extended Format out of range..
        /// </summary>
        internal static string ExceptionRangeHour {
            get {
                return ResourceManager.GetString("ExceptionRangeHour", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Minutes in Extended Format out of range..
        /// </summary>
        internal static string ExceptionRangeMinute {
            get {
                return ResourceManager.GetString("ExceptionRangeMinute", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Month of Year in Extended Format out of range..
        /// </summary>
        internal static string ExceptionRangeMonth {
            get {
                return ResourceManager.GetString("ExceptionRangeMonth", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Sliding time should be greater than or equal to 1s..
        /// </summary>
        internal static string ExceptionRangeSlidingExpiration {
            get {
                return ResourceManager.GetString("ExceptionRangeSlidingExpiration", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The storage are name for the Isolated Storage Backing Store can not be null or an empty string..
        /// </summary>
        internal static string ExceptionStorageAreaNullOrEmpty {
            get {
                return ResourceManager.GetString("ExceptionStorageAreaNullOrEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The Custom Backing Store &apos;{0}&apos; with Type &apos;{1}&apos; must derive from IBackingStore..
        /// </summary>
        internal static string ExceptionTypeForCustomBackingStoreMustDeriveFrom {
            get {
                return ResourceManager.GetString("ExceptionTypeForCustomBackingStoreMustDeriveFrom", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The Custom Cache Manager &apos;{0}&apos; with Type &apos;{1}&apos; must derive from ICacheManager..
        /// </summary>
        internal static string ExceptionTypeForCustomCacheManagerMustDeriveFrom {
            get {
                return ResourceManager.GetString("ExceptionTypeForCustomCacheManagerMustDeriveFrom", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failure while removing item from cache in background..
        /// </summary>
        internal static string FailureToRemoveCacheItemInBackground {
            get {
                return ResourceManager.GetString("FailureToRemoveCacheItemInBackground", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failure while starting application-specified refresh action..
        /// </summary>
        internal static string FailureToSpawnUserSpecifiedRefreshAction {
            get {
                return ResourceManager.GetString("FailureToSpawnUserSpecifiedRefreshAction", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Expiration poll frequency time must be at least 1 millisecond..
        /// </summary>
        internal static string InvalidExpirationPollFrequencyInMilliSeconds {
            get {
                return ResourceManager.GetString("InvalidExpirationPollFrequencyInMilliSeconds", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot stop polling before it is started..
        /// </summary>
        internal static string InvalidPollingStopOperation {
            get {
                return ResourceManager.GetString("InvalidPollingStopOperation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This cache object does not support regions..
        /// </summary>
        internal static string RegionsNotSupported {
            get {
                return ResourceManager.GetString("RegionsNotSupported", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Total Cache Expiries is the total number of items expired from the cache..
        /// </summary>
        internal static string TotalCacheExpiriesCounterHelpResource {
            get {
                return ResourceManager.GetString("TotalCacheExpiriesCounterHelpResource", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Total Cache Hits is the total number of requests for existing items received by the cache..
        /// </summary>
        internal static string TotalCacheHitsCounterHelpResource {
            get {
                return ResourceManager.GetString("TotalCacheHitsCounterHelpResource", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Total Cache Misses is the total number for non existing items received by the cache..
        /// </summary>
        internal static string TotalCacheMissesCounterHelpResource {
            get {
                return ResourceManager.GetString("TotalCacheMissesCounterHelpResource", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Total Cache Scavenged Items is the total number of items scavenged from the cache..
        /// </summary>
        internal static string TotalCacheScavengedItemsCounterHelpResource {
            get {
                return ResourceManager.GetString("TotalCacheScavengedItemsCounterHelpResource", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Total Updated Entries is the total number of items updated in the cache. An update can be either an &quot;add&quot; or a &quot;remove&quot;..
        /// </summary>
        internal static string TotalCacheUpdatedEntriesHelpResource {
            get {
                return ResourceManager.GetString("TotalCacheUpdatedEntriesHelpResource", resourceCulture);
            }
        }
    }
}
