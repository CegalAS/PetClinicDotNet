namespace PetClinic.Common
{
    public static class DateTimeCulture
    {
        /// <summary>
        /// Converts a <see cref="DateTime"/> to a <see cref="DateTimeOffset"/> based on the <see cref="DateTimeKind"/>
        /// </summary>
        /// <param name="dateTime">The <see cref="DateTime"/> to convert to <see cref="DateTimeOffset"/></param>
        /// <returns></returns>
        public static DateTimeOffset GetDateTimeOffset(this DateTime dateTime)
        {
            var utcTime = dateTime;
            if (dateTime.Kind == DateTimeKind.Unspecified)
            {
                utcTime = DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
            }
            else if (dateTime.Kind == DateTimeKind.Local)
            {
                utcTime = dateTime.ToUniversalTime();
            }

            DateTimeOffset offset = utcTime;
            return offset;
        }

    }
}
