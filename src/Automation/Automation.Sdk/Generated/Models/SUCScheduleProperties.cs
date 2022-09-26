// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.Automation.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Definition of schedule parameters.
    /// </summary>
    public partial class SUCScheduleProperties
    {
        /// <summary>
        /// Initializes a new instance of the SUCScheduleProperties class.
        /// </summary>
        public SUCScheduleProperties()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the SUCScheduleProperties class.
        /// </summary>
        /// <param name="startTime">Gets or sets the start time of the
        /// schedule.</param>
        /// <param name="startTimeOffsetMinutes">Gets the start time's offset
        /// in minutes.</param>
        /// <param name="expiryTime">Gets or sets the end time of the
        /// schedule.</param>
        /// <param name="expiryTimeOffsetMinutes">Gets or sets the expiry
        /// time's offset in minutes.</param>
        /// <param name="isEnabled">Gets or sets a value indicating whether
        /// this schedule is enabled.</param>
        /// <param name="nextRun">Gets or sets the next run time of the
        /// schedule.</param>
        /// <param name="nextRunOffsetMinutes">Gets or sets the next run time's
        /// offset in minutes.</param>
        /// <param name="interval">Gets or sets the interval of the
        /// schedule.</param>
        /// <param name="frequency">Gets or sets the frequency of the schedule.
        /// Possible values include: 'OneTime', 'Day', 'Hour', 'Week', 'Month',
        /// 'Minute'</param>
        /// <param name="timeZone">Gets or sets the time zone of the
        /// schedule.</param>
        /// <param name="advancedSchedule">Gets or sets the advanced
        /// schedule.</param>
        /// <param name="creationTime">Gets or sets the creation time.</param>
        /// <param name="lastModifiedTime">Gets or sets the last modified
        /// time.</param>
        /// <param name="description">Gets or sets the description.</param>
        public SUCScheduleProperties(System.DateTimeOffset startTime = default(System.DateTimeOffset), double startTimeOffsetMinutes = default(double), System.DateTimeOffset? expiryTime = default(System.DateTimeOffset?), double expiryTimeOffsetMinutes = default(double), bool? isEnabled = default(bool?), System.DateTimeOffset? nextRun = default(System.DateTimeOffset?), double nextRunOffsetMinutes = default(double), long? interval = default(long?), string frequency = default(string), string timeZone = default(string), AdvancedSchedule advancedSchedule = default(AdvancedSchedule), System.DateTimeOffset creationTime = default(System.DateTimeOffset), System.DateTimeOffset lastModifiedTime = default(System.DateTimeOffset), string description = default(string))
        {
            StartTime = startTime;
            StartTimeOffsetMinutes = startTimeOffsetMinutes;
            ExpiryTime = expiryTime;
            ExpiryTimeOffsetMinutes = expiryTimeOffsetMinutes;
            IsEnabled = isEnabled;
            NextRun = nextRun;
            NextRunOffsetMinutes = nextRunOffsetMinutes;
            Interval = interval;
            Frequency = frequency;
            TimeZone = timeZone;
            AdvancedSchedule = advancedSchedule;
            CreationTime = creationTime;
            LastModifiedTime = lastModifiedTime;
            Description = description;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the start time of the schedule.
        /// </summary>
        [JsonProperty(PropertyName = "startTime")]
        public System.DateTimeOffset StartTime { get; set; }

        /// <summary>
        /// Gets the start time's offset in minutes.
        /// </summary>
        [JsonProperty(PropertyName = "startTimeOffsetMinutes")]
        public double StartTimeOffsetMinutes { get; private set; }

        /// <summary>
        /// Gets or sets the end time of the schedule.
        /// </summary>
        [JsonProperty(PropertyName = "expiryTime")]
        public System.DateTimeOffset? ExpiryTime { get; set; }

        /// <summary>
        /// Gets or sets the expiry time's offset in minutes.
        /// </summary>
        [JsonProperty(PropertyName = "expiryTimeOffsetMinutes")]
        public double ExpiryTimeOffsetMinutes { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this schedule is enabled.
        /// </summary>
        [JsonProperty(PropertyName = "isEnabled")]
        public bool? IsEnabled { get; set; }

        /// <summary>
        /// Gets or sets the next run time of the schedule.
        /// </summary>
        [JsonProperty(PropertyName = "nextRun")]
        public System.DateTimeOffset? NextRun { get; set; }

        /// <summary>
        /// Gets or sets the next run time's offset in minutes.
        /// </summary>
        [JsonProperty(PropertyName = "nextRunOffsetMinutes")]
        public double NextRunOffsetMinutes { get; set; }

        /// <summary>
        /// Gets or sets the interval of the schedule.
        /// </summary>
        [JsonProperty(PropertyName = "interval")]
        public long? Interval { get; set; }

        /// <summary>
        /// Gets or sets the frequency of the schedule. Possible values
        /// include: 'OneTime', 'Day', 'Hour', 'Week', 'Month', 'Minute'
        /// </summary>
        [JsonProperty(PropertyName = "frequency")]
        public string Frequency { get; set; }

        /// <summary>
        /// Gets or sets the time zone of the schedule.
        /// </summary>
        [JsonProperty(PropertyName = "timeZone")]
        public string TimeZone { get; set; }

        /// <summary>
        /// Gets or sets the advanced schedule.
        /// </summary>
        [JsonProperty(PropertyName = "advancedSchedule")]
        public AdvancedSchedule AdvancedSchedule { get; set; }

        /// <summary>
        /// Gets or sets the creation time.
        /// </summary>
        [JsonProperty(PropertyName = "creationTime")]
        public System.DateTimeOffset CreationTime { get; set; }

        /// <summary>
        /// Gets or sets the last modified time.
        /// </summary>
        [JsonProperty(PropertyName = "lastModifiedTime")]
        public System.DateTimeOffset LastModifiedTime { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

    }
}
