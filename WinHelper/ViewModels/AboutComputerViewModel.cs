using System.Collections.ObjectModel;
using System.Management;
using WinHelper.Models;

namespace WinHelper.ViewModels;
[System.Runtime.Versioning.SupportedOSPlatform("windows")]
public class AboutComputerViewModel : ViewModelBase
{
    private const int GigabyteByteValue = 1073741824;
    private const int MegabyteByteValue = 1048576;
    
    public AboutComputerViewModel()
    {

    }

    private ObservableCollection<GpuModel>? _gpuCollection;

    public ObservableCollection<GpuModel>? GpuCollection
    {
        get
        {
            if (_gpuCollection != null)
            {
                return _gpuCollection;
            }

            _gpuCollection = new ObservableCollection<GpuModel>();

            ManagementObjectSearcher s;
            s = new ManagementObjectSearcher("root\\cimv2", 
                "SELECT * FROM Win32_VideoController");
            
            foreach (var cardItem in s.Get())
            {
                _gpuCollection.Add(new GpuModel
                {
                    Name = cardItem.GetPropertyValue("Name").ToString(),
                    Processor = cardItem.GetPropertyValue("VideoProcessor").ToString(),
                    Memory = (int)(uint.Parse(cardItem.GetPropertyValue("AdapterRAM").ToString()) / GigabyteByteValue)
                });
            }

            return _gpuCollection;
        }
    }

    private ObservableCollection<CpuModel>? _cpu;
    public ObservableCollection<CpuModel>? CpuCollection
    {
        get
        {
            if (_cpu != null) return _cpu;
            _cpu = new ObservableCollection<CpuModel>();
                
            ManagementObjectSearcher s;
            s = new ManagementObjectSearcher("root\\cimv2", 
                "SELECT * FROM Win32_Processor");
                
            foreach (var cpu in s.Get())
            {
                _cpu.Add(new CpuModel
                {
                    Name = cpu.GetPropertyValue("Name").ToString(),
                    Caption = cpu.GetPropertyValue("Caption").ToString(),
                    Manufacturer = cpu.GetPropertyValue("Manufacturer").ToString(),
                    NumberOfCores = (uint)cpu.GetPropertyValue("NumberOfCores"),
                    NumberOfLogicalCores = (uint)cpu.GetPropertyValue("NumberOfLogicalProcessors"),
                    NumberOfThreads = (uint)cpu.GetPropertyValue("ThreadCount"),
                    Socket = cpu.GetPropertyValue("SocketDesignation").ToString(),
                    L2CacheSize = (uint)cpu.GetPropertyValue("L2CacheSize"),
                    L3CacheSize = (uint)cpu.GetPropertyValue("L3CacheSize"),
                    CurrentClockSpeed = (uint)cpu.GetPropertyValue("CurrentClockSpeed"),
                    MaxClockSpeed = (uint)cpu.GetPropertyValue("MaxClockSpeed")
                });
            }

            return _cpu;
        }
    }
}