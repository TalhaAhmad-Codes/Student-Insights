namespace StudentInsight.Validators.Length
{
    public static class MaxLength
    {
        public static int Username => 50;
        public static int Email => 150;
        public static int PersonName => 50;
        public static int DepartmentName => 75;
        public static int SubjectName => 70;
        public static int SELNote => 150;
    }

    public static class MinLength
    {
        public static int Password => 8;
    }
}
