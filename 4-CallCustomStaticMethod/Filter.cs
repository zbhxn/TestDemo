namespace _4_CallCustomStaticMethod
{
    public class Filter
    {
        public string Id { get; set; }
        public Operator Operator { get; set; }
        public string? Value { get; set; }
    }

    public enum Operator
    {
        NewContains,
        ToString
    }
}
