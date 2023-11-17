var pointClass = new PointClass(10, 20);
Console.WriteLine($"Point class: {pointClass}");

var pointRecord = new PointRecord(10, 20);
Console.WriteLine($"Point record: {pointRecord}");

var newPointRecord = pointRecord with {Y = 50};
Console.WriteLine($"Point newRecord: {newPointRecord}");

var pointRecordStruct = new RecordStructPoint(40, 60);
Console.WriteLine($"Point record struct: {pointRecordStruct}");

pointRecordStruct.X = 5;

var pointReadonlyRecordStruct = new RecordStructReadonlyPoint(45, 65);
Console.WriteLine($"Point readonly record struct: {pointReadonlyRecordStruct}");

// pointReadonlyRecordStruct.X = 5; To nie zadziala, bo readonly
var newPointReadonlyRecordStruct = pointReadonlyRecordStruct with{X = 100};
Console.WriteLine($"Point readonly record struct: {newPointReadonlyRecordStruct}");


record struct RecordStructPoint(int X, int Y);
readonly record struct RecordStructReadonlyPoint(int X, int Y);
record PointRecord(int X, int Y);
class PointClass : IEquatable<PointClass>
{
    public int X { get; }
    public int Y { get; }

    public PointClass(int x, int y)
    {
        X = x;
        Y = y;
    }

    public override string ToString()
    {
        return $"X: {X}, Y: {Y}";
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }

    public bool Equals(PointClass? other)
    {
        return other is not null && other.X == X && other.Y == Y;
    }

    public override bool Equals(object? obj)
    {
        return obj is PointClass pointClass && Equals(pointClass);
    }
}