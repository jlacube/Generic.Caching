using System;
using Generic.Caching.Interfaces;
using Generic.Caching.Properties;

namespace Generic.Caching.Expirations
{
    /// <summary>
    ///	This provider tests if a item was expired using a extended format.
    /// </summary>
    [Serializable]
    [System.Runtime.InteropServices.ComVisible(false)]
    public class ExtendedFormatTime : ICacheItemExpiration
    {
        private string extendedFormat;
        private DateTime lastUsedTime;

        /// <summary>
        ///	Convert the input format to the extented time format.
        /// </summary>
        /// <param name="timeFormat">
        ///	This contains the expiration information
        /// </param>
        public ExtendedFormatTime(string timeFormat)
        {
            // check arguments
            if (string.IsNullOrEmpty(timeFormat))
            {
                throw new ArgumentException(Resources.ExceptionNullTimeFormat, "timeFormat");
            }

            ExtendedFormat.Validate(timeFormat);

            // Get the modified extended format
            this.extendedFormat = timeFormat;

            // Convert to UTC in order to compensate for time zones		
            this.lastUsedTime = DateTime.Now.ToUniversalTime();
        }

        /// <summary>
        /// Gets the extended time format.
        /// </summary>
        /// <value>
        /// The extended time format.
        /// </value>
        public string TimeFormat
        {
            get { return extendedFormat; }
        }

        /// <summary>
        ///	Specifies if item has expired or not.
        /// </summary>
        /// <returns>
        ///	Returns true if the data is expired otherwise false
        /// </returns>
        public bool HasExpired()
        {
            // Convert to UTC in order to compensate for time zones		
            DateTime nowDateTime = DateTime.Now.ToUniversalTime();

            ExtendedFormat format = new ExtendedFormat(extendedFormat);
            // Check expiration
            if (format.IsExpired(lastUsedTime, nowDateTime))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        ///	Notifies that the item was recently used.
        /// </summary>
        public void Notify()
        {
        }

        /// <summary>
        /// Not used
        /// </summary>
        /// <param name="owningCacheItem">Not used</param>
        public void Initialize<TType>(CacheItem<TType> owningCacheItem)
        {
        }
    }
}
