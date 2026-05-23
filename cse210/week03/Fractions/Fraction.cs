public class Fraction
{
    private int _top;
    private int _bottom;

    //Constructors
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }
    public Fraction(int number)
    {
        _top = number;
        _bottom = 1;
    }
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }


    //setters and getters

    public void SetTop(int top)
    {
        _top = top;
    }

    public int GetTop()
    {
        return _top;
    }

    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }

    public int GetBottom()
    {
        return _bottom;
    }

    //methods

    public string GetFractionString()
    {
        string strtop = _top.ToString();
        string strbottom = _bottom.ToString();
        string fractionFinale = $"{strtop}/{strbottom}";

        if (strbottom == "1")
        {
            return strtop;
        }
        else
        {
            return fractionFinale;
        }

    }

    public double GetDecimalValue()
    {   

        double division = (double)_top / (double)_bottom;
        return division;
    }
}