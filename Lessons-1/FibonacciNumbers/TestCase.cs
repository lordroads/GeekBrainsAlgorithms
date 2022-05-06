public class TestCase
{
    public int Number { get; set; }
    public long Expected { get; set; }
    public Exception ExpectedException { get; set; }

    public override string ToString()
    {
        return $"Number - {Number}\nExpented - {Expected}\nExpectedException - {ExpectedException}";
    }
}
