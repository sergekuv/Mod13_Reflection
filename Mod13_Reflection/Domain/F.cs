namespace Mod13_Reflection.Domain;

internal class F
{
    public int i1 { get; set; }
    public int i2 { get; set; }
    public int i3 { get; set; }
    public int i4 { get; set; }
    public int i5 { get; set; }
    public F()
    {
        i1 = 1; i2 = 2; i3 = 3; i4 = 4; i5 = 5;
    }

    //следующая строка из формулировки задачи, вероятно, она пригодится, если я неправильно понял задачу и придется что-то менять
    //public static F Get => new F() { i1 = 1, i2 = 2, i3 = 3, i4 = 4, i5 = 5 };

    public override string ToString() => "i1:" + i1 + ", i2:" + i2 + ", i3:" + i3 + ", i4:" + i4 + ", i5:" + i5;
}
