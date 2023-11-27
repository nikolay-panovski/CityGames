
public static class Util
{
    // https://forum.unity.com/threads/re-map-a-number-from-one-range-to-another.119437/#post-6750358
    public static float Remap(float val, float in1, float in2, float out1, float out2)
    {
        return out1 + (val - in1) * (out2 - out1) / (in2 - in1);
    }
}
