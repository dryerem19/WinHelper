namespace WinHelper.Models;

public class CpuModel
{
    public string? Name { get; set; }
    public string? Caption { get; set; }
    public string? Manufacturer { get; set; }
    public uint NumberOfCores { get; set; }
    public uint NumberOfLogicalCores { get; set; }
    public uint NumberOfThreads { get; set; }
    public string? Socket { get; set; }
    public uint L2CacheSize { get; set; }
    public uint L3CacheSize { get; set; }
    public uint CurrentClockSpeed { get; set; }
    public uint MaxClockSpeed { get; set; }
}