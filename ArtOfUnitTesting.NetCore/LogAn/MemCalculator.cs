namespace LogAn;

public class MemCalculator
{
    private int _sum;

    public void Add(int number)
    {
        _sum += number;
    }

    public int Sum()
    {
        int temp = _sum;
        _sum = 0;
        return temp;
    }
}
