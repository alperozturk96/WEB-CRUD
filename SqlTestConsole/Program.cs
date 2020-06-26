using dataAccess;
using Microsoft.AspNetCore.Mvc;
using SqlTest.Controllers;
using System;

namespace SqlTestConsole
{

    class Program
    {
        
        static CpuManager _managercpu;
        static MoboManager _managermobo;

        static void Main(string[] args)
        {
            if (_managercpu == null && _managermobo == null)
            {
                _managercpu = new CpuManager();
                _managermobo = new MoboManager();
            }
            StockProcedure();
        }

        public static void StockProcedure()
        {
            Console.WriteLine("1. ----> List Tables");
            Console.WriteLine("2. ----> Add Data Into Table");
            Console.WriteLine("3. ----> Delete Data From Table");
            byte choose = Convert.ToByte(Console.ReadLine());
            var datas = _managercpu.SelectTable();
            var datas2 = _managermobo.SelectTable();

            switch (choose)
            {
                case 1:
                    Console.WriteLine("1. ----> Processor Table");
                    Console.WriteLine("2. ----> Motherboard Table");
                    byte choose2 = Convert.ToByte(Console.ReadLine());
                    switch (choose2)
                        {
                        case 1:
                            foreach (var item in datas)
                            {
                                Console.WriteLine($" CPU ID: {item.cpuid}");
                                Console.Write($"/ CPU NAME: {item.Name}");
                                Console.Write($"/ CPU CACHE SIZE: {item.cachesize}" + "MB");
                                Console.Write($"/ CPU LITHOGRAPHY: {item.nanometer}" + "NM");
                                Console.Write($"/ CPU CLOCK SPEED: {item.speed}" + "GHZ");
                            }
                            Console.ReadLine();

                            break;
                        case 2:
                            
                            foreach (var item in datas2)
                            {
                                Console.WriteLine($"Motherboard ID: {item.moboId}");
                                Console.Write($"/ Motherboard NAME: {item.name}");
                                Console.Write($"/ Motherboard CHIPSET: {item.chipsetName}");
                                Console.Write($"/ Motherboard SOCKET: {item.socketName}");
                            }
                            Console.ReadLine();
                            break;
                        default:break;
                        }
                       break;

                case 2: //addProc.Index();
                        break;

                case 3:
                    Console.WriteLine("1. ----> Delete Data From Processor Table");
                    Console.WriteLine("2. ----> Delete Data From Motherboard Table");
                    byte choose3 = Convert.ToByte(Console.ReadLine());
                    switch (choose3)
                    {
                        case 1:
                            Console.WriteLine("Please write which id going to delete from table");
                            byte deleteid = Convert.ToByte(Console.ReadLine());
                            _managercpu.DeleteTableData(deleteid);
                            break;

                        default:break;
                    }
                    break;




                default: break;
            }

        }


     
            


        
    }
}


