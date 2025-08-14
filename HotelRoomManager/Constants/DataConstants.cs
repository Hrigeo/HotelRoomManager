namespace HotelRoomManager.Constants
{
    public static class DataConstants
    {

            // Room.Number (adjust if your entity uses a different size)
            public const int NumberMaxLength = 20;
            public const int NumberMin = 1;
            public const int NumberMax = 9999;

        // Use string bounds for [Range(typeof(decimal), ...)] annotations
        public const double PriceMin = 1;
            public const double PriceMax = 100000;

            public const int NameMinLength = 2;
        public const int NameMaxLength = 100;

        public const int DescriptionMaxLength = 1000;

            public const int CapacityMin = 1;
            public const int CapacityMax = 20;

            public const int RatingMin = 1;
            public const int RatingMax = 5;

            public const int SubjectMaxLength = 200;

    }
}
